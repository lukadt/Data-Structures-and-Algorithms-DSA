// <copyright file="Avl.cs" company="Data Structures and Algorithms">
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
    /// AVL Tree.
    /// </summary>
    /// <remarks>
    /// AVL tree is a tree that is self balancing.
    /// </remarks>
    /// <typeparam name="T">Type of AVL tree.</typeparam>
    public class Avl<T> : BinarySearchTree<T>
        where T : IComparable<T>
    {
        [NonSerialized]
        private AvlTreeNode<T> m_root;
      
        /// <summary>
        /// Gets the root node of the <see cref="Avl{T}"/>.
        /// </summary>
        public new AvlTreeNode<T> Root
        {
            get { return m_root; }
        }
        
        /// <summary>
        /// Retrieves the height of the specified node
        /// </summary>
        /// <param name="node">node to obtain depth </param>
        /// <returns>-1 if node is null otherwise its proper height </returns>
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
        /// Inserts a new node with the specified value at the appropriate location in the <see cref="Avl{T}"/>.
        /// </summary>
        /// <remarks>
        /// This method is an O(log n) operation plus constant time due to rebalancing.
        /// </remarks>
        /// <param name="item">Value to insert.</param>
        public override void Add(T item)
        {
            if (m_root == null)
            {
                m_root = new AvlTreeNode<T>(item);
            }
            else
            {
                m_root = InsertNode(m_root, item);
            }

            Count++;
        }

        /// <summary>
        /// Called by the Add method. Finds the location where to put the node in the <see cref="Avl{T}"/> and if necessary rebalance.
        /// </summary>
        /// <param name="node">Node to start searching from.</param>
        /// <param name="value">Value to insert into the Avl.</param>
        private AvlTreeNode<T> InsertNode(AvlTreeNode<T> node, T value)
        {
            if (Compare.IsLessThan(value, node.Value, m_comparer))
            {
                if (node.Left == null)
                {
                    node.Left = new AvlTreeNode<T>(value);
                }
                else
                {
                    InsertNode(node.Left, value);
                    if ((Height(node.Left) - Height(node.Right)) == 2)
                    {
                        if (Compare.IsLessThan(value, node.Left.Value, m_comparer))
                        {
                            node = SingleLeftRotation(node);
                        }
                        else
                        {
                            node = DoubleLeftRotation(node);
                        }
                    }
                }
            }
            else
            {
                if (node.Right == null)
                {
                    node.Right = new AvlTreeNode<T>(value);
                }
                else
                {
                    InsertNode(node.Right, value);
                    if ((Height(node.Right) - Height(node.Left)) == 2)
                    {
                        if (Compare.IsGreaterThan(value, node.Right.Value, m_comparer))
                        {
                            node = SingleRightRotation(node);
                        }
                        else
                        {
                            node = DoubleRightRotation(node);
                        }
                    }
                }
            }

            node.Height= Math.Max(Height(node.Left), Height(node.Right)) + 1;
            return node;
        }

        /// <summary>
        /// A Double rotation composed of a left rotation and a right rotation
        /// </summary>
        /// <param name="node">the pivoting node involved in rotations</param>
        /// <returns>the balanced tree node </returns>
        private AvlTreeNode<T> DoubleRightRotation(AvlTreeNode<T> node)
        {
            // Double rotation is composed of two rotation one right and one left
            node.Right = SingleLeftRotation(node.Right);
            return SingleRightRotation(node);
        }

        /// <summary>
        /// A single right rotation composed of a right rotation
        /// </summary>
        /// <param name="node">the pivoting node involved in rotations</param>
        /// <returns>the balanced tree node </returns>
        private AvlTreeNode<T> SingleRightRotation(AvlTreeNode<T> node)
        {
            AvlTreeNode<T> node1 = node.Right;
            node.Right = node1.Left;
            node1.Left= node;
            node.Height= Math.Max(Height(node.Left), Height(node.Right)) + 1;
            node1.Height= Math.Max(Height(node1.Right), node.Height) + 1;
            return node1;
        }

        /// <summary>
        /// A Double rotation composed of a right rotation and a left rotation
        /// </summary>
        /// <param name="node">the pivoting node involved in rotations</param>
        /// <returns>the balanced tree node </returns>
        private AvlTreeNode<T> DoubleLeftRotation(AvlTreeNode<T> node)
        {
            //Double rotation is composed of two rotation one right and one left
            node.Left = SingleRightRotation(node.Left);
            return SingleLeftRotation(node);
        }

        /// <summary>
        /// A Single rotation composed of a left rotation and a right rotation
        /// </summary>
        /// <param name="node">the pivoting node involved in rotations</param>
        /// <returns>the balanced tree node </returns>
        private AvlTreeNode<T> SingleLeftRotation(AvlTreeNode<T> node)
        {
            AvlTreeNode<T> node1 = node.Left;
            node.Left = node1.Right;
            node1.Right = node;
            node.Height = Math.Max(Height(node.Left), Height(node.Right)) + 1;
            node1.Height = Math.Max(Height(node1.Left), node.Height) + 1;
            return node1;
        }
    }
}
