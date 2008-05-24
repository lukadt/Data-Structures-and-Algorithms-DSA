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
    public class UnorderedSet<T> : Set<T>
    {
        /// <summary>
        /// Creates and initializes a new instance of <see cref="UnorderedSet{T}"/>.
        /// </summary>
        public UnorderedSet()
            : base(new SinglyLinkedList<T>()) 
        { 
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
        /// Returns an <see cref="IEnumerator{T}"/> to provide a simple traversal through the items in the <see cref="UnorderedSet{T}"/>.
        /// </summary>
        /// <returns>
        /// An <see cref="IEnumerator{T}"/> to traverse the <see cref="UnorderedSet{T}"/>.
        /// </returns>
        /// <remarks>
        /// This method is an O(n) operation where n is the number of items in the <see cref="UnorderedSet{T}"/>.
        /// </remarks>
        public override IEnumerator<T> GetEnumerator()
        {
            return Collection.GetEnumerator();
        }
    }
}