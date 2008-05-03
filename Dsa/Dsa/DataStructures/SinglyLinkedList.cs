using System;
using System.Collections.Generic;
using Dsa.Properties;
using Dsa.Utility;

namespace Dsa.DataStructures
{
    /// <summary>
    /// Singly linked list.
    /// </summary>
    /// <typeparam name="T">Type of the <see cref="SinglyLinkedList{T}"/>.</typeparam>
    [Serializable]
    public sealed class SinglyLinkedList<T> : CollectionBase<T>, IComparerProvider<T>
    {
        [NonSerialized]
        private SinglyLinkedListNode<T> _head;
        [NonSerialized]
        private SinglyLinkedListNode<T> _tail;
        [NonSerialized]
        private IComparer<T> _comparer;

        /// <summary>
        /// Initializes a new instance of the <see cref="SinglyLinkedList{T}"/> class.
        /// </summary>
        public SinglyLinkedList() 
        {
            _comparer = Comparer<T>.Default;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SinglyLinkedList{T}"/> class using a specified <see cref="IComparer{T}"/>.
        /// </summary>
        /// <param name="comparer">Comparer to use.</param>
        /// <exception cref="ArgumentNullException"><strong>comparer</strong> is <strong>null</strong>.</exception>
        public SinglyLinkedList(IComparer<T> comparer) 
        {
            Guard.ArgumentNull(comparer, "comparer");

            _comparer = comparer;
        }

        /// <summary>
        /// Adds a node to the tail of the <see cref="SinglyLinkedList{T}"/>.
        /// </summary>
        /// <param name="item">Item to add to the <see cref="SinglyLinkedList{T}"/>.</param>
        /// <remarks>
        /// This method is an O(1) operation, the <see cref="Tail"/> node is always known.
        /// </remarks>
        public void AddLast(T item)
        {
            SinglyLinkedListNode<T> n = new SinglyLinkedListNode<T>(item);
            if (IsEmpty())
            {
                _head = n;
                _tail = n;
            }
            else
            {
                _tail.Next = n;
                _tail = n;
            }
            Count++;
        }

        /// <summary>
        /// Adds a node to the head of the <see cref="SinglyLinkedList{T}"/>.
        /// </summary>
        /// <remarks>
        /// This method is an O(1) operation, the <see cref="Head"/> node is always known.
        /// </remarks>
        /// <param name="item">Item to add to the <see cref="SinglyLinkedList{T}"/>.</param>
        public void AddFirst(T item)
        {
            SinglyLinkedListNode<T> n = new SinglyLinkedListNode<T>(item);
            if (IsEmpty())
            {
                _head = n;
                _tail = n;
            }
            else
            {
                n.Next = _head;
                _head = n;
            }
            Count++;
        }

        /// <summary>
        /// Adds a node after the specified <see cref="SinglyLinkedListNode{T}"/> with the value of item.
        /// </summary>
        /// <remarks>
        /// This method is an O(1) operation, the node to add after and new nodes links are updated without having to perform any
        /// traversal of the linked list.
        /// </remarks>
        /// <param name="node">Node in <see cref="SinglyLinkedList{T}"/> to add node after.</param>
        /// <param name="item">Item to add to <see cref="SinglyLinkedList{T}"/>.</param>
        /// <exception cref="ArgumentNullException"><strong>node</strong> is <strong>null</strong>.</exception>
        public void AddAfter(SinglyLinkedListNode<T> node, T item)
        {
            Guard.ArgumentNull(node, "node");

            SinglyLinkedListNode<T> n = new SinglyLinkedListNode<T>(item);
            // check to see if node is the only node in the linked list
            if (node == _head && node == _tail)
            {
                _head.Next = n;
                _tail = n;
            }
            else if (node == _tail)
            {
                _tail.Next = n;
                _tail = n;
            }
            else
            {
                n.Next = node.Next;
                node.Next = n;
            }
            Count++;
        }

        /// <summary>
        /// Adds a <see cref="SinglyLinkedListNode{T}"/> before the specified <see cref="SinglyLinkedListNode{T}"/> with the specified value.
        /// </summary>
        /// <remarks>
        /// This method's best case is an O(1) operation where the node to be added before is the <see cref="Head"/> node, otherwise the
        /// method is an O(n) operation where n is the number of nodes to be traversed in order to find the node before the node to add before.
        /// </remarks>
        /// <param name="node">Node in the <see cref="SinglyLinkedList{T}"/> to add node before.</param>
        /// <param name="item">Item to add to the <see cref="SinglyLinkedList{T}"/>.</param>
        /// <exception cref="ArgumentNullException"><strong>node</strong> is <strong>null</strong>.</exception>
        public void AddBefore(SinglyLinkedListNode<T> node, T item)
        {
            Guard.ArgumentNull(node, "node");

            SinglyLinkedListNode<T> n = new SinglyLinkedListNode<T>(item);
            if (node == _head)
            {
                n.Next = _head;
                _head = n;
            }
            else
            {
                SinglyLinkedListNode<T> curr = _head;
                while (curr != null)
                {
                    if (curr.Next == node) 
                    {
                        n.Next = node;
                        curr.Next = n;
                        break;
                    }
                    curr = curr.Next;
                }
            }
            Count++;
        }

        /// <summary>
        /// Determines whether the <see cref="SinglyLinkedList{T}"/> is empty.
        /// </summary>
        /// <remarks>
        /// This method is an O(1) operation.
        /// </remarks>
        /// <returns>True if the <see cref="SinglyLinkedList{T}"/> is empty; false otherwise.</returns>
        public bool IsEmpty()
        {
            return _head == null;
        }

        /// <summary>
        /// Converts the <see cref="SinglyLinkedList{T}"/> and its items to an <see cref="Array"/>.
        /// </summary>
        /// <remarks>
        /// This method is an O(n) operation where n is the number of nodes in the linked list.
        /// </remarks>
        /// <returns>A one-dimensional <see cref="Array"/> containing the items from the <see cref="SinglyLinkedList{T}"/>.</returns>
        public override T[] ToArray()
        {
            return ToArray(Count, this);
        }

        /// <summary>
        /// Converts the <see cref="SinglyLinkedList{T}"/> and its items to an <see cref="Array"/>.
        /// </summary>
        /// <remarks>
        /// This method is an O(n) operation where n is the number of nodes in the linked list.
        /// </remarks>
        /// <returns>A one-dimensional <see cref="Array"/> containing the items from the <see cref="SinglyLinkedList{T}"/> in reverse order.</returns>
        public T[] ToReverseArray()
        {
            // note: what should we return if the list is empty? null or an empty array?
            if (_head == null)
            {
                return null;
            }

            int curr = 0;
            T[] arrayResult = new T[Count];
            foreach (T item in GetReverseEnumerator())
            {
                arrayResult[curr] = item;
                curr++;
            }
            return arrayResult;
        }

        /// <summary>
        /// Removes the last node from the <see cref="SinglyLinkedList{T}"/>.
        /// </summary>
        /// <remarks>
        /// This method's best case is an O(1) operation when the last node to remove is both the head and tail, i.e. there is only one node
        /// in the linked list, otherwise the method is an O(n) operation where n nodes have to be traversed in order to locate the node that
        /// precedes the last node.
        /// </remarks>
        /// <exception cref="InvalidOperationException"><see cref="SinglyLinkedList{T}"/> contains <strong>0</strong> items.</exception>
        public void RemoveLast() // todo: should be bool
        {
            Guard.InvalidOperation(IsEmpty(), Resources.SinglyLinkedListEmpty);

            if (_head.Next == null)
            {
                _head = null;
                _tail = null;
            }
            else
            {
                SinglyLinkedListNode<T> n = _head;
                while (n != null)
                {
                    if (n.Next == _tail) 
                    {
                        _tail = n;
                        _tail.Next = null;
                        break;
                    }
                    n = n.Next;
                }
            }
            Count--;
        }

        /// <summary>
        /// Removes the first node from the <see cref="SinglyLinkedList{T}"/>.
        /// </summary>
        /// <remarks>
        /// This method is an O(1) operation, the <see cref="Head"/> is always known.
        /// </remarks>
        /// <exception cref="InvalidOperationException"><see cref="SinglyLinkedList{T}"/> contains <strong>0</strong> items.</exception>
        public void RemoveFirst()
        {
            Guard.InvalidOperation(IsEmpty(), Resources.SinglyLinkedListEmpty);

            if (_head.Next == null) 
            {
                _head = null;
                _tail = null;
            }
            else
            {
                _head = _head.Next; 
            }
            Count--;
        }

        /// <summary>
        /// Gets the node at the head of the <see cref="SinglyLinkedList{T}"/>.
        /// </summary>
        public SinglyLinkedListNode<T> Head
        {
            get { return _head; }
        }

        /// <summary>
        /// Gets the node at the tail of the <see cref="SinglyLinkedList{T}"/>.
        /// </summary>
        public SinglyLinkedListNode<T> Tail
        {
            get { return _tail; }
        }

        /// <summary>
        /// Returns an <see cref="IEnumerator{T}"/> that iterates through the items in the <see cref="SinglyLinkedList{T}"/>.
        /// </summary>
        /// <remarks>
        /// This method is an O(n) operation where n is the number of nodes in the linked list. 
        /// </remarks>
        /// <returns>An <see cref="IEnumerator{T}" /> that can be used to iterate through the <see cref="SinglyLinkedList{T}"/>.</returns>
        public override IEnumerator<T> GetEnumerator()
        {
            SinglyLinkedListNode<T> n = Head;
            while (n != null)
            {
                yield return n.Value;
                n = n.Next;
            }
        }

        /// <summary>
        /// Adds an item to the tail of the <see cref="SinglyLinkedList{T}"/>.
        /// </summary>
        /// <remarks>
        /// This method is an O(1) operation, the <see cref="Tail"/> node is always known.
        /// </remarks>
        /// <param name="item">Item to add to the <see cref="SinglyLinkedList{T}"/>.</param>
        public override void Add(T item)
        {
            AddLast(item);
        }

        /// <summary>
        /// Resets the <see cref="SinglyLinkedList{T}"/> to its default state.
        /// </summary>
        public override void Clear()
        {
            _head = null;
            _tail = null;
            Count = 0;
        }

        /// <summary>
        /// Determines whether a value is in the <see cref="SinglyLinkedList{T}"/>.
        /// </summary>
        /// <remarks>
        /// This method is an O(n) operation where n is the number of nodes in the linked list.
        /// </remarks>
        /// <param name="item">Value to search for.</param>
        /// <returns>True if the value is in the <see cref="SinglyLinkedList{T}"/>; false otherwise.</returns>
        public override bool Contains(T item)
        {
            foreach (T value in this)
            {
                if (Compare.AreEqual(value, item, _comparer))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Removes the first occurrence of a value from the <see cref="SinglyLinkedList{T}"/>.
        /// </summary>
        /// <remarks>
        /// This method has a best case O(1) operation where te node to be removed is the head node, otherwise the method is an O(n) operation
        /// where n represents the number of nodes to traverse in order to update the node pointers appropriately.
        /// </remarks>
        /// <param name="item">Value to remove</param>
        /// <returns>True if the value was found and removed; false otherwise.</returns>
        public override bool Remove(T item)
        {
            if (IsEmpty())
            {
                return false;
            }

            SinglyLinkedListNode<T> n = _head;
            // check to see if the node to be removed is the head node
            if (Compare.AreEqual(n.Value, item, _comparer))
            {
                if (n == _tail)
                {
                    _tail = null; 
                }
                _head = _head.Next;
                Count--;
                return true;
            }

            while (n != null)
            {
                if (!(Compare.AreEqual(n.Value, item, _comparer)) && n.Next == null)
                {
                    break; // we couldn't find the value to remove in the linked list
                }
                if (Compare.AreEqual(n.Next.Value, item, _comparer)) // we have found the node to remove
                {
                    if (n.Next == _tail)
                    {
                        // the node to be removed was the tail so we need to make n the new tail
                        _tail = n;
                        n.Next = null;
                        Count--;
                        return true;
                    }
                    // the node to remove is somewhere in the middle of the linked list
                    n.Next = n.Next.Next;
                    Count--;
                    return true;
                }
                n = n.Next;
            }
            return false;
        }

        /// <summary>
        /// Returns an <see cref="IEnumerable{T}"/> that iterates through the items in the <see cref="SinglyLinkedList{T}"/> in reverse order.
        /// </summary>
        /// <remarks>
        /// This method is an O(n) operation where n is the number of nodes in the linked list.
        /// </remarks>
        /// <returns>An <see cref="IEnumerable{T}" /> that can be used to iterate through the <see cref="SinglyLinkedList{T}"/>.</returns>
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

        /// <summary>
        /// Gets the <seealso cref=" IComparer{T}"/> being used.
        /// </summary>
        IComparer<T> IComparerProvider<T>.Comparer
        {
            get { return _comparer; }
        }
    }
}