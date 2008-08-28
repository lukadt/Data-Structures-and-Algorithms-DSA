// <copyright file="BinarySearchTree.cs" company="Data Structures and Algorithms">
//   Copyright (C) Data Structures and Algorithms Team.
// </copyright>
// <summary>
//   Generic implementation of a BST. The BST is NOT balanced - see the AVL tree for that.
// </summary>
using System;
using System.Collections.Generic;
using Dsa.Properties;
using Dsa.Utility;

namespace Dsa.DataStructures
{
    /// <summary>
    /// A binary search tree (BST).
    /// </summary>
    /// <typeparam name="T">Type of <see cref="BinarySearchTree{T}"/>.</typeparam>
    [Serializable]
    public class BinarySearchTree<T> : CollectionBase<T>
        where T : IComparable<T>
    {
        /// <summary>
        /// Used as internal comparer.
        /// </summary>
        [NonSerialized] 
        private IComparer<T> m_comparer;

        /// <summary>
        /// Root node.
        /// </summary>
        [NonSerialized]
        private BinaryTreeNode<T> m_root;

        /// <summary>
        /// Initializes a new instance of the <see cref="BinarySearchTree{T}"/> class.
        /// </summary>
        public BinarySearchTree()
        {
            m_comparer = Comparer<T>.Default;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BinarySearchTree{T}"/> class, populating it with the items from the
        /// <see cref="IEnumerable{T}"/>.
        /// </summary>
        /// <param name="collection">Items to populate <see cref="BinarySearchTree{T}"/>.</param>
        public BinarySearchTree(IEnumerable<T> collection)
            : this()
        {
            CopyCollection(collection);
        }

        /// <summary>
        /// Gets the root node of the <see cref="BinarySearchTree{T}"/>.
        /// </summary>
        public BinaryTreeNode<T> Root
        {
            get { return m_root; }
            protected set { m_root = value; }
        }

        /// <summary>
        /// Gets <see cref="IComparer{T}"/> to use for comparisons.
        /// </summary>
        protected IComparer<T> Comparer
        {
            get { return m_comparer; }
        }

        /// <summary>
        /// Finds a node in the <see cref="BinarySearchTree{T}"/> with the specified value.
        /// </summary>
        /// <remarks>
        /// This method is an O(log n) operation.
        /// </remarks>
        /// <param name="value">Value to find.</param>
        /// <returns>A <see cref="BinaryTreeNode{T}"/> if the node was found with the value provided; otherwise null.</returns>
        public BinaryTreeNode<T> FindNode(T value)
        {
            return FindNode(value, m_root);
        }

        /// <summary>
        /// Finds the parent node of a node with the specified value.
        /// </summary>
        /// <param name="value">Value of node to find parent of.</param>
        /// <returns><see cref="BinaryTreeNode{T}"/> if the parent was found, otherwise null.</returns>
        public BinaryTreeNode<T> FindParent(T value)
        {
            if (m_root == null)
            {
                return null;
            }

            return Compare.AreEqual(value, m_root.Value, m_comparer) ? null : FindParent(value, m_root);
        }

        /// <summary>
        /// Traverses the <see cref="BinarySearchTree{T}"/> in breadth first order.
        /// </summary>
        /// <remarks>
        /// This method is an O(n) operation where n is the number of nodes in the <see cref="BinarySearchTree{T}"/> .
        /// </remarks>
        /// <returns>An <see cref="IEnumerator{T}" /> that can be used to iterate through the <see cref="BinarySearchTree{T}"/>.</returns>
        public IEnumerable<T> GetBreadthFirstEnumerator()
        {
            return BreadthFirstTraversal(m_root);
        }

        /// <summary>
        /// Traverses the <see cref="BinarySearchTree{T}"/> in in order traversal.
        /// </summary>
        /// <remarks>
        /// This method is an O(n) operation where n is the number of nodes in the <see cref="BinarySearchTree{T}"/>.
        /// </remarks>
        /// <returns>An <see cref="IEnumerator{T}" /> that can be used to iterate through the <see cref="BinarySearchTree{T}"/>.</returns>
        public IEnumerable<T> GetInorderEnumerator()
        {
            List<T> arrayListCollection = new List<T>();
            return InorderTraversal(m_root, arrayListCollection);
        }

        /// <summary>
        /// Finds smallest value in the <see cref="BinarySearchTree{T}"/>.
        /// </summary>
        /// <remarks>
        /// This method is an O(log n) operation.
        /// </remarks>
        /// <returns>Smallest value in the <see cref="BinarySearchTree{T}"/>.</returns>
        /// <exception cref="InvalidOperationException">The <see cref="BinarySearchTree{T}"/> contains <strong>0</strong> items.</exception>
        public T FindMin()
        {
            Guard.InvalidOperation(m_root == null, Resources.BinarySearchTreeEmpty);

            return FindMin(m_root);
        }

        /// <summary>
        /// Traverses the <see cref="BinarySearchTree{T}"/> in postorder traversal.
        /// </summary>
        /// <remarks>
        /// This method is an O(n) operation where n is the number of nodes in the <see cref="BinarySearchTree{T}"/> .
        /// </remarks>
        /// <returns>An <see cref="IEnumerator{T}" /> that can be used to iterate through the <see cref="BinarySearchTree{T}"/>.</returns>
        public IEnumerable<T> GetPostorderEnumerator()
        {
            List<T> arrayListCollection = new List<T>();
            return PostorderTraversal(m_root, arrayListCollection);
        }

        /// <summary>
        /// Finds the largest value in the <see cref="BinarySearchTree{T}"/>.
        /// </summary>
        /// <remarks>
        /// This method is an O(log n) operation.
        /// </remarks>
        /// <returns>Largest value in the <see cref="BinarySearchTree{T}"/>.</returns>
        /// <exception cref="InvalidOperationException">The <see cref="BinarySearchTree{T}"/> contains <strong>0</strong> items.</exception>
        public T FindMax()
        {
            Guard.InvalidOperation(m_root == null, Resources.BinarySearchTreeEmpty);

            return FindMax(m_root);
        }

        /// <summary>
        /// Copies all the <see cref="BinarySearchTree{T}"/> items to a compatible one-dimensional <see cref="Array"/>.
        /// </summary>
        /// <param name="array">A one-dimensional <see cref="Array"/> to copy the <see cref="BinarySearchTree{T}"/> items to.</param>
        public void CopyTo(T[] array)
        {
            Array.Copy(ToArray(), array, Count);
        }

        /// <summary>
        /// Returns the items in the <see cref="BinarySearchTree{T}"/> as an <see cref="Array"/> using <see cref="BinarySearchTree{T}.GetBreadthFirstEnumerator"/> 
        /// traversal.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method is an O(n) operation where n is the number of nodes in the <see cref="BinarySearchTree{T}"/>.
        /// </para>
        /// </remarks>
        /// <returns>A one-dimensional <see cref="Array"/> containing the items of the <see cref="BinarySearchTree{T}"/>.</returns>
        public override T[] ToArray()
        {
            return ToArray(Count, GetBreadthFirstEnumerator());
        }

        /// <summary>
        /// Inserts a new node with the specified value at the appropriate location in the <see cref="BinarySearchTree{T}"/>.
        /// </summary>
        /// <remarks>
        /// This method is an O(log n) operation.
        /// </remarks>
        /// <param name="item">Value to insert.</param>
        public override void Add(T item)
        {
            if (m_root == null)
            {
                m_root = new BinaryTreeNode<T>(item);
            }
            else
            {
                InsertNode(m_root, item);
            }

            Count++;
        }

        /// <summary>
        /// Clears all items from the <see cref="BinarySearchTree{T}"/>.
        /// </summary>
        /// <remarks>
        /// This method is an O(1) operation.
        /// </remarks>
        public override void Clear()
        {
            m_root = null;
            Count = 0;
        }

        /// <summary>
        /// Determines whether an item is contained within the <see cref="BinarySearchTree{T}"/>.
        /// </summary>
        /// <remarks>
        /// This method is an O(log n) operation.
        /// </remarks>
        /// <param name="item">Item to search the <see cref="BinarySearchTree{T}"/> for.</param>
        /// <returns>True if the item is contained within the <see cref="BinarySearchTree{T}"/>; otherwise false.</returns>
        public override bool Contains(T item)
        {
            return Contains(m_root, item);
        }

        /// <summary>
        /// Removes a node with the specified value from the <see cref="BinarySearchTree{T}"/>.
        /// </summary>
        /// <remarks>
        /// This method is an O(log n) operation.
        /// </remarks>
        /// <param name="item">Item to remove from the the <see cref="BinarySearchTree{T}"/>.</param>
        /// <returns>True if the item was removed; otherwise false.</returns>
        public override bool Remove(T item)
        {
            BinaryTreeNode<T> nodeToRemove = FindNode(item);
            if (nodeToRemove == null)
            {
                return false;
            }

            BinaryTreeNode<T> parent = FindParent(item);
            if (Count == 1)
            {
                m_root = null;
            }
            else if (nodeToRemove.Left == null && nodeToRemove.Right == null)
            {
                // nodeToRemove is a leaf
                if (Compare.IsLessThan(nodeToRemove.Value, parent.Value, m_comparer))
                {
                    parent.Left = null;
                }
                else
                {
                    parent.Right = null;
                }
            }
            else if (nodeToRemove.Left == null && nodeToRemove.Right != null)
            {
                // nodeToRemove has only a right subtree
                if (Compare.IsLessThan(nodeToRemove.Value, parent.Value, m_comparer))
                {
                    parent.Left = nodeToRemove.Right;
                }
                else
                {
                    parent.Right = nodeToRemove.Right;
                }
            }
            else if (nodeToRemove.Left != null && nodeToRemove.Right == null)
            {
                // nodeToRemove has only a left subtree
                if (Compare.IsLessThan(nodeToRemove.Value, parent.Value, m_comparer))
                {
                    parent.Left = nodeToRemove.Left;
                }
                else
                {
                    parent.Right = nodeToRemove.Left;
                }
            }
            else
            {
                // nodeToRemove has both a left and right subtree
                BinaryTreeNode<T> largestValue = nodeToRemove.Left;

                // find the largest value in the left subtree of nodeToRemove
                while (largestValue.Right != null)
                {
                    largestValue = largestValue.Right;
                }

                // find the parent of the largest value in the left subtree of nodeToDelete and sets its right property to null.
                FindParent(largestValue.Value).Right = null;

                // set value of nodeToRemove to the value of largestValue
                nodeToRemove.Value = largestValue.Value;
            }

            Count--;
            return true;
        }

        /// <summary>
        /// An <see cref="IEnumerator{T}"/> that iterates through the <see cref="BinarySearchTree{T}"/>.  By default Preorder traversal of the tree.
        /// </summary>
        /// <remarks>
        /// This method is an O(n) operation.
        /// </remarks>
        /// <returns>An <see cref="IEnumerator{T}" /> that can be used to iterate through the <see cref="BinarySearchTree{T}"/>.</returns>
        public override IEnumerator<T> GetEnumerator()
        {
            List<T> arrayListCollection = new List<T>();
            return PreorderTraveral(m_root, arrayListCollection).GetEnumerator();
        }

        /// <summary>
        /// Find the largest value in the bst.
        /// </summary>
        /// <param name="root">Root node of the bst.</param>
        /// <returns>Largest value in the bst.</returns>
        private static T FindMax(BinaryTreeNode<T> root)
        {
            return root.Right == null ? root.Value : FindMax(root.Right);
        }

        /// <summary>
        /// Traverse the tree in breadth first order, i.e. each node is visited on the same depth to depth n where n is the depth of the tree.
        /// </summary>
        /// <param name="root">The root node of the BinarySearchTree.</param>
        /// <returns>ArrayList populated with the items from the traversal.</returns>
        private static List<T> BreadthFirstTraversal(BinaryTreeNode<T> root)
        {
            Queue<BinaryTreeNode<T>> unvisited = new Queue<BinaryTreeNode<T>>();
            List<T> visited = new List<T>();

            while (root != null)
            {
                visited.Add(root.Value);
                if (root.Left != null)
                {
                    unvisited.Enqueue(root.Left);
                }

                if (root.Right != null)
                {
                    unvisited.Enqueue(root.Right);
                }

                root = unvisited.Count > 0 ? unvisited.Dequeue() : null;
            }

            return visited;
        }

        /// <summary>
        /// Traverses the tree in in order, i.e. returning the values of the nodes when a node is passed underneath.
        /// </summary>
        /// <param name="root">The root node of the BinarySearchTree.</param>
        /// <param name="arrayList">ArrayList to store the traversed node values.</param>
        /// <returns>ArrayList populated with the items from the traversal.</returns>
        private static List<T> InorderTraversal(BinaryTreeNode<T> root, List<T> arrayList)
        {
            if (root != null)
            {
                InorderTraversal(root.Left, arrayList);
                arrayList.Add(root.Value);
                InorderTraversal(root.Right, arrayList);
            }

            return arrayList;
        }

        /// <summary>
        /// Finds the smallest value in the bst.
        /// </summary>
        /// <param name="root">Root node of the bst.</param>
        /// <returns>Smallest value in the bst.</returns>
        private static T FindMin(BinaryTreeNode<T> root)
        {
            return root.Left == null ? root.Value : FindMin(root.Left);
        }

        /// <summary>
        /// Traverses the tree in postorder, i.e. returning the values of the nodes passed on the right.
        /// </summary>
        /// <param name="root">The root node of the BinarySearchTree.</param>
        /// <param name="arrayList">ArrayList to store the traversed node values.</param>
        /// <returns>ArrayList populated with the items from the traversal.</returns>
        private static List<T> PostorderTraversal(BinaryTreeNode<T> root, List<T> arrayList)
        {
            if (root != null)
            {
                PostorderTraversal(root.Left, arrayList);
                PostorderTraversal(root.Right, arrayList);
                arrayList.Add(root.Value);
            }

            return arrayList;
        }

        /// <summary>
        /// Traverses the tree in preorder, i.e. returning the values of the nodes passed on the left.
        /// </summary>
        /// <param name="root">The root node of the BinarySearchTree.</param>
        /// <param name="arrayList">A ArrayList to store the traversed node values.</param>
        /// <returns>ArrayList populated with the items from the traversal.</returns>
        private static List<T> PreorderTraveral(BinaryTreeNode<T> root, List<T> arrayList)
        {
            if (root != null)
            {
                arrayList.Add(root.Value);
                PreorderTraveral(root.Left, arrayList);
                PreorderTraveral(root.Right, arrayList);
            }

            return arrayList;
        }

        /// <summary>
        /// Finds a node in the <see cref="BinarySearchTree{T}"/> with the specified value.
        /// </summary>
        /// <param name="value">Value to find.</param>
        /// <param name="root">Node to start search from.</param>
        /// <returns>A <see cref="BinaryTreeNode{T}"/> if the node was found with the value provided; otherwise null.</returns>
        private BinaryTreeNode<T> FindNode(T value, BinaryTreeNode<T> root)
        {
            if (root == null)
            {
                return null;
            }

            return Compare.IsLessThan(value, root.Value, m_comparer)
                       ? FindNode(value, root.Left)
                       : (Compare.IsGreaterThan(value, root.Value, m_comparer) ? FindNode(value, root.Right) : root);
        }

        /// <summary>
        /// Called by the Add method. Finds the location where to put the node in the <see cref="BinarySearchTree{T}"/>.
        /// </summary>
        /// <param name="node">Node to start searching from.</param>
        /// <param name="value">Value to insert into the Bst.</param>
        private void InsertNode(BinaryTreeNode<T> node, T value)
        {
            if (Compare.IsLessThan(value, node.Value, m_comparer))
            {
                if (node.Left == null)
                {
                    node.Left = new BinaryTreeNode<T>(value);
                }
                else
                {
                    InsertNode(node.Left, value);
                }
            }
            else
            {
                if (node.Right == null)
                {
                    node.Right = new BinaryTreeNode<T>(value);
                }
                else
                {
                    InsertNode(node.Right, value);
                }
            }
        }

        /// <summary>
        /// Finds the parent of a node with the specified value, starting the search from a specified node in the bst.
        /// </summary>
        /// <remarks>
        /// This method is an O(log n) operation.
        /// </remarks>
        /// <param name="value">Value of node to find parent of.</param>
        /// <param name="root">Node to start the search at.</param>
        /// <returns><see cref="BinaryTreeNode{T}"/> if the parent was found, otherwise null.</returns>
        private BinaryTreeNode<T> FindParent(T value, BinaryTreeNode<T> root)
        {
            if (Compare.IsLessThan(value, root.Value, m_comparer))
            {
                // check to see if the left child of root is null, if it is then the value is not in the bst
                if (root.Left == null)
                {
                    return null;
                }

                return Compare.AreEqual(value, root.Left.Value, m_comparer) ? root : FindParent(value, root.Left);
            }

            if (root.Right == null)
            {
                return null;
            }

            return Compare.AreEqual(value, root.Right.Value, m_comparer) ? root : FindParent(value, root.Right);
        }

        /// <summary>
        /// Determines whether an item is contained within the <see cref="BinarySearchTree{T}"/>.
        /// </summary>
        /// <param name="root">The root node of the <see cref="BinarySearchTree{T}"/>.</param>
        /// <param name="item">The item to be located in the <see cref="BinarySearchTree{T}"/>.</param>
        /// <returns>True if the item is contained within the <see cref="BinarySearchTree{T}"/>; otherwise false.</returns>
        private bool Contains(BinaryTreeNode<T> root, T item)
        {
            if (root == null)
            {
                return false; // if the root is null then we have exhausted all the nodes in the tree, thus the item isn't in the bst
            }

            if (Compare.AreEqual(root.Value, item, m_comparer))
            {
                return true;
            }

            return Compare.IsLessThan(item, root.Value, m_comparer) ? Contains(root.Left, item) : Contains(root.Right, item);
        }
    }
}