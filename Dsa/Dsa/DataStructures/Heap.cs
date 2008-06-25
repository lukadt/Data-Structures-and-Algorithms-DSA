// <copyright file="Heap.cs" company="Data Structures and Algorithms">
//   Copyright (C) Data Structures and Algorithms Team.
// </copyright>
// <summary>
//   Array based implementation of a Heap.
// </summary>
using System;
using System.Collections.Generic;
using Dsa.Algorithms;
using Dsa.Properties;
using Dsa.Utility;

namespace Dsa.DataStructures
{
    /// <summary>
    /// Heap data structure.
    /// </summary>
    /// <remarks>
    /// Min heap by default.
    /// </remarks>
    /// <typeparam name="T">Type of heap.</typeparam>
    public sealed class Heap<T> : CollectionBase<T>
        where T : IComparable<T>
    {
        [NonSerialized]
        private T[] heap;
        [NonSerialized]
        private readonly IComparer<T> comparer;
        [NonSerialized]
        private readonly Strategy strategy;

        /// <summary>
        /// Creates and initializes a new instance of <see cref="Heap{T}"/>.
        /// </summary>
        public Heap()
        {
            heap = new T[4];
            comparer = Comparer<T>.Default;
            strategy = Strategy.Min;
        }

        /// <summary>
        /// Creates and initializes a new instance of <see cref="Heap{T}"/>, populating it with the items from the 
        /// <see cref="IEnumerable{T}"/>.
        /// </summary>
        /// <param name="collection">Items to populate <see cref="Heap{T}"/> with.</param>
        public Heap(IEnumerable<T> collection)
            : this()
        {
            CopyCollection(collection);
        }

        /// <summary>
        /// Creates and initializes a new instance of <see cref="Heap{T}"/> using a specified <see cref="Strategy"/>.
        /// </summary>
        /// <param name="strategy">Strategy of Heap.</param>
        public Heap(Strategy strategy)
            : this()
        {
            this.strategy = strategy;
        }

        /// <summary>
        /// Creates and initializes a new instance of <see cref="Heap{T}"/>, populating it with the items from the 
        /// <see cref="IEnumerable{T}"/>, and using a specified <see cref="Strategy"/>.
        /// </summary>
        /// <param name="collection">Items to populate <see cref="Heap{T}"/> with.</param>
        /// <param name="strategy">Strategy of heap.</param>
        public Heap(IEnumerable<T> collection, Strategy strategy)
            : this(strategy)
        {
            CopyCollection(collection);
        }

        /// <summary>
        /// Gets the item at the specified index.
        /// </summary>
        /// <param name="index">Index of item.</param>
        /// <returns>Item at the specified index.</returns>
        public T this[int index]
        {
            get
            {
                Guard.OutOfRange(index < 0 || index > Count - 1, "index", Resources.IndexNotWithinBoundsOfHeap);
                return heap[index];
            }
        }

        /// <summary>
        /// Adds an item to the <see cref="Heap{T}"/>.
        /// </summary>
        /// <remarks>
        /// This method is an O(log n) operation.
        /// </remarks>
        /// <param name="item">Item to add to the heap.</param>
        public override void Add(T item)
        {
            if (Count == heap.Length)
            {
                Array.Resize(ref heap, 2 * heap.Length);
            }

            heap[Count++] = item;
            if (strategy == Strategy.Min)
            {
                MinHeapify();
            }
            else
            {
                MaxHeapify();
            }
        }

        /// <summary>
        /// Clears the <see cref="Heap{T}"/> of its items.
        /// </summary>
        /// <remarks>
        /// Calling this method returns the internal <see cref="Array"/> to it's original capacity of 4.
        /// </remarks>
        public override void Clear()
        {
            Count = 0;
            heap = new T[4];
        }

        /// <summary>
        /// Determines whether or not the <see cref="Heap{T}"/> contains a specific item.
        /// </summary>
        /// <remarks>
        /// This is an O(n) operation where n is the number of items in the <see cref="Heap{T}"/>.
        /// </remarks>
        /// <param name="item">Item to see if the Heap contains.</param>
        /// <returns>True is the item if in the Heap; otherwise false.</returns>
        public override bool Contains(T item)
        {
            return Array.IndexOf(heap, item) < 0 ? false : true;
        }

        /// <summary>
        /// Removes an item from the <see cref="Heap{T}"/>.
        /// </summary>
        /// <remarks>
        /// This method is an O(n) operation.
        /// </remarks>
        /// <param name="item">Item to remove from the Heap.</param>
        /// <returns>True if the item was found and removed; otherwise false.</returns>
        public override bool Remove(T item)
        {
            int index = Array.IndexOf(heap, item);
            if (index < 0)
            {
                return false;
            }

            heap[index] = heap[--Count]; // todo: refactor this!!!
            if (strategy == Strategy.Min)
            {
                while (2 * index + 1 < Count && (Compare.IsGreaterThan(heap[index], heap[2 * index + 1], comparer) ||
                                                 Compare.IsGreaterThan(heap[index], heap[2 * index + 2], comparer)))
                {
                    if (Compare.IsLessThan(heap[2 * index + 1], heap[2 * index + 2], comparer))
                    {
                        Sorting.Exchange(heap, index, 2 * index + 1);
                        index = 2 * index + 1;
                    }
                    else
                    {
                        Sorting.Exchange(heap, index, 2 * index + 2);
                        index = 2 * index + 2;
                    }
                }
            }
            else
            {
                while (2 * index + 1 < Count && (Compare.IsLessThan(heap[index], heap[2 * index + 1], comparer) ||
                                                 Compare.IsLessThan(heap[index], heap[2 * index + 2], comparer)))
                {
                    if (Compare.IsGreaterThan(heap[2 * index + 1], heap[2 * index + 2], comparer))
                    {
                        Sorting.Exchange(heap, index, 2 * index + 1);
                        index = 2 * index + 1;
                    }
                    else
                    {
                        Sorting.Exchange(heap, index, 2 * index + 2);
                        index = 2 * index + 2;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Converts the <see cref="Heap{T}"/> to a one-dimensional array.
        /// </summary>
        /// <remarks>
        /// This method is an O(n) operation where n is the number of items in the <see cref="Heap{T}"/>.
        /// </remarks>
        /// <returns>A one-dimensional <see cref="Array"/> containing the values of the nodes contained in the 
        /// <see cref="Heap{T}"/>.</returns>
        public override T[] ToArray()
        {
            return ToArray(Count, this);
        }

        /// <summary>
        /// Returns an enumerator that iterates through the <see cref="Heap{T}"/> in breadth first order.
        /// </summary>
        /// <remarks>
        /// This method is an O(n) operation where n is the number of items in the <see cref="Heap{T}"/>.
        /// </remarks>
        /// <returns>An <see cref="IEnumerator{T}"/> for the <see cref="Heap{T}"/>.</returns>
        public override IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return heap[i];
            }
        }

        /// <summary>
        /// Min heapifies the <see cref="Heap{T}"/>.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method is an O(log n) operation.
        /// </para>
        /// <para>
        /// The key of the parent is less than or equal to that of its child, this property holds throughout the Heap :. the key at the root of 
        /// the Heap is the smallest key in the Heap.
        /// </para>
        /// </remarks>
        private void MinHeapify()
        {
            int i = Count - 1;
            while (i > 0 && Compare.IsLessThan(heap[i], heap[(i - 1) / 2], comparer))
            {
                Sorting.Exchange(heap, i, (i - 1) / 2);
                i = (i - 1) / 2;
            }
        }

        /// <summary>
        /// Max heapifies the <see cref="Heap{T}"/>.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method is an O(log n) operation.
        /// </para>
        /// <para>
        /// The key of the parent is greater than or equal to that of its child, this property holds throughout the Heap :. the key at the 
        /// root of the Heap is the greatest key in the Heap.
        /// </para>
        /// </remarks>
        private void MaxHeapify()
        {
            int i = Count - 1;
            while (i > 0 && Compare.IsGreaterThan(heap[i], heap[(i - 1) / 2], comparer))
            {
                Sorting.Exchange(heap, i, (i - 1) / 2);
                i = (i - 1) / 2;
            }
        }
    }
}
