using System;
using System.Collections;
using System.Collections.Generic;
using Dsa.Properties;
using Dsa.Utility;

namespace Dsa.DataStructures
{

    /// <summary>
    /// <see cref="BinarySearchTree{T}"/> is an implementation of a binary search tree.
    /// </summary>
    /// <typeparam name="T">Type of items to store in the <see cref="BinarySearchTree{T}"/>.</typeparam>
    [Serializable]
    public sealed class BinarySearchTree<T> : CollectionBase<T>, IComparerProvider<T>
    {

        [NonSerialized]
        private BinaryTreeNode<T> _root;
        [NonSerialized]
        private IComparer<T> _comparer;

        /// <summary>
        /// Initializes a new instance of the <see cref="BinarySearchTree{T}"/> class.
        /// </summary>
        public BinarySearchTree() 
        {
            _comparer = Comparer<T>.Default;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BinarySearchTree{T}"/> class using a provided <see cref="IComparer{T}"/>.
        /// </summary>
        /// <param name="comparer">Comparer to use with <see cref="BinarySearchTree{T}"/>.</param>
        /// <exception cref="ArgumentNullException"><strong>comparer</strong> is <strong>null</strong>.</exception>
        public BinarySearchTree(IComparer<T> comparer)
        {
            if (comparer == null)
            {
                throw new ArgumentNullException("comparer");
            }
            _comparer = comparer;
        }

        /// <summary>
        /// Gets the root node of the <see cref="BinarySearchTree{T}"/>.
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
        private void InsertNode(BinaryTreeNode<T> node, T value)
        {
            if (Compare.IsLessThan(value, node.Value, _comparer))
            {
                // the value is less than the current nodes value, so go left.
                if (node.Left == null)
                {
                    node.Left = new BinaryTreeNode<T>(value); // the left child of the current node is null so insert the node here.
                }
                else
                {
                    InsertNode(node.Left, value); // call the insertNode method going left in the tree.
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
                    InsertNode(node.Right, value); // call the insertNode method going right in the tree.
                }
            }
        }

        /// <summary>
        /// Finds a node in the <see cref="BinarySearchTree{T}"/> with the specified value.
        /// </summary>
        /// <param name="value">Value to find.</param>
        /// <returns>A <see cref="BinaryTreeNode{T}"/> if a node was found with the value provided; otherwise null.</returns>
        public BinaryTreeNode<T> FindNode(T value)
        {
            return FindNode(value, _root);
        }

        /// <summary>
        /// Finds a node in the <see cref="BinarySearchTree{T}"/> with the specified value.
        /// </summary>
        /// <param name="value">Value to find.</param>
        /// <param name="root">Node to start search from.</param>
        /// <returns>A <see cref="BinaryTreeNode{T}"/> if a node was found with the value provided; otherwise null.</returns>
        private BinaryTreeNode<T> FindNode(T value, BinaryTreeNode<T> root)
        {
            if (root == null)
            {
                return null; // there is no node in the bst with the value specified
            }
            /* check to see which way in the bst to go - left if value is less than the value of root, or right
            * if value is greater than the value of root.*/
            if (Compare.IsLessThan(value, root.Value, _comparer))
            {
                return FindNode(value, root.Left);
            }
            else if (Compare.IsGreaterThan(value, root.Value, _comparer))
            {
                return FindNode(value, root.Right);
            }
            else
            {
                /* the value is neither greater than or less than the value of root - thus we have found the 
                 * node we are looking for. */
                return root; 
            }
        }

        /// <summary>
        /// Finds the parent node of a node with the specified value.
        /// </summary>
        /// <param name="value">Value of node to find parent of.</param>
        /// <returns><see cref="BinaryTreeNode{T}"/> if the parent was found, otherwise null.</returns>
        public BinaryTreeNode<T> FindParent(T value)
        {
            /* check to see if there are any items in the bst, if not then you cannot search the bst for a parent
             * node of a specified value. */
            if (_root == null)
            {
                throw new InvalidOperationException(Resources.BinarySearchTreeEmpty);
            }
            /* check to see if the value is the same as that of the root node, if it is then the root 
             * has no parent so return null. */
            if (Compare.AreEqual(value, _root.Value, _comparer))
            {
                return null;
            }
            return FindParent(value, _root);
        }

        /// <summary>
        /// Finds the parent of a node with the specified value, starting the search from a specified node in the bst.
        /// </summary>
        /// <param name="value">Value of node to find parent of.</param>
        /// <param name="root">Node to start the search at.</param>
        /// <returns><see cref="BinaryTreeNode{T}"/> if the parent was found, otherwise null.</returns>
        private BinaryTreeNode<T> FindParent(T value, BinaryTreeNode<T> root)
        {
            if (Compare.IsLessThan(value, root.Value, _comparer))
            {
                // check to see if the left child of root is null, if it is then the value is not in the bst
                if (root.Left == null)
                {
                    return null;
                }
                else if (Compare.AreEqual(value, root.Left.Value, _comparer))
                {
                    // root is the parent of the node with the value searching for
                    return root;
                }
                else
                {
                    return FindParent(value, root.Left); // search the left subtree of root for the node with the spoecified value
                }
            }
            else
            {
                // check to see if the right child of root is null, if it is then the value is not in the bst
                if (root.Right == null)
                {
                    return null; 
                }
                else if (Compare.AreEqual(value, root.Right.Value, _comparer))
                {
                    // root is the parent of the node with the value searching for
                    return root;
                }
                else
                {
                    return FindParent(value, root.Right); // search the right subtree of root for the node with the spoecified value
                }
            }
        }

        /// <summary>
        /// Traverses the tree in preorder, i.e. returning the values of the nodes passed on the left.
        /// </summary>
        /// <param name="root">The root node of the BinarySearchTree.</param>
        /// <param name="arrayList">A ArrayList to store the traversed node values.</param>
        /// <returns>ArrayList populated with the items from the traversal.</returns>
        private static ArrayList<T> PreorderTraveral(BinaryTreeNode<T> root, ArrayList<T> arrayList)
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
        /// Traverses the tree in postorder, i.e. returning the values of the nodes passed on the right.
        /// </summary>
        /// <param name="root">The root node of the BinarySearchTree.</param>
        /// <param name="arrayList">ArrayList to store the traversed node values.</param>
        /// <returns>ArrayList populated with the items from the traversal.</returns>
        private static ArrayList<T> PostorderTraversal(BinaryTreeNode<T> root, ArrayList<T> arrayList)
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
        /// Traverses the tree in inorder, i.e. returning the values of the nodes when a node is passed underneath.
        /// </summary>
        /// <param name="root">The root node of the BinarySearchTree.</param>
        /// <param name="arrayList">ArrayList to store the traversed node values.</param>
        /// <returns>ArrayList populated with the items from the traversal.</returns>
        private static ArrayList<T> InorderTraversal(BinaryTreeNode<T> root, ArrayList<T> arrayList)
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
        /// Traverse the tree in breadth first order, i.e. each node is visited on the same depth to depth n where n is the depth of the tree.
        /// </summary>
        /// <param name="root">The root node of the BinarySearchTree.</param>
        /// <returns>ArrayList populated with the items from the traversal.</returns>
        private static ArrayList<T> BreadthFirstTraversal(BinaryTreeNode<T> root)
        {
            Queue<BinaryTreeNode<T>> queue = new Queue<BinaryTreeNode<T>>(); // stores the nodes we have yet to visit
            ArrayList<T> visitOrder = new ArrayList<T>(); // stores the value of the nodes visited in bf order
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
                if (queue.Count > 0)
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
        /// Traverses the <see cref="BinarySearchTree{T}"/> in breadth first order.
        /// </summary>
        /// <returns>An <see cref="IEnumerator{T}" /> that can be used to iterate through the <see cref="BinarySearchTree{T}"/>.</returns>
        public IEnumerable<T> GetBreadthFirstEnumerator()
        {
            return BreadthFirstTraversal(_root);
        }

        ///<summary>
        /// Traverses the <see cref="BinarySearchTree{T}"/> in postorder traversal.
        ///</summary>
        ///<returns>An <see cref="IEnumerator{T}" /> that can be used to iterate through the <see cref="BinarySearchTree{T}"/>.</returns>
        public IEnumerable<T> GetPostorderEnumerator()
        {
            ArrayList<T> arrayListCollection = new ArrayList<T>();
            return PostorderTraversal(_root, arrayListCollection);
        }

        /// <summary>
        /// Traverses the <see cref="BinarySearchTree{T}"/> in inorder traversal.
        /// </summary>
        /// <returns>An <see cref="IEnumerator{T}" /> that can be used to iterate through the <see cref="BinarySearchTree{T}"/>.</returns>
        public  IEnumerable<T> GetInorderEnumerator()
        {
            ArrayList<T> arrayListCollection = new ArrayList<T>();
            return InorderTraversal(_root, arrayListCollection);
        }

        /// <summary>
        /// Finds smallest value in the <see cref="BinarySearchTree{T}"/>.
        /// </summary>
        /// <returns>Smallest value in the <see cref="BinarySearchTree{T}"/>.</returns>
        public T FindMin()
        {
            return FindMin(_root);
        }

        /// <summary>
        /// Finds the smallest value in the bst.
        /// </summary>
        /// <param name="root">Root node of the bst.</param>
        /// <returns>Smallest value in the bst.</returns>
        private T FindMin(BinaryTreeNode<T> root)
        {
            if (root.Left == null) return root.Value; // if the left child of the current node is null then we have found the smallest value in the tree
            return FindMin(root.Left); // continue walking down the left side of the tree to locate smallest value
        }

        /// <summary>
        /// Finds the largest value in the <see cref="BinarySearchTree{T}"/>.
        /// </summary>
        /// <returns>Largest value in the <see cref="BinarySearchTree{T}"/>.</returns>
        public T FindMax()
        {
            return FindMax(_root);
        }

        /// <summary>
        /// Find the largest value in the bst.
        /// </summary>
        /// <param name="root">Root node of the bst.</param>
        /// <returns>Largest value in the bst.</returns>
        private T FindMax(BinaryTreeNode<T> root)
        {
            if (root.Right == null) return root.Value; // if the right child of the current node is null then we have found the largest value in the tree
            return FindMax(root.Right); // continue walking down the right side of the tree to locate largest value
        }

        /// <summary>
        /// Returns the items in the <see cref="BinarySearchTree{T}"/> as an <see cref="Array"/> using 
        /// <see cref="BinarySearchTree{T}.GetBreadthFirstEnumerator"/> traversal.
        /// </summary>
        /// <remarks>
        /// You cannot call the <see cref="BinarySearchTree{T}.ToArray"/> method on a <see cref="BinarySearchTree{T}"/> that is
        /// empty.
        /// </remarks>
        /// <returns>An <see cref="Array"/> containing the items of the <see cref="BinarySearchTree{T}"/>.</returns>
        /// <exception cref="InvalidOperationException"><see cref="BinarySearchTree{T}"/> is <strong>empty</strong>.</exception>
        public override T[] ToArray()
        {
            if (Count < 1)
            {
                throw new InvalidOperationException(Resources.BinarySearchTreeEmpty); // to array is not permitted on a bst with no items.
            }
            int i = 0;
            T[] array = new T[Count];
            foreach (T item in GetBreadthFirstEnumerator())
            {
                // loop through items copying them to an array
                array[i] = item;
                i++;
            }
            return array;
        }

        /// <summary>
        /// Inserts a new node with the specified value at the appropriate location
        /// in the <see cref="BinarySearchTree{T}"/>.
        /// </summary>
        /// <param name="item">Value to insert.</param>
        public override void Add(T item)
        {
            if (_root == null)
            {
                _root = new BinaryTreeNode<T>(item); // first node to be inserted into the tree.
            }
            else
            {
                InsertNode(_root, item); // call the recursive method insertNode to see where this value is to be placed in the tree.
            }
            Count++; // update count as we have added a new node to the bst
        }

        /// <summary>
        /// Clears all items from the <see cref="BinarySearchTree{T}"/>.
        /// </summary>
        public override void Clear()
        {
            _root = null;
            Count = 0;
        }

        /// <summary>
        /// Determines whether an item is contained within the <see cref="BinarySearchTree{T}"/>.
        /// </summary>
        /// <param name="item">Item to search the <see cref="BinarySearchTree{T}"/> for.</param>
        /// <returns>True if the item is contained within the <see cref="BinarySearchTree{T}"/>; false otherwise.</returns>
        public override bool Contains(T item)
        {
            return Contains(_root, item);
        }

        /// <summary>
        /// Determines whether an item is contained within the bst.
        /// </summary>
        /// <param name="root">The root node of the bst.</param>
        /// <param name="item">The item to be located in the bst.</param>
        /// <returns>True if the item is contained within the bst, false otherwise.</returns>
        private bool Contains(BinaryTreeNode<T> root, T item)
        {
            if (root == null)
            {
                return false; // if the root is null then we have exhausted all the nodes in the tree, thus the item isn't in the bst
            }
            if (Compare.AreEqual(root.Value, item, _comparer))
            {
                return true; // we have found the item
            }
            else if (Compare.IsLessThan(item, root.Value, _comparer))
            {
                return Contains(root.Left, item); // search the left subtree of the current node for the item
            }
            else
            {
                return Contains(root.Right, item); // search the right subtree of the current node for the item
            }
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
        /// Removes a node with the specified value from the <see cref="BinarySearchTree{T}"/>.
        /// </summary>
        /// <param name="item">Item to remove from the the <see cref="BinarySearchTree{T}"/>.</param>
        /// <returns>True if the item was removed; false otherwise.</returns>
        public override bool Remove(T item)
        {
            BinaryTreeNode<T> nodeToRemove = FindNode(item);
            // check to see if the item is not in the bst
            if (nodeToRemove == null)
            {
                return false;
            }

            BinaryTreeNode<T> parent = FindParent(item);

            // check to see if nodeToRemove is the only node in the bst
            if (Count == 1)
            {
                _root = null;
            }
            else if (nodeToRemove.Left == null && nodeToRemove.Right == null)
            {
                // nodeToRemove is a leaf
                if (Compare.IsLessThan(nodeToRemove.Value, parent.Value, _comparer))
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
                if (Compare.IsLessThan(nodeToRemove.Value, parent.Value, _comparer))
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
                if (Compare.IsLessThan(nodeToRemove.Value, parent.Value, _comparer))
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
                /* find the parent of the largest value in the left subtree of nodeToDelete and sets its
                 * * Right property to null. */
                FindParent(largestValue.Value).Right = null;
                // set value of nodeToRemove to the value of largestValue
                nodeToRemove.Value = largestValue.Value;
            }
            Count--;
            return true;
        }

        ///<summary>
        /// An <see cref="IEnumerator{T}"/> that iterates through the <see cref="BinarySearchTree{T}"/>.  By default Preorder traversal of the tree.
        ///</summary>
        ///<returns>
        /// An <see cref="IEnumerator{T}" /> that can be used to iterate through the <see cref="BinarySearchTree{T}"/>.
        ///</returns>
        public override IEnumerator<T> GetEnumerator()
        {
            ArrayList<T> arrayListCollection = new ArrayList<T>();
            return PreorderTraveral(_root, arrayListCollection).GetEnumerator();
        }

        #region IComparerProvider<T> Members

        /// <summary>
        /// Gets the <see cref="IComparer{T}"/> being used.
        /// </summary>
        public IComparer<T> Comparer
        {
            get { return _comparer; }
        }

        #endregion
    }

}
