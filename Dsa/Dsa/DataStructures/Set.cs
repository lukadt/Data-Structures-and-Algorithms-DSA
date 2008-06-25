// <copyright file="Set.cs" company="Data Structures and Algorithms">
//   Copyright (C) Data Structures and Algorithms Team.
// </copyright>
// <summary>
//   Base class of all set data structures.
// </summary>
using System;

namespace Dsa.DataStructures
{
    /// <summary>
    /// Base class for all sets.
    /// </summary>
    /// <typeparam name="T">Type of <see cref="Set{T}"/>.</typeparam>
    public class Set<T> : CollectionBase<T>
    {
        private readonly CollectionBase<T> collection;

        /// <summary>
        /// Creates and initializes a new instance of <see cref="Set{T}"/>.
        /// </summary>
        /// <param name="collection">Collection to use for the set.</param>
        protected Set(CollectionBase<T> collection)
        {
            this.collection = collection;
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
            get { return collection; }
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
            if (collection.Contains(item))
            {
                return; // item already in set
            }

            collection.Add(item);
            Count++;
        }

        /// <summary>
        /// Clears all the items from the <see cref="Set{T}"/>.
        /// </summary>
        public override void Clear()
        {
            collection.Clear();
            Count = 0;
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
            return collection.Contains(item);
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
            if (collection.Remove(item))
            {
                Count--;
            }

            return Count < count ? true : false;
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
