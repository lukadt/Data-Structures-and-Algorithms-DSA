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
        private DoublyLinkedListNode<T> head;
        [NonSerialized]
        private DoublyLinkedListNode<T> tail;
        [NonSerialized]
        private readonly IComparer<T> comparer;

        /// <summary>
        /// Creates and initializes a new instance of the <see cref="DoublyLinkedList{T}"/> class.
        /// </summary>
        public DoublyLinkedList() 
        {
            comparer = Comparer<T>.Default;
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
            get { return head; }
        }

        /// <summary>
        /// Gets the node at the end of the <see cref="DoublyLinkedList{T}"/>.
        /// </summary>
        public DoublyLinkedListNode<T> Tail
        {
            get { return tail; }
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
                head = n;
                tail = n;
            }
            else
            {
                tail.Next = n; 
                n.Previous = tail; 
                tail = n; 
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
                head = n;
                tail = n;
            }
            else
            {
                head.Previous = n; 
                n.Next = head; 
                head = n; 
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
            if (node == tail)
            {
                n.Previous = tail;
                tail.Next = n;
                tail = n;
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
            if (node == head) 
            {
                n.Next = head;
                head.Previous = n;
                head = n;
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
            if (tail == head) 
            {
                head = null;
                tail = null;
            }
            else if (head.Next == tail)
            {
                // only two nodes in the dll
                tail = head;
                head.Next = null;
            }
            else
            {
                tail = tail.Previous;
                tail.Next = null;
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

            if (head.Next == null)
            {
                // only one node in the dll
                head = null;
                tail = null;
            }
            else if (head.Next == tail) 
            {
                // only two nodes in the dll
                head = tail;
                head.Previous = null;
            }
            else
            {
                head = head.Next; // the new head is the old head nodes next node
                head.Previous = null;
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
            return head == null;
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
            head = null;
            tail = null;
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
                if (Compare.AreEqual(value, item, comparer))
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
            // case 1: empty list
            if (IsEmpty())
            {
                return false;
            }

            if (Compare.AreEqual(item, head.Value, comparer))
            {
                if (head == tail)
                {
                    // case 2: only one node in the list
                    head = null;
                    tail = null;
                }
                else
                {
                    // case 3: head is to be removed in a list that contains > 1 node
                    head = head.Next;
                    head.Previous = null;
                }

                Count--;
                return true;
            }

            DoublyLinkedListNode<T> n = head.Next;
            while (n != null && !Compare.AreEqual(item, n.Value, comparer))
            {
                n = n.Next;
            }

            if (n == tail)
            {
                // case 4: tail is to be removed
                tail = tail.Previous;
                tail.Next = null;
                Count--;
                return true;
            }
            else if (n != null)
            {
                // case 5: node to be removed is somewhere inbetween the head and tail
                n.Previous.Next = n.Next;
                n.Next.Previous = n.Previous;
                Count--;
                return true;
            }

            return false; // case 6: value not in list
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
            DoublyLinkedListNode<T> n = head;
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
