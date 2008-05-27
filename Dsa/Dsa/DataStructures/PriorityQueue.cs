// <copyright file="PriorityQueue.cs" company="Data Structures and Algorithms">
//   Copyright (C) Data Structures and Algorithms Team.
// </copyright>
// <summary>
//   Heap based implementation of a PriorityQueue.
// </summary>
using System;
using Dsa.Properties;
using Dsa.Utility;

namespace Dsa.DataStructures
{
    /// <summary>
    /// Priority queue.
    /// </summary>
    /// <remarks>
    /// Higher priority given to "lower" value objects by default.
    /// </remarks>
    /// <typeparam name="T">Type of the <see cref="PriorityQueue{T}"/>.</typeparam>
    public class PriorityQueue<T> : CollectionBase<T>
    {
        private readonly Strategy _strategy;
        private readonly Heap<T> _heap;

        /// <summary>
        /// Creates and initializes a new instance of <see cref="PriorityQueue{T}"/>.
        /// </summary>
        public PriorityQueue()
        {
            _strategy = Strategy.Min;
            _heap = new Heap<T>(_strategy);
        }

        /// <summary>
        /// Adds an item to the queue.
        /// </summary>
        /// <remarks>
        /// This is an O(log n) operation.
        /// </remarks>
        /// <param name="item">Item to add to the queue.</param>
        public override void Add(T item)
        {
            Enqueue(item);
        }

        /// <summary>
        /// Clears the <see cref="PriorityQueue{T}"/>.
        /// </summary>
        /// <remarks>
        /// This is an O(1) operation.
        /// </remarks>
        public override void Clear()
        {
            _heap.Clear();
            Count = 0;
        }

        /// <summary>
        /// Determines whether or not the <see cref="PriorityQueue{T}"/> contains a specific item.
        /// </summary>
        /// <remarks>
        /// This is an O(n) operation where n is the number of items in the <see cref="PriorityQueue{T}"/>.
        /// </remarks>
        /// <param name="item">Item to see if the queue contains.</param>
        /// <returns>True if the item is in the queue; otherwise false.</returns>
        public override bool Contains(T item)
        {
            return _heap.Contains(item);
        }

        /// <summary>
        /// Not supported.
        /// </summary>
        /// <param name="item">Item to remove from the collection.</param>
        /// <returns>True if the item was removed; otherwise false.</returns>
        /// <exception cref="NotSupportedException">Remove is not supported on the queue.</exception>
        public override bool Remove(T item)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Converts the <see cref="PriorityQueue{T}"/> to a one-dimensional array.
        /// </summary>
        /// <remarks>
        /// This method is an O(n) operation where n is the number of items in the <see cref="PriorityQueue{T}"/>.
        /// </remarks>
        /// <returns>A one-dimensional <see cref="Array"/> containing the values of the items contained in the 
        /// <see cref="PriorityQueue{T}"/>.</returns>
        public override T[] ToArray()
        {
            return _heap.ToArray();
        }

        /// <summary>
        /// Peeks at the item at the front of the queue.
        /// </summary>
        /// <remarks>
        /// This is an O(1) operation.
        /// </remarks>
        /// <returns>The item at the front of the queue.</returns>
        /// <exception cref="InvalidOperationException"><strong>Count</strong> is less than <strong>1</strong>.</exception>
        public T Peek()
        {
            Guard.InvalidOperation(Count < 1, Resources.QueueEmpty);

            return _heap[0];
        }

        /// <summary>
        /// Adds an item to the queue.
        /// </summary>
        /// <remarks>
        /// This is an O(log n) operation.
        /// </remarks>
        /// <param name="item">Item to add to the queue.</param>
        public void Enqueue(T item)
        {
            _heap.Add(item);
            Count++;
        }

        /// <summary>
        /// Removes and returns the item at the front of the queue.
        /// </summary>
        /// <remarks>
        /// This is an O(1) operation.
        /// </remarks>
        /// <returns>The item at the front of the queue.</returns>
        /// <exception cref="InvalidOperationException"><strong>Count</strong> is less than <strong>1</strong>.</exception>
        public T Dequeue()
        {
            Guard.InvalidOperation(Count < 1, Resources.QueueEmpty);

            T head = _heap[0];
            _heap.Remove(head);
            Count--;
            return head;
        }
    }
}
