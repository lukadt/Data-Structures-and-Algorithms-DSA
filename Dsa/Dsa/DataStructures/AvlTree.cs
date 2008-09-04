﻿// <copyright file="AvlTree.cs" company="Data Structures and Algorithms">
//   Copyright (C) Data Structures and Algorithms Team.
// </copyright>
// <summary>
//   Generic implementation of an AVL tree.
// </summary>
using System;
using System.Collections.Generic;
using Dsa.Utility;

namespace Dsa.DataStructures
{
    
    /// <summary>
    /// AVL balanced tree.
    /// </summary>
    /// <remarks>
    /// AVL tree is a tree that is self balancing.
    /// </remarks>
    /// <typeparam name="T">Concrete type of AVL Tree</typeparam>
    public class AvlTree<T> : CommonTree<AvlTreeNode<T>,T>
        where T : IComparable<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AvlTree{T}"/> class.
        /// </summary>
        public AvlTree()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AvlTree{T}"/> class, populating it with the items from the
        /// <see cref="IEnumerable{T}"/>.
        /// </summary>
        /// <param name="collection">Items to populate <see cref="AvlTree{T}"/>.</param>
        public AvlTree(IEnumerable<T> collection)
            : this()
        {
            CopyCollection(collection);
        }

        /// <summary>
        /// Retrieves the height of the specified node.
        /// </summary>
        /// <param name="node">Node to obtain depth.</param>
        /// <returns>If the node is null -1; otherwise its proper height.</returns>
        public int Height(AvlTreeNode<T> node)
        {
            if (node == null)
            {
                return -1;
            }
            else
            {
                return node.Height;
            }
        }

        /// <summary>
        /// Get the balance factor for the node
        /// Balance factor is defined as the height difference 
        /// between left and right subtree if subtrees exist otherwise as 0
        /// </summary>
        public int GetBalanceFactor(AvlTreeNode<T> node)
        {
            if (node.Left == null && node.Right == null)
            {
                return 0;
            }
            else
            {
                return Height(node.Left) - Height(node.Right);
            }
        }

        /// <summary>
        /// Inserts a new node with the specified value at the appropriate location in the <see cref="AvlTree{T}"/>.
        /// </summary>
        /// <remarks>
        /// This method is an O(log n) operation plus constant time due to rebalancing.
        /// </remarks>
        /// <param name="item">Value to insert.</param>
        public override void Add(T item)
        {
            if (Root == null)
            {
                Root = new AvlTreeNode<T>(item);
            }
            else
            {
                Root = InsertNode(Root, item);
            }

            Count++;
        }

        /// <summary>
        /// Called by the Add method. Finds the location where to put the node in the <see cref="AvlTree{T}"/> and if 
        /// necessary rebalance.
        /// </summary>
        /// <param name="avlNode">Node to start searching from.</param>
        /// <param name="value">Value to insert into the Avl.</param>
        /// <returns>Location where node was inserted into the tree.</returns>
        private AvlTreeNode<T> InsertNode(AvlTreeNode<T> avlNode, T value)
        {

            if (Compare.IsLessThan(value, avlNode.Value, Comparer))
            {
                if (avlNode.Left == null)
                {
                    avlNode.Left = new AvlTreeNode<T>(value);
                }
                else
                {
                    InsertNode(avlNode.Left, value);
                    avlNode = Balance(avlNode);
                }
            }
            else
            {
                if (avlNode.Right == null)
                {
                    avlNode.Right = new AvlTreeNode<T>(value);
                }
                else
                {
                    InsertNode(avlNode.Right, value);
                    avlNode = Balance(avlNode);
                }
            }

            avlNode.Height = Math.Max(Height(avlNode.Left), Height(avlNode.Right)) + 1;
            return avlNode;
        }

        /// <summary>
        /// Function that balance the tree after having updated its height
        /// </summary>
        /// <param name="node">the root of the tree to balance </param>
        /// <returns>the root node of the balanced subtree</returns>
        private AvlTreeNode<T> Balance(AvlTreeNode<T> node)
        {

            if (node.Left == null && node.Right == null)
            {
                node.Height = -1;
            }
            else
            {
                node.Height = Math.Max(Height(node.Left), Height(node.Right)) + 1;
            }
            if (GetBalanceFactor(node) > 1)
            {
                if (GetBalanceFactor(node.Left) > 0)
                {
                    node = SingleRightRotation(node);
                }
                else
                {
                    node = DoubleLeftRightRotation(node);
                }
            }
            else if (GetBalanceFactor(node) < -1)
            {
                if (GetBalanceFactor(node.Right) < 0)
                {
                    node = SingleLeftRotation(node);
                }
                else
                {
                    node = DoubleRightLeftRotation(node);
                }
            }
            return node;
        }

        /// <summary>
        /// A Double rotation composed of a left rotation and a right rotation.
        /// </summary>
        /// <param name="node">The pivoting node involved in rotations.</param>
        /// <returns>The balanced tree node.</returns>
        private AvlTreeNode<T> DoubleLeftRightRotation(AvlTreeNode<T> node)
        {
            // Double rotation is composed of two rotation one right and one left
            node.Left = SingleLeftRotation(node.Left);
            node = SingleRightRotation(node);
            return node;
        }

        /// <summary>
        /// A single right rotation composed of a right rotation.
        /// </summary>
        /// <param name="node">The pivoting node involved in rotations.</param>
        /// <returns>The balanced tree node.</returns>
        private AvlTreeNode<T> SingleLeftRotation(AvlTreeNode<T> node)
        {
            AvlTreeNode<T> node1 = node.Right;
            node.Right = node1.Left;
            node1.Left = node;
            node.Height = Math.Max(Height(node.Left), Height(node.Right)) + 1;
            node1.Height = Math.Max(Height(node1.Right), Height(node)) + 1;
            return node1;
        }

        /// <summary>
        /// A Double rotation composed of a right rotation and a left rotation.
        /// </summary>
        /// <param name="node">The pivoting node involved in rotations.</param>
        /// <returns>The balanced tree node.</returns>
        private AvlTreeNode<T> DoubleRightLeftRotation(AvlTreeNode<T> node)
        {
            // Double rotation is composed of two rotation one right and one left
            node.Right = SingleRightRotation(node.Right);
            node = SingleLeftRotation(node);
            return node;
        }

        /// <summary>
        /// A Single rotation composed of a left rotation and a right rotation.
        /// </summary>
        /// <param name="node">The pivoting node involved in rotations.</param>
        /// <returns>The balanced tree node.</returns>
        private AvlTreeNode<T> SingleRightRotation(AvlTreeNode<T> node)
        {
            AvlTreeNode<T> node1 = node.Left;
            node.Left = node1.Right;
            node1.Right = node;
            node.Height = Math.Max(Height(node.Left), Height(node.Right)) + 1;
            node1.Height = Math.Max(Height(node1.Left), Height(node)) + 1;
            return node1;
        }

        /// <summary>
        /// Removes a node with the specified value from the <see cref="AvlTree{T}"/>.
        /// </summary>
        /// <remarks>
        /// This method is an O(log n) operation plus if necessary a rebalancing.
        /// </remarks>
        /// <param name="item">Item to remove from the the <see cref="AvlTree{T}"/>.</param>
        /// <returns>True if the item was removed; otherwise false.</returns>
        public override bool Remove(T item)
        {
            throw new NotImplementedException();
        }
    }
}