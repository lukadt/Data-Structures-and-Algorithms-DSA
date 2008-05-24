// <copyright file="HeapType.cs" company="Data Structures and Algorithms">
//   Copyright (C) Data Structures and Algorithms Team.
// </copyright>
// <summary>
//   Used to describe the strategy of a heap.
// </summary>
namespace Dsa.DataStructures
{
    /// <summary>
    /// Defines the type of the <see cref="Heap{T}"/>.
    /// </summary>
    public enum HeapType
    {
        /// <summary>
        /// Min - each parent's key is less than or equal to that of its children.
        /// </summary>
        Min,

        /// <summary>
        /// Max - each parent's key is greater than or equal to that of its children.
        /// </summary>
        Max
    }
}