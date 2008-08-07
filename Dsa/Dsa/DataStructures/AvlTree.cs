// <copyright file="Avl.cs" company="Data Structures and Algorithms">
//   Copyright (C) Data Structures and Algorithms Team.
// </copyright>
// <summary>
//   Generic implementation of an AVL tree.
// </summary>
using System;
using System.Collections.Generic;
using Dsa.Utility;
using System.Diagnostics;

namespace Dsa.DataStructures
{
    /// <summary>
    /// AVL Tree.
    /// </summary>
    /// <remarks>
    /// AVL tree is a tree that is self balancing.
    /// </remarks>
    /// <typeparam name="T">Type of AVL tree.</typeparam>
    public class AvlTree<T> : BinarySearchTree<T>
        where T : IComparable<T>
    {
        /// <summary>
        /// Creates and initializes a new instance of <see cref="AvlTree{T}"/>.
        /// </summary>
        public AvlTree()
            : base() { }

        /// <summary>
        /// Creates and initializes a new instance of <see cref="AvlTree{T}"/> , populating it with the items from the
        /// <see cref="IEnumerable{T}"/>.
        /// </summary>
        /// <param name="collection">Items to populate <see cref="AvlTree{T}"/>.</param>
        public AvlTree(IEnumerable<T> collection)
            : base(collection) { }

        /// <summary>
        /// Retrieves the height of the specified node
        /// </summary>
        /// <param name="node">Node to obtain depth </param>
        /// <returns>-1 if node is null otherwise its proper height.</returns>
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
        /// Inserts a new node with the specified value at the appropriate location in the <see cref="AvlTree{T}"/>.
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
        /// Called by the Add method. Finds the location where to put the node in the <see cref="AvlTree{T}"/> and if necessary rebalance.
        /// </summary>
        /// <param name="node">Node to start searching from.</param>
        /// <param name="value">Value to insert into the Avl.</param>
        private AvlTreeNode<T> InsertNode(BinaryTreeNode<T> node, T value)
        {
            AvlTreeNode<T> left = node.Left as AvlTreeNode<T>;
            AvlTreeNode<T> right = node.Right as AvlTreeNode<T>;
            AvlTreeNode<T> avlNode = node as AvlTreeNode<T>;

            Debug.Assert(left != null, "Left is null in InsertNode");
            Debug.Assert(right != null, "Right is null in InsertNode.");
            Debug.Assert(avlNode != null, "avlNode is null in InsertNode.");

            if (Compare.IsLessThan(value, avlNode.Value, m_comparer))
            {
                if (avlNode.Left == null)
                {
                    avlNode.Left = new AvlTreeNode<T>(value);
                }
                else
                {
                    InsertNode(avlNode.Left, value);
                    if ((Height(left) - Height(right)) == 2)
                    {


                        if (Compare.IsLessThan(value, avlNode.Left.Value, m_comparer))
                        {
                            avlNode = SingleLeftRotation(avlNode);
                        }
                        else
                        {
                            avlNode = DoubleLeftRotation(avlNode);
                        }
                    }
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
                    if ((Height(right) - Height(left)) == 2)
                    {
                        if (Compare.IsGreaterThan(value, avlNode.Right.Value, m_comparer))
                        {
                            avlNode = SingleRightRotation(avlNode as AvlTreeNode<T>);
                        }
                        else
                        {
                            avlNode = DoubleRightRotation(avlNode as AvlTreeNode<T>);
                        }
                    }
                }
            }

            avlNode.Height = Math.Max(Height(avlNode.Left as AvlTreeNode<T>), Height(avlNode.Right as AvlTreeNode<T>)) + 1;
            return avlNode;
        }

        /// <summary>
        /// A Double rotation composed of a left rotation and a right rotation
        /// </summary>
        /// <param name="node">the pivoting node involved in rotations</param>
        /// <returns>the balanced tree node </returns>
        private AvlTreeNode<T> DoubleRightRotation(AvlTreeNode<T> node)
        {
            // Double rotation is composed of two rotation one right and one left
            node.Right = SingleLeftRotation(node.Right as AvlTreeNode<T>);
            return SingleRightRotation(node);
        }

        /// <summary>
        /// A single right rotation composed of a right rotation
        /// </summary>
        /// <param name="node">the pivoting node involved in rotations</param>
        /// <returns>the balanced tree node </returns>
        private AvlTreeNode<T> SingleRightRotation(AvlTreeNode<T> node)
        {
            AvlTreeNode<T> node1 = node.Right as AvlTreeNode<T>;
            Debug.Assert(node1 != null, "node1 is null");

            node.Right = node1.Left;
            node1.Left = node;
            node.Height = Math.Max(Height(node.Left as AvlTreeNode<T>), Height(node.Right as AvlTreeNode<T>)) + 1;
            node1.Height = Math.Max(Height(node1.Right as AvlTreeNode<T>), node.Height) + 1;
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
            node.Left = SingleRightRotation(node.Left as AvlTreeNode<T>);
            return SingleLeftRotation(node);
        }

        /// <summary>
        /// A Single rotation composed of a left rotation and a right rotation
        /// </summary>
        /// <param name="node">the pivoting node involved in rotations</param>
        /// <returns>the balanced tree node </returns>
        private AvlTreeNode<T> SingleLeftRotation(AvlTreeNode<T> node)
        {
            AvlTreeNode<T> node1 = node.Left as AvlTreeNode<T>;
            node.Left = node1.Right;
            node1.Right = node;
            node.Height = Math.Max(Height(node.Left as AvlTreeNode<T>), Height(node.Right as AvlTreeNode<T>)) + 1;
            node1.Height = Math.Max(Height(node1.Left as AvlTreeNode<T>), node.Height) + 1;
            return node1;
        }
    }
}