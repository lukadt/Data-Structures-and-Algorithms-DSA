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
    public sealed class BinarySearchTree<T> : CollectionBase<T>, IComparerProvider<T>
    {
        [NonSerialized]
        private BinaryTreeNode<T> _root;
        [NonSerialized]
        private readonly IComparer<T> _comparer;

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
            Guard.ArgumentNull(comparer, "comparer");

            _comparer = comparer;
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
                // the value is greater than or equal to the current nodes value so go right.
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
        /// Finds a node in the <see cref="BinarySearchTree{T}"/> with the specified value.
        /// </summary>
        /// <remarks>
        /// This method is an O(log n) operation.
        /// </remarks>
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
                return null; 
            }

            return Compare.IsLessThan(value, root.Value, _comparer)
                       ? FindNode(value, root.Left)
                       : (Compare.IsGreaterThan(value, root.Value, _comparer) ? FindNode(value, root.Right) : root);
        }

        /// <summary>
        /// Finds the parent node of a node with the specified value.
        /// </summary>
        /// <param name="value">Value of node to find parent of.</param>
        /// <returns><see cref="BinaryTreeNode{T}"/> if the parent was found, otherwise null.</returns>
        /// <exception cref="InvalidOperationException"><see cref="BinarySearchTree{T}"/> is <strong>empty</strong>.</exception>
        public BinaryTreeNode<T> FindParent(T value)
        {
            if (_root == null)
            {
                throw new InvalidOperationException(Resources.BinarySearchTreeEmpty);
            }

            return Compare.AreEqual(value, _root.Value, _comparer) ? null : FindParent(value, _root);
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
            if (Compare.IsLessThan(value, root.Value, _comparer))
            {
                // check to see if the left child of root is null, if it is then the value is not in the bst
                if (root.Left == null)
                {
                    return null;
                }
                return Compare.AreEqual(value, root.Left.Value, _comparer) ? root : FindParent(value, root.Left);
            }
            if (root.Right == null)
            {
                return null; 
            }
            return Compare.AreEqual(value, root.Right.Value, _comparer) ? root : FindParent(value, root.Right);
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
        /// Traverses the <see cref="BinarySearchTree{T}"/> in breadth first order.
        /// </summary>
        /// <remarks>
        /// This method is an O(n) operation where n is the number of nodes in the <see cref="BinarySearchTree{T}"/> .
        /// </remarks>
        /// <returns>An <see cref="IEnumerator{T}" /> that can be used to iterate through the <see cref="BinarySearchTree{T}"/>.</returns>
        public IEnumerable<T> GetBreadthFirstEnumerator()
        {
            return BreadthFirstTraversal(_root);
        }

        ///<summary>
        /// Traverses the <see cref="BinarySearchTree{T}"/> in postorder traversal.
        ///</summary>
        ///<remarks>
        ///This method is an O(n) operation where n is the number of nodes in the <see cref="BinarySearchTree{T}"/> .
        /// </remarks>
        ///<returns>An <see cref="IEnumerator{T}" /> that can be used to iterate through the <see cref="BinarySearchTree{T}"/>.</returns>
        public IEnumerable<T> GetPostorderEnumerator()
        {
            List<T> arrayListCollection = new List<T>();
            return PostorderTraversal(_root, arrayListCollection);
        }

        /// <summary>
        /// Traverses the <see cref="BinarySearchTree{T}"/> in in order traversal.
        /// </summary>
        /// <remarks>
        /// This method is an O(n) operation where n is the number of nodes in the <see cref="BinarySearchTree{T}"/>.
        /// </remarks>
        /// <returns>An <see cref="IEnumerator{T}" /> that can be used to iterate through the <see cref="BinarySearchTree{T}"/>.</returns>
        public  IEnumerable<T> GetInorderEnumerator()
        {
            List<T> arrayListCollection = new List<T>();
            return InorderTraversal(_root, arrayListCollection);
        }

        /// <summary>
        /// Finds smallest value in the <see cref="BinarySearchTree{T}"/>.
        /// </summary>
        /// <remarks>
        /// This method is an O(log n) operation.
        /// </remarks>
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
        private static T FindMin(BinaryTreeNode<T> root)
        {
            if (root.Left == null)
            {
                return root.Value;
            }
            return FindMin(root.Left);
        }

        /// <summary>
        /// Finds the largest value in the <see cref="BinarySearchTree{T}"/>.
        /// </summary>
        /// <remarks>
        /// This method is an O(log n) operation.
        /// </remarks>
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
        private static T FindMax(BinaryTreeNode<T> root)
        {
            if (root.Right == null)
            {
                return root.Value;
            }
            return FindMax(root.Right); 
        }

        /// <summary>
        /// Returns the items in the <see cref="BinarySearchTree{T}"/> as an <see cref="Array"/> using <see cref="BinarySearchTree{T}.GetBreadthFirstEnumerator"/> 
        /// traversal.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method is an O(n) operation where n is the number of nodes in the <see cref="BinarySearchTree{T}"/>.
        /// </para>
        /// <para>
        /// You cannot call the <see cref="BinarySearchTree{T}.ToArray"/> method on a <see cref="BinarySearchTree{T}"/> that is empty.
        /// </para>
        /// </remarks>
        /// <returns>A one-dimensional <see cref="Array"/> containing the items of the <see cref="BinarySearchTree{T}"/>.</returns>
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
                array[i] = item;
                i++;
            }
            return array;
        }

        /// <summary>
        /// Inserts a new node with the specified value at the appropriate location
        /// in the <see cref="BinarySearchTree{T}"/>.
        /// </summary>
        /// <remarks>
        /// This method is an O(log n) operation.
        /// </remarks>
        /// <param name="item">Value to insert.</param>
        public override void Add(T item)
        {
            if (_root == null)
            {
                _root = new BinaryTreeNode<T>(item);
            }
            else
            {
                InsertNode(_root, item);
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
            _root = null;
            Count = 0;
        }

        /// <summary>
        /// Determines whether an item is contained within the <see cref="BinarySearchTree{T}"/>.
        /// </summary>
        /// <remarks>
        /// This method is an O(log n) operation.
        /// </remarks>
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
                return true; 
            }
            return Compare.IsLessThan(item, root.Value, _comparer) ? Contains(root.Left, item) : Contains(root.Right, item);
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
        /// <remarks>
        /// This method is an O(log n) operation.
        /// </remarks>
        /// <param name="item">Item to remove from the the <see cref="BinarySearchTree{T}"/>.</param>
        /// <returns>True if the item was removed; false otherwise.</returns>
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
                // find the parent of the largest value in the left subtree of nodeToDelete and sets its right property to null.
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
        ///<remarks>
        /// This method is an O(n) operation.
        ///</remarks>
        ///<returns>
        /// An <see cref="IEnumerator{T}" /> that can be used to iterate through the <see cref="BinarySearchTree{T}"/>.
        ///</returns>
        public override IEnumerator<T> GetEnumerator()
        {
            List<T> arrayListCollection = new List<T>();
            return PreorderTraveral(_root, arrayListCollection).GetEnumerator();
        }

        /// <summary>
        /// Gets the root node of the <see cref="BinarySearchTree{T}"/>.
        /// </summary>
        public BinaryTreeNode<T> Root
        {
            get { return _root; }
        }

        /// <summary>
        /// Gets the <see cref="IComparer{T}"/> being used.
        /// </summary>
        IComparer<T> IComparerProvider<T>.Comparer
        {
            get { return _comparer; }
        }
    }
}