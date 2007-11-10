using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using Dsa.Properties;

namespace Dsa.DataStructures
{

    /// <summary>
    /// <see cref="DoublyLinkedListCollection{T}"/> is an implementation of a doubly linked list data structure.
    /// </summary>
    /// <typeparam name="T">Type of <see cref="DoublyLinkedListCollection{T}"/>.</typeparam>
    [Serializable]
    [DebuggerDisplay("Count={Count}")]
    [DebuggerTypeProxy(typeof(CollectionDebugView<>))]
    public sealed class DoublyLinkedListCollection<T> : ICollection<T>, ICollection, IComparerProvider<T>
    {

        [NonSerialized]
        private DoublyLinkedListNode<T> _head;
        [NonSerialized]
        private DoublyLinkedListNode<T> _tail;
        [NonSerialized]
        private int _count;
        [NonSerialized]
        private object _syncRoot;
        [NonSerialized]
        private IComparer<T> _comparer;

        /// <summary>
        /// Initializes a new instance of the <see cref="DoublyLinkedListCollection{T}"/> class.
        /// </summary>
        public DoublyLinkedListCollection() 
        {
            _comparer = Comparer<T>.Default;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DoublyLinkedListCollection{T}"/> class with a specified <see cref="IComparer{T}"/>.
        /// </summary>
        /// <param name="comparer">Comparer to use for the <see cref="DoublyLinkedListCollection{T}"/>.</param>
        /// <exception cref="ArgumentNullException"><strong>comparer</strong> is <strong>null</strong>.</exception>
        public DoublyLinkedListCollection(IComparer<T> comparer) 
        {
            if (comparer == null)
            {
                throw new ArgumentNullException("comparer");
            }
            _comparer = comparer;
        }

        /// <summary>
        /// Adds a node to the tail of the <see cref="DoublyLinkedListCollection{T}"/>.
        /// </summary>
        /// <param name="value">Value to add to the <see cref="DoublyLinkedListCollection{T}"/>.</param>
        public void AddLast(T value)
        {
            DoublyLinkedListNode<T> n = new DoublyLinkedListNode<T>(value);
            if (IsEmpty())
            {
                // this is the first node being added to the dll, so both the head and tail is n
                _head = n;
                _tail = n;
            }
            else
            {
                _tail.Next = n; // adjust the tails next pointer to this node
                n.Prev = _tail; // set this nodes prev pointer to the tail node
                _tail = n; // make n the new tail node
            }
            _count++;
        }

        /// <summary>
        /// Adds a node to the head of the <see cref="DoublyLinkedListCollection{T}"/>.
        /// </summary>
        /// <param name="value">Value to add to the <see cref="DoublyLinkedListCollection{T}"/>.</param>
        public void AddFirst(T value)
        {
            DoublyLinkedListNode<T> n = new DoublyLinkedListNode<T>(value);
            if (IsEmpty())
            {
                // this is the first node being added to the dll, so both the head and tail is n
                _head = n;
                _tail = n;
            }
            else
            {
                _head.Prev = n; // add the node before the current head node by adjusting the current head nodes prev pointer to point to n
                n.Next = _head; // make the next pointer of n point to the head node
                _head = n; // n is now the new head node of the dll
            }
            _count++;
        }

        /// <summary>
        /// Adds a node after a specified node in the <see cref="DoublyLinkedListCollection{T}"/>.
        /// </summary>
        /// <param name="node">The <see cref="DoublyLinkedListNode{T}"/> to add after.</param>
        /// <param name="value">The value of the node to add after the specified node.</param>
        public void AddAfter(DoublyLinkedListNode<T> node, T value)
        {
            ValidateAddArgs(node);
            DoublyLinkedListNode<T> n = new DoublyLinkedListNode<T>(value);
            if (node == _tail) // the node we are adding will be the new tail node
            {
                n.Prev = _tail;
                _tail.Next = n;
                _tail = n;
            }
            else
            {
                // setup the n's pointers accordingly
                n.Next = node.Next;
                n.Next.Prev = n;
                node.Next = n;
                n.Prev = node;
            }
            _count++;
        }

        /// <summary>
        /// Adds a node before a specified node in the <see cref="DoublyLinkedListCollection{T}"/>.
        /// </summary>
        /// <param name="node">The <see cref="DoublyLinkedListNode{T}"/> to add before.</param>
        /// <param name="value">The value of the node to add after the specified node.</param>
        public void AddBefore(DoublyLinkedListNode<T> node, T value)
        {
            ValidateAddArgs(node);
            DoublyLinkedListNode<T> n = new DoublyLinkedListNode<T>(value);
            if (node == _head) // the node we are adding will be the new head node
            {
                n.Next = _head;
                _head.Prev = n;
                _head = n;
            }
            else
            {
                // setup the n's pointers accordingly
                n.Next = node;
                node.Prev.Next = n;
                n.Prev = node.Prev;
                node.Prev = n;
            }
            _count++;
        }

        /// <summary>
        /// Removes a node from the tail of the <see cref="DoublyLinkedListCollection{T}"/>.
        /// </summary>
        /// <exception cref="InvalidOperationException"><see cref="DoublyLinkedListCollection{T}"/> contains <strong>0 items</strong>.</exception>
        public void RemoveLast()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException(Resources.DoublyLinkedListEmpty); // nothing to remove
            }
            if (_tail == _head) // we are removing the only item in the dll
            {
                _head = null;
                _tail = null;
            }
            else if (_head.Next == _tail) // only two nodes in the dll
            {
                _tail = _head;
                _head.Next = null;
            }
            else
            {
                _tail = _tail.Prev; // set tail to be the old tails prev node
                _tail.Next = null;
            }
            _count--;
        }

        /// <summary>
        /// Removes the node at the head of the <see cref="DoublyLinkedListCollection{T}"/>.
        /// </summary>
        /// <exception cref="InvalidOperationException"><see cref="DoublyLinkedListCollection{T}"/> contains <strong>0 items</strong>.</exception>
        public void RemoveFirst()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException(Resources.DoublyLinkedListEmpty); // nothing to remove
            }
            if (_head.Next == null) // only one node in the dll
            {
                _head = null;
                _tail = null;
            }
            else if (_head.Next == _tail) // only two nodes in the dll
            {
                _head = _tail;
                _head.Prev = null;
            }
            else
            {
                _head = _head.Next; // the new head is the old head nodes next node
                _head.Prev = null;
            }
            _count--;
        }

        /// <summary>
        /// Returns an array containing all the values of the nodes contained within the <see cref="DoublyLinkedListCollection{T}"/>.
        /// </summary>
        /// <returns><see cref="Array"/> containing the values of the nodes contained in the <see cref="DoublyLinkedListCollection{T}"/>.</returns>
        /// <exception cref="InvalidOperationException"><see cref="DoublyLinkedListCollection{T}"/> contains <strong>0 items</strong>.</exception>
        public T[] ToArray()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException(Resources.DoublyLinkedListEmpty); // nothing to make an array out of
            }
            int index = 0;
            T[] resultArray = new T[_count]; 
            foreach (T value in this)
            {
                resultArray[index] = value; // copy dll's items to array
                index++;
            }
            return resultArray;
        }

        /// <summary>
        /// Method that validates the state of the DoublyLinkedListCollection(Of T) as well as if the node passed in is null.
        /// This method is used by AddAfter, and AddBefore.
        /// </summary>
        /// <param name="node">Node to verify whether or not is null.</param>
        private void ValidateAddArgs(DoublyLinkedListNode<T> node)
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException(Resources.DoublyLinkedListEmpty);
            }
            else if (node == null)
            {
                throw new ArgumentNullException("node");
            }
        }

        /// <summary>
        /// Indicates whether the <see cref="DoublyLinkedListCollection{T}"/> is empty or not.
        /// </summary>
        /// <returns>Returns true if the <see cref="DoublyLinkedListCollection{T}"/> is empty, or false otherwise.</returns>
        public bool IsEmpty()
        {
            return _head == null;
        }

        /// <summary>
        /// Gets the node at the head of the <see cref="DoublyLinkedListCollection{T}"/>.
        /// </summary>
        public DoublyLinkedListNode<T> Head
        {
            get { return _head; }
        }

        /// <summary>
        /// Gets the node at the end of the <see cref="DoublyLinkedListCollection{T}"/>.
        /// </summary>
        public DoublyLinkedListNode<T> Tail
        {
            get { return _tail; }
        }


        #region ICollection<T> Members

        /// <summary>
        /// Adds an item to the <see cref="ICollection{T}"/>.
        /// </summary>
        /// <param name="item">Item to add to the <see cref="ICollection{T}"/>.</param>
        void ICollection<T>.Add(T item)
        {
            AddLast(item);
        }

        /// <summary>
        /// Resets the <see cref="DoublyLinkedListCollection{T}"/> back to its default state.
        /// </summary>
        public void Clear()
        {
            _head = null;
            _tail = null;
            _count = 0;
        }

        /// <summary>
        /// Determines whether a value is in the <see cref="DoublyLinkedListCollection{T}"/>.
        /// </summary>
        /// <param name="item">Value to search the <see cref="DoublyLinkedListCollection{T}"/> for.</param>
        /// <returns>True if the value was found; false otherwise.</returns>
        public bool Contains(T item)
        {
            foreach (T value in this)
            {
                if (Comparer.Compare(value, item) == 0) return true; // item found
            }
            return false;
        }

        /// <summary>
        /// Copies the entire <see cref="DoublyLinkedListCollection{T}"/> to a compatible one-dimensional <see cref="Array"/>, starting at 
        /// the specified index of the target array.
        /// </summary>
        /// <param name="array"><see cref="Array"/> to copy values of <see cref="DoublyLinkedListCollection{T}"/> to.</param>
        /// <param name="arrayIndex">Index of array to start copying to.</param>
        public void CopyTo(T[] array, int arrayIndex)
        {
            Array.Copy(ToArray(), array, _count);
        }

        /// <summary>
        /// Gets the number of nodes contained in the <see cref="DoublyLinkedListCollection{T}"/>.
        /// </summary>
        public int Count
        {
            get { return _count; }
        }

        /// <summary>
        /// Gets whether or not the <see cref="IList"/> is readonly.
        /// </summary>
        bool ICollection<T>.IsReadOnly
        {
            get { return false; }
        }

        /// <summary>
        /// Removes the first occurrence of a value from the <see cref="DoublyLinkedListCollection{T}"/>.
        /// </summary>
        /// <param name="item">Value to remove from the <see cref="DoublyLinkedListCollection{T}"/>.</param>
        /// <returns>True if the value was removed from the <see cref="DoublyLinkedListCollection{T}"/>; false otherwise.</returns>
        /// <exception cref="InvalidOperationException"><see cref="DoublyLinkedListCollection{T}"/> contains <strong>0 items</strong>.</exception>
        public bool Remove(T item)
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException(Resources.DoublyLinkedListEmpty); // no items to remove
            }
            if (_head.Next == null && Comparer.Compare(_head.Value, item) == 0)
            {
                // we are removing the only node in the dll
                _head = null;
                _tail = null;
                _count--;
                return true;
            }
            else if (_head.Next == _tail) // there are only two nodes in the dll
            {
                if (Comparer.Compare(_head.Value, item) == 0) // the head node is to be removed
                {
                    _head = _head.Next; // the new head node is the old head nodes next node
                    _head.Prev = null;
                    _count--;
                    return true;
                }
                else if (Comparer.Compare(_tail.Value, item) == 0) // the tail node is to be removed
                {
                    _tail = _head; // as there are only two nodes in the dll make the head node the tail also
                    _head.Next = null;
                    _count--;
                    return true;
                }
            }
            else // there are more than 2 nodes in the dll
            {
                DoublyLinkedListNode<T> n = _head;
                while (n != null)
                {
                    if (Comparer.Compare(n.Value, item) == 0) // we have found a node with the value specified to remove
                    {
                        if (n == _head) // the node to remove is the head node
                        {
                            _head = _head.Next;
                            _head.Prev = null;
                        }
                        else if (n == _tail) // the node to remove is the tail node
                        {
                            _tail = _tail.Prev;
                            _tail.Next = null;
                        }
                        else // the node to remove is somewhere in the middle of the dll
                        {
                            n.Prev.Next = n.Next;
                            n.Next.Prev = n.Prev;
                        }
                        _count--;
                        return true;
                    }
                    n = n.Next; 
                }
            }
            return false; // we didn't find the value in the dll
        }

        #endregion

        #region IEnumerable<T> Members

        /// <summary>
        /// Traverses the items in the <see cref="DoublyLinkedListCollection{T}"/>.
        /// </summary>
        /// <returns>An <see cref="IEnumerator{T}" /> that can be used to iterate through the <see cref="DoublyLinkedListCollection{T}"/>.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            DoublyLinkedListNode<T> n = _head;
            while (n != null)
            {
                yield return n.Value;
                n = n.Next;
            }
        }

        #endregion

        #region IEnumerable Members

        /// <summary>
        /// Traverses the items in the <see cref="IEnumerable"/>.
        /// </summary>
        /// <returns>An <see cref="IEnumerator" /> that can be used to iterate through the <see cref="IEnumerable"/>.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion

        #region ICollection Members

        /// <summary>
        /// Copies the elements of the <see cref="ICollection"/> to an <see cref="Array"/>, starting at a particular <see cref="Array"/> index.
        /// </summary>
        /// <param name="array">Array to copy elements to.</param>
        /// <param name="index">Index of array to start copying to.</param>
        void ICollection.CopyTo(Array array, int index)
        {
            throw new NotSupportedException(Resources.ICollectionCopyToNotSupported);
        }

        /// <summary>
        /// Gets a value indicating whether access to the <see cref="ICollection"/> is synchronized (thread safe).
        /// </summary>
        bool ICollection.IsSynchronized
        {
            get { return false; }
        }

        /// <summary>
        /// Gets an object that can be used to synchronize access to the <see cref="ICollection"/>.
        /// </summary>
        object ICollection.SyncRoot
        {
            get
            {
                if (_syncRoot == null)
                {
                    Interlocked.CompareExchange(ref _syncRoot, new object(), null);
                }
                return _syncRoot;
            }
        }

        #endregion


        #region IComparerProvider<T> Members

        /// <summary>
        /// Gets the <see cref="IComparer{T}"/> being used.
        /// </summary>
        public IComparer<T> Comparer
        {
            get { return _comparer; }
        }

        #endregion
    }

}
