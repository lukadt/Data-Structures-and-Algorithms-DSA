// <copyright file="BinaryTreeNode.cs" company="Data Structures and Algorithms">
//   Copyright (C) Data Structures and Algorithms Team.
// </copyright>
// <summary>
//   Generic implementation of a BST node.
// </summary>
namespace Dsa.DataStructures
{
    /// <summary>
    /// Node used by <see cref="BinarySearchTree{T}"/>.
    /// </summary>
    /// <typeparam name="T">Type of the node.</typeparam>
    public class BinaryTreeNode<T>
    {
        /// <summary>
        /// Gets or sets the left node reference.
        /// </summary>
        public BinaryTreeNode<T> Left { get; set; }

        /// <summary>
        /// Gets or sets the right node reference.
        /// </summary>
        public BinaryTreeNode<T> Right { get; set; }

        /// <summary>
        /// Gets or sets the value of the node.
        /// </summary>
        public T Value { get; set; }

        /// <summary>
        /// Creates and initializes a new instance of <see cref="BinaryTreeNode{T}"/>.
        /// </summary>
        /// <param name="value">Value of node.</param>
        public BinaryTreeNode(T value)
        {
            Value = value;
        }
    }
}
