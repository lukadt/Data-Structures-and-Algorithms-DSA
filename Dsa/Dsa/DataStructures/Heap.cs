using System;
using System.Collections.Generic;
using Dsa.Utility;

namespace Dsa.DataStructures
{

    /// <summary>
    /// Heap data structure.
    /// </summary>
    /// <typeparam name="T">Type of heap.</typeparam>
    public class Heap<T> : CollectionBase<T>
    {

        private T[] _heap;
        private int _index;
        private IComparer<T> _comparer;

        /// <summary>
        /// Initializes a new instance of <see cref="Heap{T}"/>.
        /// </summary>
        public Heap()
        {
            _heap = new T[4];
            _comparer = Comparer<T>.Default;
        }

        /// <summary>
        /// Adds an item to the <see cref="Heap{T}"/>.
        /// </summary>
        /// <param name="item">Item to add to the heap.</param>
        public override void Add(T item)
        {
            if (_index == _heap.Length)
            {
                Array.Resize(ref _heap, 2 * _heap.Length);
            }
            _heap[_index++] = item;
            Count++;
            MaxHeapify();
        }

        /// <summary>
        /// Clears the <see cref="Heap{T}"/> of its items.
        /// </summary>
        public override void Clear()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Determines whether or not the <see cref="Heap{T}"/> contains a specific item.
        /// </summary>
        /// <param name="item">Item to see if the Heap contains.</param>
        /// <returns>True is the item is in the Heap; otherwise false.</returns>
        public override bool Contains(T item)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Removes an item from the <see cref="Heap{T}"/>.
        /// </summary>
        /// <param name="item">Item to remove from the Heap.</param>
        /// <returns>True if the item was found and removed; otherwise false.</returns>
        public override bool Remove(T item)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Converts the <see cref="Heap{T}"/> to a one-dimension array.
        /// </summary>
        /// <returns>Array populated with the items from the Heap.</returns>
        public override T[] ToArray()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Returns an enumerator that iterates through the <see cref="Heap{T}"/> in breadth first order.
        /// </summary>
        /// <returns>An <see cref="IEnumerator{T}"/> for the <see cref="Heap{T}"/>.</returns>
        public override IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < _index; i++)
            {
                yield return _heap[i];
            }
        }

        /// <summary>
        /// Max heapifies the <see cref="Heap{T}"/>.
        /// </summary>
        /// <remarks>
        /// The key of the parent is greater than or equal to that of its child, this property holds
        /// throughout the Heap :. the key at the root of the Heap is the greatest key in the Heap.
        /// </remarks>
        private void MaxHeapify()
        {
            int i = _index - 1;
            int parent = (i - 1) / 2;
            while (i > 0 && Compare.IsGreaterThan(_heap[i], _heap[parent], _comparer))
            {
                T temp = _heap[i];
                _heap[i] = _heap[parent];
                _heap[parent] = temp;
                i = parent;
            }
        }
    }
}
