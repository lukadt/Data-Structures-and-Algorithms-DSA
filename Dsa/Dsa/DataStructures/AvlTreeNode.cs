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
        /// Initializes a new instance of the <see cref="AvlTreeNode{T}"/> class.
        /// </summary>
        /// <param name="value">Value of node.</param>
        public AvlTreeNode(T value)
            : base(value) { }

        /// <summary>
        /// Gets the height of the node.
        /// </summary>
        public int Height { get; internal set; }
    }
}
