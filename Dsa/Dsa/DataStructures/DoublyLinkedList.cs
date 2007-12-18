using System;
using System.Collections.Generic;
using Dsa.Properties;

namespace Dsa.DataStructures
{

    /// <summary>
    /// <see cref="DoublyLinkedList{T}"/> is an implementation of a doubly linked list data structure.
    /// </summary>
    /// <typeparam name="T">Type of <see cref="DoublyLinkedList{T}"/>.</typeparam>
    [Serializable]
    public sealed class DoublyLinkedList<T> : CollectionBase<T>, IComparerProvider<T>
    {

        [NonSerialized]
        private DoublyLinkedListNode<T> _head;
        [NonSerialized]
        private DoublyLinkedListNode<T> _tail;
        [NonSerialized]
        private IComparer<T> _comparer;

        /// <summary>
        /// Initializes a new instance of the <see cref="DoublyLinkedList{T}"/> class.
        /// </summary>
        public DoublyLinkedList() 
        {
            _comparer = Comparer<T>.Default;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DoublyLinkedList{T}"/> class with a specified <see cref="IComparer{T}"/>.
        /// </summary>
        /// <param name="comparer">Comparer to use for the <see cref="DoublyLinkedList{T}"/>.</param>
        /// <exception cref="ArgumentNullException"><strong>comparer</strong> is <strong>null</strong>.</exception>
        public DoublyLinkedList(IComparer<T> comparer) 
        {
            if (comparer == null)
            {
                throw new ArgumentNullException("comparer");
            }
            _comparer = comparer;
        }

        /// <summary>
        /// Adds a node to the tail of the <see cref="DoublyLinkedList{T}"/>.
        /// </summary>
        /// <param name="value">Value to add to the <see cref="DoublyLinkedList{T}"/>.</param>
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
                _tail.Next = n; 
                n.Previous = _tail; 
                _tail = n; 
            }
            Count++;
        }

        /// <summary>
        /// Adds a node to the head of the <see cref="DoublyLinkedList{T}"/>.
        /// </summary>
        /// <param name="value">Value to add to the <see cref="DoublyLinkedList{T}"/>.</param>
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
                _head.Previous = n; 
                n.Next = _head; 
                _head = n; 
            }
            Count++;
        }

        /// <summary>
        /// Adds a node after a specified node in the <see cref="DoublyLinkedList{T}"/>.
        /// </summary>
        /// <param name="node">The <see cref="DoublyLinkedListNode{T}"/> to add after.</param>
        /// <param name="value">The value of the node to add after the specified node.</param>
        public void AddAfter(DoublyLinkedListNode<T> node, T value)
        {
            ValidateAddArgs(node);
            DoublyLinkedListNode<T> n = new DoublyLinkedListNode<T>(value);
            if (node == _tail) // the node we are adding will be the new tail node
            {
                n.Previous = _tail;
                _tail.Next = n;
                _tail = n;
            }
            else
            {
                // setup the n's pointers accordingly
                n.Next = node.Next;
                n.Next.Previous = n;
                node.Next = n;
                n.Previous = node;
            }
            Count++;
        }

        /// <summary>
        /// Adds a node before a specified node in the <see cref="DoublyLinkedList{T}"/>.
        /// </summary>
        /// <param name="node">The <see cref="DoublyLinkedListNode{T}"/> to add before.</param>
        /// <param name="value">The value of the node to add after the specified node.</param>
        public void AddBefore(DoublyLinkedListNode<T> node, T value)
        {
            ValidateAddArgs(node);
            DoublyLinkedListNode<T> n = new DoublyLinkedListNode<T>(value);
            // check to see if we are adding before the head node
            if (node == _head) 
            {
                n.Next = _head;
                _head.Previous = n;
                _head = n;
            }
            else
            {
                // setup the n's pointers accordingly
                n.Next = node;
                node.Previous.Next = n;
                n.Previous = node.Previous;
                node.Previous = n;
            }
            Count++;
        }

        /// <summary>
        /// Removes a node from the tail of the <see cref="DoublyLinkedList{T}"/>.
        /// </summary>
        /// <exception cref="InvalidOperationException"><see cref="DoublyLinkedList{T}"/> contains <strong>0 items</strong>.</exception>
        public void RemoveLast()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException(Resources.DoublyLinkedListEmpty); 
            }
            // check to see if there is only 1 item in the linked list
            if (_tail == _head) 
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
                _tail = _tail.Previous; // set tail to be the old tails Previous node
                _tail.Next = null;
            }
            Count--;
        }

        /// <summary>
        /// Removes the node at the head of the <see cref="DoublyLinkedList{T}"/>.
        /// </summary>
        /// <exception cref="InvalidOperationException"><see cref="DoublyLinkedList{T}"/> contains <strong>0 items</strong>.</exception>
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
                _head.Previous = null;
            }
            else
            {
                _head = _head.Next; // the new head is the old head nodes next node
                _head.Previous = null;
            }
            Count--;
        }

        /// <summary>
        /// Returns an array containing all the values of the nodes contained within the <see cref="DoublyLinkedList{T}"/>.
        /// </summary>
        /// <returns><see cref="Array"/> containing the values of the nodes contained in the <see cref="DoublyLinkedList{T}"/>.</returns>
        /// <exception cref="InvalidOperationException"><see cref="DoublyLinkedList{T}"/> contains <strong>0 items</strong>.</exception>
        public override T[] ToArray()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException(Resources.DoublyLinkedListEmpty); // nothing to make an array out of
            }
            int index = 0;
            T[] resultArray = new T[Count]; 
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
        /// Indicates whether the <see cref="DoublyLinkedList{T}"/> is empty or not.
        /// </summary>
        /// <returns>Returns true if the <see cref="DoublyLinkedList{T}"/> is empty, or false otherwise.</returns>
        public bool IsEmpty()
        {
            return _head == null;
        }

        /// <summary>
        /// Gets the node at the head of the <see cref="DoublyLinkedList{T}"/>.
        /// </summary>
        public DoublyLinkedListNode<T> Head
        {
            get { return _head; }
        }

        /// <summary>
        /// Gets the node at the end of the <see cref="DoublyLinkedList{T}"/>.
        /// </summary>
        public DoublyLinkedListNode<T> Tail
        {
            get { return _tail; }
        }

        /// <summary>
        /// Adds an item to the <see cref="ICollection{T}"/>.
        /// </summary>
        /// <param name="item">Item to add to the <see cref="ICollection{T}"/>.</param>
        public override void Add(T item)
        {
            AddLast(item);
        }

        /// <summary>
        /// Resets the <see cref="DoublyLinkedList{T}"/> back to its default state.
        /// </summary>
        public override void Clear()
        {
            _head = null;
            _tail = null;
           Count = 0;
        }

        /// <summary>
        /// Determines whether a value is in the <see cref="DoublyLinkedList{T}"/>.
        /// </summary>
        /// <param name="item">Value to search the <see cref="DoublyLinkedList{T}"/> for.</param>
        /// <returns>True if the value was found; false otherwise.</returns>
        public override bool Contains(T item)
        {
            foreach (T value in this)
            {
                if (_comparer.Compare(value, item) == 0) return true; // item found
            }
            return false;
        }

        /// <summary>
        /// Removes the first occurrence of a value from the <see cref="DoublyLinkedList{T}"/>.
        /// </summary>
        /// <param name="item">Value to remove from the <see cref="DoublyLinkedList{T}"/>.</param>
        /// <returns>True if the value was removed from the <see cref="DoublyLinkedList{T}"/>; false otherwise.</returns>
        /// <exception cref="InvalidOperationException"><see cref="DoublyLinkedList{T}"/> contains <strong>0 items</strong>.</exception>
        public override bool Remove(T item)
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException(Resources.DoublyLinkedListEmpty); // no items to remove
            }
            if (_head.Next == null && _comparer.Compare(_head.Value, item) == 0)
            {
                // we are removing the only node in the dll
                _head = null;
                _tail = null;
                Count--;
                return true;
            }
            else if (_head.Next == _tail) // there are only two nodes in the dll
            {
                if (_comparer.Compare(_head.Value, item) == 0) // the head node is to be removed
                {
                    _head = _head.Next; // the new head node is the old head nodes next node
                    _head.Previous = null;
                    Count--;
                    return true;
                }
                else if (_comparer.Compare(_tail.Value, item) == 0) // the tail node is to be removed
                {
                    _tail = _head; // as there are only two nodes in the dll make the head node the tail also
                    _head.Next = null;
                    Count--;
                    return true;
                }
            }
            else // there are more than 2 nodes in the dll
            {
                DoublyLinkedListNode<T> n = _head;
                while (n != null)
                {
                    if (_comparer.Compare(n.Value, item) == 0) // we have found a node with the value specified to remove
                    {
                        if (n == _head) // the node to remove is the head node
                        {
                            _head = _head.Next;
                            _head.Previous = null;
                        }
                        else if (n == _tail) // the node to remove is the tail node
                        {
                            _tail = _tail.Previous;
                            _tail.Next = null;
                        }
                        else // the node to remove is somewhere in the middle of the dll
                        {
                            n.Previous.Next = n.Next;
                            n.Next.Previous = n.Previous;
                        }
                        Count--;
                        return true;
                    }
                    n = n.Next; 
                }
            }
            return false; // we didn't find the value in the dll
        }

        /// <summary>
        /// Traverses the items in the <see cref="DoublyLinkedList{T}"/>.
        /// </summary>
        /// <returns>An <see cref="IEnumerator{T}" /> that can be used to iterate through the <see cref="DoublyLinkedList{T}"/>.</returns>
        public override IEnumerator<T> GetEnumerator()
        {
            DoublyLinkedListNode<T> n = _head;
            while (n != null)
            {
                yield return n.Value;
                n = n.Next;
            }
        }

        #region IComparerProvider<T> Members

        /// <summary>
        /// Gets the <see cref="IComparer{T}"/> being used.
        /// </summary>
        IComparer<T> IComparerProvider<T>.Comparer
        {
            get { return _comparer; }
        }

        #endregion
    }

}
