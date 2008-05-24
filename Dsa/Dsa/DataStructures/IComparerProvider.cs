// <copyright file="IComparerProvider.cs" company="Data Structures and Algorithms">
//   Copyright (C) Data Structures and Algorithms Team.
// </copyright>
// <summary>
//   Simple interface that essentially marks a collection as having a behaviour by which
//   the user can get at the comparer being used by the collection.
//   By all occassions if the user doesn't provider a comparer then all DSA collections will
//   use a default comparer for that type if one exists.
// </summary>
using System.Collections.Generic;

namespace Dsa.DataStructures
{
    /// <summary>
    /// Defines a mechanism for retrieving a <see cref="IComparer{T}"/> being used by a DSA collection.
    /// </summary>
    /// <typeparam name="T">Type of <see cref="IComparer{T}"/>.</typeparam>
    public interface IComparerProvider<T>
    {
        /// <summary>
        /// Gets the <see cref="IComparer{T}"/> being used.
        /// </summary>
        IComparer<T> Comparer 
        { 
            get; 
        }
    }
}