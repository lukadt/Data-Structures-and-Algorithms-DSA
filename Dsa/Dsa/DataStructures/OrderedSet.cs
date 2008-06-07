﻿// <copyright file="OrderedSet.cs" company="Data Structures and Algorithms">
//   Copyright (C) Data Structures and Algorithms Team.
// </copyright>
// <summary>
//   Set whose items are ordered. 
//   Uses a binary search tree.
// </summary>
using System;
using System.Collections.Generic;

namespace Dsa.DataStructures
{
    /// <summary>
    /// An ordered set where the items are ordered using a default <see cref="Comparer{T}"/> or a provided <see cref="IComparer{T}"/>.  
    /// </summary>
    /// <remarks>
    /// In order to check for equality for non-primitve types you must make sure the type implements <see cref="IComparable{T}"/> otherwise
    /// the <see cref="OrderedSet{T}"/> cannot guarantee the set contains only unique objects.
    /// </remarks>
    /// <typeparam name="T">Type of OrderedSet.</typeparam>
    public sealed class OrderedSet<T> : Set<T>
        where T : IComparable<T>
    {
        /// <summary>
        /// Creates and initializes a new instance of <see cref="OrderedSet{T}"/>.
        /// </summary>
        public OrderedSet()
            : base(new BinarySearchTree<T>()) 
        {
        }

        /// <summary>
        /// Creates and initializes a new instance of <see cref="OrderedSet{T}"/> populating the <see cref="OrderedSet{T}"/> with
        /// the items withing the provided <see cref="IEnumerable{T}"/>.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Call this constructor if assigning a collection to the <see cref="OrderedSet{T}"/>.
        /// </para>
        /// <para>
        /// This method is an O(n) operation where n is the number of items in the <see cref="IEnumerable{T}"/>.
        /// </para>
        /// </remarks>
        /// <param name="collection">Collection of items to populate the set.</param>
        public OrderedSet(IEnumerable<T> collection)
            : this()
        {
            CopyCollection(collection);
        }

        /// <summary>
        /// Returns an <see cref="IEnumerator{T}"/> to provide a simple traversal through the items in the <see cref="OrderedSet{T}"/>.
        /// </summary>
        /// <returns>An <see cref="IEnumerator{T}"/> to traverse the <see cref="OrderedSet{T}"/>.</returns>
        /// <remarks>
        /// This method is an O(n) operation where n is the number of items in the <see cref="OrderedSet{T}"/>.
        /// </remarks>
        public override IEnumerator<T> GetEnumerator()
        {
            return (Collection as BinarySearchTree<T>).GetInorderEnumerator().GetEnumerator();
        }
    }
}
