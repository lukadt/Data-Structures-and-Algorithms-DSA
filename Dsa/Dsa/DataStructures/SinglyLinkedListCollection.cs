using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using Dsa.Properties;

namespace Dsa.DataStructures
{

    /// <summary>
    /// <see cref="SinglyLinkedListCollection{T}"/> is an implementation of a singly linked list data structure.
    /// </summary>
    /// <typeparam name="T">Type of the <see cref="SinglyLinkedListCollection{T}"/>.</typeparam>
    [Serializable]
    [DebuggerDisplay("Count={Count}")]
    [DebuggerTypeProxy(typeof(CollectionDebugView<>))]
    public sealed class SinglyLinkedListCollection<T> : ICollection<T>, ICollection, IComparerProvider<T>
    {

        [NonSerialized]
        private SinglyLinkedListNode<T> _head;
        [NonSerialized]
        private SinglyLinkedListNode<T> _tail;
        [NonSerialized]
        private int _count;
        [NonSerialized]
        private object _syncRoot;
        [NonSerialized]
        private IComparer<T> _comparer;


        /// <summary>
        /// Initializes a new instance of the <see cref="SinglyLinkedListCollection{T}"/> class.
        /// </summary>
        public SinglyLinkedListCollection() 
        {
            _comparer = Comparer<T>.Default;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SinglyLinkedListCollection{T}"/> class using a specified <see cref="IComparer{T}"/>.
        /// </summary>
        /// <param name="comparer">Comparer to use.</param>
        /// <exception cref="ArgumentNullException"><strong>comparer</strong> is <strong>null</strong>.</exception>
        public SinglyLinkedListCollection(IComparer<T> comparer) 
        {
            if (comparer == null)
            {
                throw new ArgumentNullException("comparer");
            }
            _comparer = comparer;
        }

        /// <summary>
        /// Adds a node to the tail of the <see cref="SinglyLinkedListCollection{T}"/>.
        /// </summary>
        /// <param name="item">Item to add to the <see cref="SinglyLinkedListCollection{T}"/>.</param>
        public void AddLast(T item)
        {
            SinglyLinkedListNode<T> n = new SinglyLinkedListNode<T>(item);
            if (IsEmpty())
            {
                // this is the first node in the sll, head and tail point to the same node
                _head = n;
                _tail = n;
            }
            else
            {
                _tail.Next = n;
                _tail = n;
            }
            _count++;
        }

        /// <summary>
        /// Adds a node to the head of the <see cref="SinglyLinkedListCollection{T}"/>.
        /// </summary>
        /// <param name="item">Item to add to the <see cref="SinglyLinkedListCollection{T}"/>.</param>
        public void AddFirst(T item)
        {
            SinglyLinkedListNode<T> n = new SinglyLinkedListNode<T>(item);
            if (IsEmpty())
            {
                // this is the first node in the SinglyLinkedListCollection, head and tail point to the same node
                _head = n;
                _tail = n;
            }
            else
            {
                n.Next = _head;
                _head = n;
            }
            _count++;
        }

        /// <summary>
        /// Adds a node after the specified <see cref="SinglyLinkedListNode{T}"/> with the value of item.
        /// </summary>
        /// <param name="node">Node in <see cref="SinglyLinkedListCollection{T}"/> to add node after.</param>
        /// <param name="item">Item to add to <see cref="SinglyLinkedListCollection{T}"/>.</param>
        /// <exception cref="InvalidOperationException"><see cref="SinglyLinkedListCollection{T}"/> contains <strong>0 items</strong>.</exception>
        /// <exception cref="ArgumentNullException"><strong>node</strong> is <strong>null</strong>.</exception>
        public void AddAfter(SinglyLinkedListNode<T> node, T item)
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException(Resources.SinglyLinkedListEmpty); // nothing to add after
            }
            if (node == null)
            {
                throw new ArgumentNullException("node");
            }
            else
            {
                SinglyLinkedListNode<T> n = new SinglyLinkedListNode<T>(item);
                if (node == _head && node == _tail)
                {
                    // node passed in is the only node in the SinglyLinkedListCollection
                    _head.Next = n;
                    _tail = n;
                }
                else if (node == _tail)
                {
                    // node passed in is the tail node
                    _tail.Next = n;
                    _tail = n;
                }
                else
                {
                    // we are adding a node somewhere in the middle of the sll
                    n.Next = node.Next;
                    node.Next = n;
                }
                _count++;
            }
        }

        /// <summary>
        /// Adds a <see cref="SinglyLinkedListNode{T}"/> before the specified <see cref="SinglyLinkedListNode{T}"/> with the specified value.
        /// </summary>
        /// <param name="node">Node in the <see cref="SinglyLinkedListCollection{T}"/> to add node before.</param>
        /// <param name="item">Item to add to the <see cref="SinglyLinkedListCollection{T}"/>.</param>
        /// <exception cref="InvalidOperationException"><see cref="SinglyLinkedListCollection{T}"/> contains <strong>0 items</strong>.</exception>
        /// <exception cref="ArgumentNullException"><strong>node</strong> is <strong>null</strong>.</exception>
        public void AddBefore(SinglyLinkedListNode<T> node, T item)
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException(Resources.SinglyLinkedListEmpty); // nothing to add before
            }
            if (node == null)
            {
                throw new ArgumentNullException("node");
            }
            else
            {
                SinglyLinkedListNode<T> n = new SinglyLinkedListNode<T>(item);
                if (node == _head)
                {
                    // we are adding a node before the head node
                    n.Next = _head;
                    _head = n;
                }
                else
                {
                    SinglyLinkedListNode<T> curr = _head;
                    while (curr != null)
                    {
                        if (curr.Next == node) // we have found the node to add before
                        {
                            n.Next = node;
                            curr.Next = n;
                            break;
                        }
                        curr = curr.Next;
                    }
                }
                _count++;
            }
        }

        /// <summary>
        /// Determines whether the <see cref="SinglyLinkedListCollection{T}"/> is empty.
        /// </summary>
        /// <returns>True if the <see cref="SinglyLinkedListCollection{T}"/> is empty; false otherwise.</returns>
        public bool IsEmpty()
        {
            return _head == null;
        }

        /// <summary>
        /// Converts the <see cref="SinglyLinkedListCollection{T}"/> and its items to an <see cref="Array"/>.
        /// </summary>
        /// <returns>An <see cref="Array"/> containing the items from the <see cref="SinglyLinkedListCollection{T}"/>.</returns>
        /// <exception cref="InvalidOperationException"><see cref="SinglyLinkedListCollection{T}"/> contains <strong>0 items</strong>.</exception>
        public T[] ToArray()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException(Resources.SinglyLinkedListEmpty); // nothing to copy to array
            }
            else
            {
                int curr = 0; // index of array at which current nodes value is stored
                T[] arrayResult = new T[_count];
                foreach (T value in this)
                {
                    arrayResult[curr] = value; // copy items to array
                    curr++;
                }
                return arrayResult;
            }
        }

        /// <summary>
        /// Converts the <see cref="SinglyLinkedListCollection{T}"/> and its items to an <see cref="Array"/>.
        /// </summary>
        /// <returns>An <see cref="Array"/> containing the items from the <see cref="SinglyLinkedListCollection{T}"/> in reverse order.</returns>
        /// <exception cref="InvalidOperationException"><see cref="SinglyLinkedListCollection{T}"/> contains <strong>0 items</strong>.</exception>
        public T[] ToReverseArray()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException(Resources.SinglyLinkedListEmpty); // nothing to add to array
            }
            else
            {
                int curr = 0;
                T[] arrayResult = new T[_count];
                foreach (T item in GetReverseEnumerator())
                {
                    arrayResult[curr] = item; // add item to array
                    curr++;
                }
                return arrayResult;
            }
        }

        /// <summary>
        /// Removes the last node from the <see cref="SinglyLinkedListCollection{T}"/>.
        /// </summary>
        /// <exception cref="InvalidOperationException"><see cref="SinglyLinkedListCollection{T}"/> contains <strong>0 items</strong>.</exception>
        public void RemoveLast()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException(Resources.SinglyLinkedListEmpty); // nothing to remove
            }
            else
            {
                if (_head.Next == null)
                {
                    // only one node in the SinglyLinkedListCollection
                    _head = null;
                    _tail = null;
                }
                else
                {
                    // traverse SinglyLinkedListCollection until we find the tail
                    SinglyLinkedListNode<T> n = _head;
                    while (n != null)
                    {
                        if (n.Next == _tail) // we have found the tail node
                        {
                            _tail = n;
                            _tail.Next = null;
                            break;
                        }
                        n = n.Next;
                    }
                }
                _count--;
            }
        }

        /// <summary>
        /// Removes the first node from the <see cref="SinglyLinkedListCollection{T}"/>.
        /// </summary>
        /// <exception cref="InvalidOperationException"><see cref="SinglyLinkedListCollection{T}"/> contains <strong>0 items</strong>.</exception>
        public void RemoveFirst()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException(Resources.SinglyLinkedListEmpty); // nothing to remove
            }
            else
            {
                if (_head.Next == null) // only one node in the sll
                {
                    _head = null;
                    _tail = null;
                }
                else
                {
                    _head = _head.Next; // the head node is the prevoius head nodes next link
                }
                _count--;
            }
        }

        /// <summary>
        /// Get's the node at the head of the <see cref="SinglyLinkedListCollection{T}"/>.
        /// </summary>
        public SinglyLinkedListNode<T> Head
        {
            get { return _head; }
        }

        /// <summary>
        /// Get's the node at the tail of the <see cref="SinglyLinkedListCollection{T}"/>.
        /// </summary>
        public SinglyLinkedListNode<T> Tail
        {
            get { return _tail; }
        }

        #region IEnumerable<T> Members

        /// <summary>
        /// Returns an <see cref="IEnumerator{T}"/> that iterates through the items in the <see cref="SinglyLinkedListCollection{T}"/>.
        /// </summary>
        /// <returns>An <see cref="IEnumerator{T}" /> that can be used to iterate through the <see cref="SinglyLinkedListCollection{T}"/>.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            SinglyLinkedListNode<T> n = Head;
            while (n != null)
            {
                yield return n.Value;
                n = n.Next;
            }
        }

        #endregion

        #region IEnumerable Members

        /// <summary>
        /// Returns an <see cref="IEnumerator"/> that iterates through the items in the <see cref="IEnumerable"/>.
        /// </summary>
        /// <returns>An <see cref="IEnumerator" /> that can be used to iterate through the <see cref="IEnumerable"/>.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion

        #region ICollection<T> Members

        /// <summary>
        /// Adds an item to the tail of the <see cref="SinglyLinkedListCollection{T}"/>.
        /// </summary>
        /// <param name="item">Item to add to the <see cref="SinglyLinkedListCollection{T}"/>.</param>
        public void Add(T item)
        {
            AddLast(item);
        }

        /// <summary>
        /// Resets the <see cref="SinglyLinkedListCollection{T}"/> to its default state.
        /// </summary>
        public void Clear()
        {
            _head = null;
            _tail = null;
            _count = 0;
        }

        /// <summary>
        /// Determines whether a value is in the <see cref="SinglyLinkedListCollection{T}"/>.
        /// </summary>
        /// <param name="item">Value to search for.</param>
        /// <returns>True if the value is in the <see cref="SinglyLinkedListCollection{T}"/>; false otherwise.</returns>
        public bool Contains(T item)
        {
            foreach (T value in this)
            {
                if (Comparer.Compare(value, item) == 0) return true; // we have found the item
            }
            return false;
        }

        /// <summary>
        /// Copies the entire <see cref="SinglyLinkedListCollection{T}"/> to a compatible one-dimensional <see cref="Array"/>.
        /// </summary>
        /// <param name="array">Array to copy <see cref="SinglyLinkedListCollection{T}"/> items to.</param>
        public void CopyTo(T[] array)
        {
            Array.Copy(ToArray(), array, _count);
        }

        /// <summary>
        /// Copies the entire <see cref="SinglyLinkedListCollection{T}"/> to a compatible one-dimensional <see cref="Array"/>, starting at the specified 
        /// index of the target <see cref="Array"/>.
        /// </summary>
        /// <param name="array">Array to copy <see cref="SinglyLinkedListCollection{T}"/> to.</param>
        /// <param name="arrayIndex">Index of array to start copying to.</param>
        public void CopyTo(T[] array, int arrayIndex)
        {
            Array.Copy(ToArray(), 0, array, arrayIndex, _count);
        }

        /// <summary>
        /// Removes the first occurrence of a value from the <see cref="SinglyLinkedListCollection{T}"/>.
        /// </summary>
        /// <param name="item">Value to remove</param>
        /// <returns>True if the value was found and removed; false otherwise.</returns>
        /// <exception cref="InvalidOperationException"><see cref="SinglyLinkedListCollection{T}"/> contains <strong>0 items</strong>.</exception>
        public bool Remove(T item)
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException(Resources.SinglyLinkedListEmpty); // nothing to remove
            }
            SinglyLinkedListNode<T> n = _head;
            if (Comparer.Compare(n.Value, item) == 0)
            {
                // node to be removed is the head node
                if (n == _tail)
                {
                    _tail = null; // n is head and tail, make tail null
                }
                // if n was the only node in the list then head is now null as well as tail, if not head has been updated to its next node
                _head = _head.Next;
                _count--;
                return true;
            }
            while (n != null)
            {
                if (!(Comparer.Compare(n.Value, item) == 0) && n.Next == null) break; // we couldn't find the value to remove in the sll
                else if (Comparer.Compare(n.Next.Value, item) == 0) // we have found the node to remove
                {
                    if (n.Next == _tail)
                    {
                        // the node to be removed was the tail so we need to make n the new tail
                        _tail = n;
                        n.Next = null;
                        _count--;
                        return true;
                    }
                    n.Next = n.Next.Next;
                    _count--;
                    return true;
                }
                else
                {
                    n = n.Next;
                }
            }
            return false;
        }

        /// <summary>
        /// Gets whether the <see cref="ICollection{T}"/> is read only.
        /// </summary>
        bool ICollection<T>.IsReadOnly
        {
            get { return false; }
        }

        /// <summary>
        /// Get's the count of nodes in the <see cref="SinglyLinkedListCollection{T}"/>.
        /// </summary>
        public int Count
        {
            get { return _count; }
        }

        #endregion

        /// <summary>
        /// Returns an <see cref="IEnumerable{T}"/> that iterates through the items in the <see cref="SinglyLinkedListCollection{T}"/> in reverse order.
        /// </summary>
        /// <returns>An <see cref="IEnumerable{T}" /> that can be used to iterate through the <see cref="SinglyLinkedListCollection{T}"/>.</returns>
        public IEnumerable<T> GetReverseEnumerator()
        {
            SinglyLinkedListNode<T> n = _head;
            SinglyLinkedListNode<T> curr = _tail;
            while (n != curr)
            {
                if (n.Next == curr)
                {
                    yield return curr.Value;
                    curr = n;
                    n = _head;
                }
                else
                {
                    n = n.Next;
                }
            }
            yield return n.Value;
        }

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
        /// Gets the <seealso cref=" IComparer{T}"/> being used.
        /// </summary>
        public IComparer<T> Comparer
        {
            get { return _comparer; }
        }

        #endregion
    }

}
