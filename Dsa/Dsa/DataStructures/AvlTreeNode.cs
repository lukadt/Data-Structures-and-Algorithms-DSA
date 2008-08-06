// <copyright file="AvlTreeNode.cs" company="Data Structures and Algorithms">
//   Copyright (C) Data Structures and Algorithms Team.
// </copyright>
// <summary>
//   Generic implementation of an Avl node.
// </summary>
namespace Dsa.DataStructures
{
    /// <summary>
    /// Node used by <see cref="AvlTree{T}"/>.
    /// </summary>
    /// <typeparam name="T">Type of the node.</typeparam>
    public class AvlTreeNode<T> : BinaryTreeNode<T>
    {
        /// <summary>
        /// Creates and initializes a new instance of <see cref="AvlTreeNode{T}"/>.
        /// </summary>
        /// <param name="value">Value of node.</param>
        public AvlTreeNode(T value)
            : base(value)
        {
            Height = 0;
        }

        /// <summary>
        /// Get or sets the height of the node
        /// </summary>
        public int Height { get; set; }
    }
}
