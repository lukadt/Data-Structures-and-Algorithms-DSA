﻿// <copyright file="ICommonTreeNode.cs" company="Data Structures and Algorithms">
//   Copyright (C) Data Structures and Algorithms Team.
// </copyright>
// <summary>
//   Interface that nodes of a CommonTree must implement.
// </summary>
namespace Dsa.DataStructures
{
    /// <summary>
    /// Interface for the nodes that are used in a <see cref="CommonTree{TNode,TValue}"/>.
    /// </summary>
    /// <typeparam name="TNode">Type of the node.</typeparam>
    /// <typeparam name="TValue">Type of the value.</typeparam>
    public interface ICommonTreeNode<TNode, TValue>
    {
        /// <summary>
        /// Gets or sets the left node reference.
        /// </summary>
        TNode Left { get; set; }

        /// <summary>
        /// Gets or sets the right node reference.
        /// </summary>
        TNode Right { get; set; }

        /// <summary>
        /// Gets or sets the value of the <see cref="ICommonTreeNode{TNode,TValue}"/>.
        /// </summary>
        TValue Value { get; set; }
    }
}
