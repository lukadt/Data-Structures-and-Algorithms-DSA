// <copyright file="UnorderedSet.cs" company="Data Structures and Algorithms">
//   Copyright (C) Data Structures and Algorithms Team.
// </copyright>
// <summary>
//   A set in the traditional sense where ordering is not required. 
//   Uses a singly linked list.
// </summary>
using System;
using System.Collections.Generic;

namespace Dsa.DataStructures
{
    /// <summary>
    /// Based on a standard mathematical set.
    /// </summary>
    /// <remarks>
    /// In order to check for equality for non-primitve types you must make sure the type implements <see cref="IComparable{T}"/> otherwise
    /// the <see cref="UnorderedSet{T}"/> cannot guarantee the set contains only unique objects.
    /// </remarks>
    /// <typeparam name="T">Type of the <see cref="UnorderedSet{T}"/>.</typeparam>
    public sealed class UnorderedSet<T> : CollectionBase<T>
        where T : IComparable<T>
    {
        private readonly Dictionary<T, T> set;

        /// <summary>
        /// Creates and initializes a new instance of <see cref="UnorderedSet{T}"/>.
        /// </summary>
        public UnorderedSet() 
        {
            set = new Dictionary<T, T>();
        }

        /// <summary>
        /// Creates and initializes a new instance of <see cref="UnorderedSet{T}"/> populating the <see cref="UnorderedSet{T}"/> with
        /// the items withing the provided <see cref="IEnumerable{T}"/>.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Call this constructor if assigning a collection to the <see cref="UnorderedSet{T}"/>.
        /// </para>
        /// <para>
        /// This method is an O(n) operation where n is the number of items in the <see cref="IEnumerable{T}"/>.
        /// </para>
        /// </remarks>
        /// <param name="collection">Items to populate the <see cref="UnorderedSet{T}"/> with.</param>
        public UnorderedSet(IEnumerable<T> collection)
            : this()
        {
            CopyCollection(collection);
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
            if (set.ContainsValue(item))
            {
                return; // item already in set
            }

            set.Add(item, item);
            Count++;
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
            if (set.Remove(item))
            {
                Count--;
            }

            return Count < count ? true : false;
        }

        /// <summary>
        /// Clears all the items from the <see cref="Set{T}"/>.
        /// </summary>
        public override void Clear()
        {
            set.Clear();
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
            return set.ContainsKey(item);
        }

        /// <summary>
        /// Returns an <see cref="IEnumerator{T}"/> to provide a simple traversal through the items in the <see cref="UnorderedSet{T}"/>.
        /// </summary>
        /// <returns>w
        /// An <see cref="IEnumerator{T}"/> to traverse the <see cref="UnorderedSet{T}"/>.
        /// </returns>
        /// <remarks>
        /// This method is an O(n) operation where n is the number of items in the <see cref="UnorderedSet{T}"/>.
        /// </remarks>
        public override IEnumerator<T> GetEnumerator()
        {
            foreach (KeyValuePair<T, T> kvp in set)
            {
                yield return kvp.Value;
            }
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