﻿// <copyright file="DoublyLinkedList.cs" company="Data Structures and Algorithms">
//   Copyright (C) Data Structures and Algorithms Team.
// </copyright>
// <summary>
//   Node based implementation of a linked list where every node has both a previous AND next
//   reference.
// </summary>
using System;
using System.Collections.Generic;
using Dsa.Properties;
using Dsa.Utility;

namespace Dsa.DataStructures
{
    /// <summary>
    /// Doubly linked list.
    /// </summary>
    /// <typeparam name="T">Type of <see cref="DoublyLinkedList{T}"/>.</typeparam>
    [Serializable]
    public sealed class DoublyLinkedList<T> : CollectionBase<T>
        where T : IComparable<T>
    {
        [NonSerialized]
        private DoublyLinkedListNode<T> _head;
        [NonSerialized]
        private DoublyLinkedListNode<T> _tail;
        [NonSerialized]
        private readonly IComparer<T> _comparer;

        /// <summary>
        /// Creates and initializes a new instance of the <see cref="DoublyLinkedList{T}"/> class.
        /// </summary>
        public DoublyLinkedList() 
        {
            _comparer = Comparer<T>.Default;
        }

        /// <summary>
        /// Creates and initializes a new instance of <see cref="DoublyLinkedList{T}"/>, populating it with the items of the 
        /// <see cref="IEnumerable{T}"/>.
        /// </summary>
        /// <param name="collection">Items to populate <see cref="DoublyLinkedList{T}"/> with.</param>
        public DoublyLinkedList(IEnumerable<T> collection)
            : this()
        {
            CopyCollection(collection);
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
        /// Adds a node to the tail of the <see cref="DoublyLinkedList{T}"/>.
        /// </summary>
        /// <remarks>
        /// This method is an O(1) operation. The last node is always known.
        /// </remarks>
        /// <param name="value">Value to add to the <see cref="DoublyLinkedList{T}"/>.</param>
        public void AddLast(T value)
        {
            DoublyLinkedListNode<T> n = new DoublyLinkedListNode<T>(value);
            if (IsEmpty())
            {
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
        /// <remarks>
        /// This method is an O(1) operation. The head node is always known.
        /// </remarks>
        /// <param name="value">Value to add to the <see cref="DoublyLinkedList{T}"/>.</param>
        public void AddFirst(T value)
        {
            DoublyLinkedListNode<T> n = new DoublyLinkedListNode<T>(value);
            if (IsEmpty())
            {
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
        /// <remarks>
        /// This is an O(1) operation.
        /// </remarks>
        /// <param name="node">The <see cref="DoublyLinkedListNode{T}"/> to add after.</param>
        /// <param name="value">The value of the node to add after the specified node.</param>
        public void AddAfter(DoublyLinkedListNode<T> node, T value)
        {
            ValidateAddArgs(node);

            DoublyLinkedListNode<T> n = new DoublyLinkedListNode<T>(value);

            // check if adding after _tail node
            if (node == _tail)
            {
                n.Previous = _tail;
                _tail.Next = n;
                _tail = n;
            }
            else
            {
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
        /// <remarks>
        /// This method is an O(1) operation.
        /// </remarks>
        /// <param name="node">The <see cref="DoublyLinkedListNode{T}"/> to add before.</param>
        /// <param name="value">The value of the node to add after the specified node.</param>
        public void AddBefore(DoublyLinkedListNode<T> node, T value)
        {
            ValidateAddArgs(node);

            DoublyLinkedListNode<T> n = new DoublyLinkedListNode<T>(value);

            // check if adding before _head node
            if (node == _head) 
            {
                n.Next = _head;
                _head.Previous = n;
                _head = n;
            }
            else
            {
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
        /// <remarks>
        /// This method is an O(1) operation.
        /// </remarks>
        /// <returns>True if the tail node was removed; otherwise false.</returns>
        public bool RemoveLast()
        {
            if (IsEmpty())
            {
                return false;
            }

            // check to see if there is only 1 item in the linked list
            if (_tail == _head) 
            {
                _head = null;
                _tail = null;
            }
            else if (_head.Next == _tail)
            {
                // only two nodes in the dll
                _tail = _head;
                _head.Next = null;
            }
            else
            {
                _tail = _tail.Previous;
                _tail.Next = null;
            }

            Count--;
            return true;
        }

        /// <summary>
        /// Removes the node at the head of the <see cref="DoublyLinkedList{T}"/>.
        /// </summary>
        /// <remarks>
        /// This method is an O(1) operation.
        /// </remarks>
        /// <returns>True if the head node was removed; otherwise false.</returns>
        public bool RemoveFirst()
        {
            // check first that the list has some items 
            if (IsEmpty())
            {
                return false;
            }

            if (_head.Next == null)
            {
                // only one node in the dll
                _head = null;
                _tail = null;
            }
            else if (_head.Next == _tail) 
            {
                // only two nodes in the dll
                _head = _tail;
                _head.Previous = null;
            }
            else
            {
                _head = _head.Next; // the new head is the old head nodes next node
                _head.Previous = null;
            }

            Count--;
            return true;
        }

        /// <summary>
        /// Returns an array containing all the values of the nodes contained within the <see cref="DoublyLinkedList{T}"/>.
        /// </summary>
        /// <remarks>
        /// This method is an O(n) operation where n is the number of nodes in the <see cref="DoublyLinkedList{T}"/>.
        /// </remarks>
        /// <returns>A one-dimensional <see cref="Array"/> containing the values of the nodes contained in the <see cref="DoublyLinkedList{T}"/>.</returns>
        public override T[] ToArray()
        {
            return ToArray(Count, this);
        }

        /// <summary>
        /// Indicates whether the <see cref="DoublyLinkedList{T}"/> is empty or not.
        /// </summary>
        /// <remarks>
        /// This method is an O(1) operation.
        /// </remarks>
        /// <returns>Returns true if the <see cref="DoublyLinkedList{T}"/> is empty, or false otherwise.</returns>
        public bool IsEmpty()
        {
            return _head == null;
        }

        /// <summary>
        /// Adds an item to the <see cref="ICollection{T}"/>.
        /// </summary>
        /// <remarks>
        /// This method is an O(1) operation.
        /// </remarks>
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
        /// <remarks>
        /// This method is an O(n) operation.
        /// </remarks>
        /// <param name="item">Value to search the <see cref="DoublyLinkedList{T}"/> for.</param>
        /// <returns>True if the value was found; otherwise false.</returns>
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
        /// Removes the first occurrence of a value from the <see cref="DoublyLinkedList{T}"/>.
        /// </summary>
        /// <remarks>
        /// This is an O(1) operation (best case) when there are only two nodes in the <see cref="DoublyLinkedList{T}"/>; otherwise it is an O(n) operation.
        /// </remarks>
        /// <param name="item">Value to remove from the <see cref="DoublyLinkedList{T}"/>.</param>
        /// <returns>True if the value was removed from the <see cref="DoublyLinkedList{T}"/>; false otherwise.</returns>
        public override bool Remove(T item)
        {
            if (IsEmpty())
            {
                return false;
            }

            if (_head.Next == null && Compare.AreEqual(_head.Value, item, _comparer))
            {
                // we are removing the only node in the dll
                _head = null;
                _tail = null;
                Count--;
                return true;
            }

            if (_head.Next == _tail) 
            {
                // there are only two nodes in the dll
                if (Compare.AreEqual(_head.Value, item, _comparer)) 
                {
                    _head = _head.Next; 
                    _head.Previous = null;
                }
                else if (Compare.AreEqual(_tail.Value, item, _comparer)) 
                {
                    _tail = _head; 
                    _head.Next = null;
                }

                Count--;
                return true;
            }

            DoublyLinkedListNode<T> n = _head;
            while (n != null)
            {
                if (Compare.AreEqual(n.Value, item, _comparer)) 
                {
                    // we have found a node with the value specified to remove
                    if (n == _head) 
                    {
                        // the node to remove is the head node
                        _head = _head.Next;
                        _head.Previous = null;
                    }
                    else if (n == _tail) 
                    {
                        // the node to remove is the tail node
                        _tail = _tail.Previous;
                        _tail.Next = null;
                    }
                    else 
                    {
                        // the node to remove is somewhere in the middle of the dll
                        n.Previous.Next = n.Next;
                        n.Next.Previous = n.Previous;
                    }

                    Count--;
                    return true;
                }

                n = n.Next; 
            }

            return false;
        }

        /// <summary>
        /// Traverses the items in the <see cref="DoublyLinkedList{T}"/>.
        /// </summary>
        /// <remarks>
        /// This method is an O(n) operation, where n is the number of nodes in the <see cref="DoublyLinkedList{T}"/>.
        /// </remarks>
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

        /// <summary>
        /// Method that validates the state of the DoublyLinkedListCollection(Of T) as well as if the node passed in is null.
        /// This method is used by AddAfter, and AddBefore.
        /// </summary>
        /// <param name="node">Node to verify whether or not is null.</param>
        private void ValidateAddArgs(DoublyLinkedListNode<T> node)
        {
            Guard.InvalidOperation(IsEmpty(), Resources.DoublyLinkedListEmpty);
            Guard.ArgumentNull(node, "node");
        }
    }
}
