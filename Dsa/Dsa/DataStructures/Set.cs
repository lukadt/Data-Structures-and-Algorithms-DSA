using System;
using System.Collections.Generic;
using Dsa.Utility;

namespace Dsa.DataStructures
{
    /// <summary>
    /// Base class for all sets.
    /// </summary>
    /// <typeparam name="T">Type of <see cref="Set{T}"/>.</typeparam>
    public class Set<T> : CollectionBase<T>
    {
        private readonly CollectionBase<T> _collection;
        /// <summary>
        /// Creates and initializes a new instance of <see cref="Set{T}"/>.
        /// </summary>
        /// <param name="collection"></param>
        public Set(CollectionBase<T> collection)
        {
            _collection = collection;
        }

        /// <summary>
        /// Adds an item to the <see cref="Set{T}"/>.
        /// </summary>
        /// <remarks>
        /// This is an O(1) operation if an <see cref="UnorderedSet{T}"/>, for an <see cref="OrderedSet{T}"/> this is an O(log n) operation.
        /// </remarks>
        /// <param name="item">Item to add to the <see cref="Set{T}"/>.</param>
        public override void Add(T item)
        {
            if (_collection.Contains(item))
            {
                return; // item already in set
            }
            _collection.Add(item);
            Count++;
        }

        /// <summary>
        /// Clears all the items from the <see cref="Set{T}"/>.
        /// </summary>
        public override void Clear()
        {
            _collection.Clear();
            Count = 0;
        }

        /// <summary>
        /// Copies the items in an <see cref="IEnumerable{T}"/> to the <see cref="Set{T}"/>.
        /// </summary>
        /// <param name="collection">Items to copy.</param>
        /// <exception cref="ArgumentNullException"><strong>collection</strong> is <strong>null</strong>.</exception>
        protected void CopyCollection(IEnumerable<T> collection)
        {
            Guard.ArgumentNull(collection, "collection");

            foreach (T item in collection)
            {
                Add(item);
            }
        }

        /// <summary>
        /// Determines whether or not an item is contained within the <see cref="UnorderedSet{T}"/>.
        /// </summary>
        /// <remarks>
        /// This is an O(n) operation for an <see cref="UnorderedSet{T}"/>, for a <see cref="OrderedSet{T}"/> this is an O(log n) operation.
        /// </remarks>
        /// <param name="item">Item to search the <see cref="Set{T}"/> for.</param>
        /// <returns>True if the item is contained within the <see cref="Set{T}"/>; otherwise false.</returns>
        public override bool Contains(T item)
        {
            return _collection.Contains(item);
        }

        /// <summary>
        /// Removes an item from the <see cref="Set{T}"/>.
        /// </summary>
        /// <remarks>
        /// This is an O(n) operation for an <see cref="UnorderedSet{T}"/>, for a <see cref="OrderedSet{T}"/> this is an O(log n) operation.
        /// </remarks>
        /// <param name="item">Item to remove from the <see cref="Set{T}"/>.</param>
        /// <returns>True if the item was removed; false otherwise.</returns>
        public override bool Remove(T item)
        {
            int count = Count;
            if (_collection.Remove(item))
            {
                Count--;
            }
            return Count < count ? true : false;
        }

        /// <summary>
        /// Gets the collection being used for the set implementation.
        /// </summary>
        /// <remarks>
        /// For an <see cref="UnorderedSet{T}"/> this is a <see cref="SinglyLinkedList{T}"/>, an <see cref="OrderedSet{T}"/> uses 
        /// a <see cref="BinarySearchTree{T}"/>.
        /// </remarks>
        protected CollectionBase<T> Collection
        {
            get { return _collection; }
        }

        /// <summary>
        /// Returns the items in the <see cref="Set{T}"/> as a one-dimensional <see cref="Array"/>.
        /// </summary>
        /// <remarks>
        /// This is an O(n) operation where n is the number of items in the <see cref="Set{T}"/>.
        /// </remarks>
        /// <returns>A one dimensional <see cref="Array"/> populated with the items from the <see cref="Set{T}"/>.</returns>
        public override T[] ToArray()
        {
            return ToArray(Count, this);
        }  
    }
}
