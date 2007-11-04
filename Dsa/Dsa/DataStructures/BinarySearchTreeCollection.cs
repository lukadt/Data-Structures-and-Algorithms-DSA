﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Dsa.Properties;

namespace Dsa.DataStructures
{

    /// <summary>
    /// <see cref="BinarySearchTreeCollection{T}"/> is an implementation of a binary search tree.
    /// </summary>
    /// <typeparam name="T">Type of items to store in the <see cref="BinarySearchTreeCollection{T}"/>.</typeparam>
    public sealed class BinarySearchTreeCollection<T> : ICollection, ICollection<T>
    {

        private BinaryTreeNode<T> _root;
        private static readonly Comparer<T> _comparer = Comparer<T>.Default;
        private int _count;
        private object _syncRoot;

        /// <summary>
        /// Initializes a new instance of the <see cref="BinarySearchTreeCollection{T}"/> class
        /// </summary>
        public BinarySearchTreeCollection() { }

        /// <summary>
        /// Gets the root node of the <see cref="BinarySearchTreeCollection{T}"/>.
        /// </summary>
        public BinaryTreeNode<T> Root
        {
            get { return _root; }
        }

        /// <summary>
        /// Called by the Add method. Finds the location where to put the node in the BinarySearchTree.
        /// </summary>
        /// <param name="node">Node to start searching from.</param>
        /// <param name="value">Value to insert into the Bst.</param>
        private void insertNode(BinaryTreeNode<T> node, T value)
        {
            if (_comparer.Compare(value, node.Value) < 0)
            {
                // the value is less than the current nodes value, so go left.
                if (node.Left == null)
                {
                    node.Left = new BinaryTreeNode<T>(value); // the left child of the current node is null so insert the node here.
                }
                else
                {
                    insertNode(node.Left, value); // call the insertNode method going left in the tree.
                }
            }
            else
            {
                // the value is greater than or equal to the current nodes value so go right.
                if (node.Right == null)
                { 
                    node.Right = new BinaryTreeNode<T>(value); // the right child of the current node is null so insert the node here.
                }
                else
                {
                    insertNode(node.Right, value); // call the insertNode method going right in the tree.
                }
            }
        }

        /// <summary>
        /// Traverses the tree in preorder, i.e. returning the values of the nodes passed on the left.
        /// </summary>
        /// <param name="root">The root node of the BinarySearchTree.</param>
        /// <param name="arrayList">A ArrayList to store the traversed node values.</param>
        /// <returns>ArrayList populated with the items from the traversal.</returns>
        private static ArrayListCollection<T> preorderTraveral(BinaryTreeNode<T> root, ArrayListCollection<T> arrayList)
        {
            if (root != null)
            {
                arrayList.Add(root.Value); 
                preorderTraveral(root.Left, arrayList); 
                preorderTraveral(root.Right, arrayList); 
            }
            return arrayList;
        }

        /// <summary>
        /// Traverses the tree in postorder, i.e. returning the values of the nodes passed on the right.
        /// </summary>
        /// <param name="root">The root node of the BinarySearchTree.</param>
        /// <param name="arrayList">ArrayList to store the traversed node values.</param>
        /// <returns>ArrayList populated with the items from the traversal.</returns>
        private static ArrayListCollection<T> postorderTraversal(BinaryTreeNode<T> root, ArrayListCollection<T> arrayList)
        {
            if (root != null)
            {
                postorderTraversal(root.Left, arrayList);  
                postorderTraversal(root.Right, arrayList);  
                arrayList.Add(root.Value); 
            }
            return arrayList;
        }

        /// <summary>
        /// Traverses the tree in inorder, i.e. returning the values of the nodes when a node is passed underneath.
        /// </summary>
        /// <param name="root">The root node of the BinarySearchTree.</param>
        /// <param name="arrayList">ArrayList to store the traversed node values.</param>
        /// <returns>ArrayList populated with the items from the traversal.</returns>
        private static ArrayListCollection<T> inorderTraversal(BinaryTreeNode<T> root, ArrayListCollection<T> arrayList)
        {
            if (root != null)
            {
                inorderTraversal(root.Left, arrayList);
                arrayList.Add(root.Value);
                inorderTraversal(root.Right, arrayList);
            }
            return arrayList;
        }

        /// <summary>
        /// Traverse the tree in breadth first order, i.e. each node is visited on the same depth to depth n where n is the depth of the tree.
        /// </summary>
        /// <param name="root">The root node of the BinarySearchTree.</param>
        /// <returns>ArrayList populated with the items from the traversal.</returns>
        private static ArrayListCollection<T> breadthFirstTraversal(BinaryTreeNode<T> root)
        {
            QueueCollection<BinaryTreeNode<T>> queue = new QueueCollection<BinaryTreeNode<T>>(); // stores the nodes we have yet to visit
            ArrayListCollection<T> visitOrder = new ArrayListCollection<T>(); // stores the value of the nodes visited in bf order
            while (root != null)
            {
                visitOrder.Add(root.Value); // add current nodes value to the list
                if (root.Left != null)
                {
                    queue.Enqueue(root.Left); // add the roots left child node to the queue of nodes to visit
                }
                if (root.Right != null)
                {
                    queue.Enqueue(root.Right); // add the roots right child node to the queue of nodes to visit
                }
                if (!queue.IsEmpty())
                {
                    root = queue.Dequeue(); // we still have nodes to visit, root is assigned to the next node to visit
                }
                else
                {
                    root = null; // we have ran out of nodes to visit
                }
            }
            return visitOrder;
        }

        /// <summary>
        /// Traverses the <see cref="BinarySearchTreeCollection{T}"/> in breadth first order.
        /// </summary>
        /// <returns>An <see cref="IEnumerator{T}" /> that can be used to iterate through the <see cref="BinarySearchTreeCollection{T}"/>.</returns>
        public IEnumerable<T> GetBreadthFirstEnumerator()
        {
            return breadthFirstTraversal(_root);
        }

        ///<summary>
        /// Traverses the <see cref="BinarySearchTreeCollection{T}"/> in postorder traversal.
        ///</summary>
        ///<returns>An <see cref="IEnumerator{T}" /> that can be used to iterate through the <see cref="BinarySearchTreeCollection{T}"/>.</returns>
        public IEnumerable<T> GetPostorderEnumerator()
        {
            ArrayListCollection<T> arrayListCollection = new ArrayListCollection<T>();
            return postorderTraversal(_root, arrayListCollection);
        }

        /// <summary>
        /// Traverses the <see cref="BinarySearchTreeCollection{T}"/> in inorder traversal.
        /// </summary>
        /// <returns>An <see cref="IEnumerator{T}" /> that can be used to iterate through the <see cref="BinarySearchTreeCollection{T}"/>.</returns>
        public  IEnumerable<T> GetInorderEnumerator()
        {
            ArrayListCollection<T> arrayListCollection = new ArrayListCollection<T>();
            return inorderTraversal(_root, arrayListCollection);
        }

        /// <summary>
        /// Finds smallest value in the <see cref="BinarySearchTreeCollection{T}"/>.
        /// </summary>
        /// <returns>Smallest value in the <see cref="BinarySearchTreeCollection{T}"/>.</returns>
        public T FindMin()
        {
            return findMin(_root);
        }

        /// <summary>
        /// Finds the smallest value in the bst.
        /// </summary>
        /// <param name="root">Root node of the bst.</param>
        /// <returns>Smallest value in the bst.</returns>
        private T findMin(BinaryTreeNode<T> root)
        {
            if (root.Left == null) return root.Value; // if the left child of the current node is null then we have found the smallest value in the tree
            return findMin(root.Left); // continue walking down the left side of the tree to locate smallest value
        }

        /// <summary>
        /// Finds the largest value in the <see cref="BinarySearchTreeCollection{T}"/>.
        /// </summary>
        /// <returns>Largest value in the <see cref="BinarySearchTreeCollection{T}"/>.</returns>
        public T FindMax()
        {
            return findMax(_root);
        }

        /// <summary>
        /// Find the largest value in the bst.
        /// </summary>
        /// <param name="root">Root node of the bst.</param>
        /// <returns>Largest value in the bst.</returns>
        private T findMax(BinaryTreeNode<T> root)
        {
            if (root.Right == null) return root.Value; // if the right child of the current node is null then we have found the largest value in the tree
            return findMax(root.Right); // continue walking down the right side of the tree to locate largest value
        }

        /// <summary>
        /// Returns the items in the <see cref="BinarySearchTreeCollection{T}"/> as an <see cref="Array"/> using 
        /// <see cref="BinarySearchTreeCollection{T}.GetBreadthFirstEnumerator"/> traversal.
        /// </summary>
        /// <remarks>
        /// You cannot call the <see cref="BinarySearchTreeCollection{T}.ToArray"/> method on a <see cref="BinarySearchTreeCollection{T}"/> that is
        /// empty.
        /// </remarks>
        /// <returns>An <see cref="Array"/> containing the items of the <see cref="BinarySearchTreeCollection{T}"/>.</returns>
        /// <exception cref="InvalidOperationException"><see cref="BinarySearchTreeCollection{T}"/> is <strong>empty</strong>.</exception>
        public T[] ToArray()
        {
            if (_count < 1)
            {
                throw new InvalidOperationException(Resources.BinarySearchTreeEmpty); // to array is not permitted on a bst with no items.
            }
            int i = 0;
            T[] array = new T[_count];
            foreach (T item in GetBreadthFirstEnumerator())
            {
                // loop through items copying them to an array
                array[i] = item;
                i++;
            }
            return array;
        }

        #region ICollection<T> Members

        /// <summary>
        /// Inserts a new node with the specified value at the appropriate location
        /// in the <see cref="BinarySearchTreeCollection{T}"/>.
        /// </summary>
        /// <param name="item">Value to insert.</param>
        public void Add(T item)
        {
            if (_root == null)
            {
                _root = new BinaryTreeNode<T>(item); // first node to be inserted into the tree.
            }
            else
            {
                insertNode(_root, item); // call the recursive method insertNode to see where this value is to be placed in the tree.
            }
            _count++; // update count as we have added a new node to the bst
        }

        /// <summary>
        /// Removes all items from the <see cref="BinarySearchTreeCollection{T}"/>.
        /// </summary>
        public void Clear()
        {
            _root = null;
            _count = 0;
        }

        /// <summary>
        /// Determines whether an item is contained with the <see cref="BinarySearchTreeCollection{T}"/>.
        /// </summary>
        /// <param name="item">Item to search the <see cref="BinarySearchTreeCollection{T}"/> for.</param>
        /// <returns>True if the item is contained within the <see cref="BinarySearchTreeCollection{T}"/>; false otherwise.</returns>
        public bool Contains(T item)
        {
            return contains(_root, item);
        }

        /// <summary>
        /// Determines whether an item is contained within the bst.
        /// </summary>
        /// <param name="root">The root node of the bst.</param>
        /// <param name="item">The item to be located in the bst.</param>
        /// <returns>True if the item is contained within the bst, false otherwise.</returns>
        private bool contains(BinaryTreeNode<T> root, T item)
        {
            if (root == null) return false; // if the root is null then we have exhausted all the nodes in the tree, thus the item isn't in the bst
            if (_comparer.Compare(root.Value, item) == 0)
            {
                return true; // we have found the item
            }
            else if (_comparer.Compare(item, root.Value) < 0)
            {
                return contains(root.Left, item); // search the left subtree of the current node for the item
            }
            else
            {
                return contains(root.Right, item); // search the right subtree of the current node for the item
            }
        }

        /// <summary>
        /// Copies all the <see cref="BinarySearchTreeCollection{T}"/> items to a compatible one-dimensional <see cref="Array"/>.
        /// </summary>
        /// <param name="array">A one-dimensional <see cref="Array"/> to copy the <see cref="BinarySearchTreeCollection{T}"/> items to.</param>
        public void CopyTo(T[] array)
        {
            Array.Copy(ToArray(), array, _count);
        }

        /// <summary>
        /// Copies all the <see cref="BinarySearchTreeCollection{T}"/> items to a compatible one-dimensional <see cref="Array"/>, 
        /// starting at the specified index of the target <see cref="Array"/>.
        /// </summary>
        /// <param name="array">A one-dimensional <see cref="Array"/> to copy the <see cref="BinarySearchTreeCollection{T}"/> items to.</param>
        /// <param name="arrayIndex">Index of target <see cref="Array"/> where copying begins.</param>
        public void CopyTo(T[] array, int arrayIndex)
        {
            Array.Copy(ToArray(), 0, array, arrayIndex, _count);
        }

        /// <summary>
        /// Gets the number of items contained in the <see cref="BinarySearchTreeCollection{T}"/>.
        /// </summary>
        public int Count
        {
            get { return _count; }
        }

        /// <summary>
        /// Gets whether or not the collection is read only.
        /// </summary>
        bool ICollection<T>.IsReadOnly
        {
            get { return false; }
        }

        /// <summary>
        /// Removes a node with the specified value from the <see cref="BinarySearchTreeCollection{T}"/>.
        /// </summary>
        /// <param name="item">Item to remove from the the <see cref="BinarySearchTreeCollection{T}"/>.</param>
        /// <returns>True if the item was removed; false otherwise.</returns>
        public bool Remove(T item)
        {
            return removeNode(_root, item);
        }

        /// <summary>
        /// Recursive method that removes a node with the specified value from the bst.
        /// </summary>
        /// <param name="root">The root node of the bst.</param>
        /// <param name="value">Value to remove from the bst.</param>
        /// <returns>True if the node was removed, false otherwise.</returns>
        private bool removeNode(BinaryTreeNode<T> root, T value)
        {
            // check to see if we need to go either left or right in the bst
            if (_comparer.Compare(value, root.Value) < 0)
            {
                return removeNode(root.Left, value);
            }
            else if (_comparer.Compare(value, root.Value) > 0)
            {
                return removeNode(root.Right, value);
            }
            else // the value to delete is neither < or > than the current nodes value so we have found the node to delete
            {
                // test for leaf node
                if (root.Left == null) 
                {
                    root = root.Right; 
                    return true;
                }
                else if (root.Right == null)
                {
                    root = root.Left;
                    return true;
                }
                else
                {
                    // the node to delete is not a leaf
                    return false;
                }
            }
        }

        #endregion

        #region IEnumerable<T> Members

        ///<summary>
        /// An <see cref="IEnumerator{T}"/> that iterates through the <see cref="BinarySearchTreeCollection{T}"/>.  By default Preorder traversal of the tree.
        ///</summary>
        ///<returns>
        /// An <see cref="IEnumerator{T}" /> that can be used to iterate through the <see cref="BinarySearchTreeCollection{T}"/>.
        ///</returns>
        public IEnumerator<T> GetEnumerator()
        {
            ArrayListCollection<T> arrayListCollection = new ArrayListCollection<T>();
            return preorderTraveral(_root, arrayListCollection).GetEnumerator();
        }

        #endregion

        #region IEnumerable Members

        ///<summary>
        /// An <see cref="IEnumerator"/> that iterates through the collection.  By default Preorder traversal of the tree.
        ///</summary>
        ///<returns>
        /// A <see cref="IEnumerator" /> that can be used to iterate through the collection.
        ///</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion

        #region ICollection Members

        /// <summary>
        /// Not Supported.  Copies items in bst to a target array.
        /// </summary>
        /// <param name="array">Target array to copy items to.</param>
        /// <param name="index">Index to starty copying items to.</param>
        public void CopyTo(Array array, int index)
        {
            throw new NotSupportedException(Resources.ICollectionCopyToNotSupported);
        }

        /// <summary>
        /// Gets whether or not the collection is thread safe.
        /// </summary>
        public bool IsSynchronized
        {
            get { return false; }
        }

        /// <summary>
        /// Gets an object that can be used to synchronize accesss to the collection.
        /// </summary>
        object ICollection.SyncRoot
        {
            get 
            {
                if (_syncRoot == null)
                {
                    Interlocked.CompareExchange(ref _syncRoot, new object(), null);
                }
                return _syncRoot;
            }
        }

        #endregion
    }

}
