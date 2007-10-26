using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace Dsa.DataStructures
{

    /// <summary>
    /// BinarySearchTree(Of T).
    /// </summary>
    /// <typeparam name="T">Type of BinarySearchTree.</typeparam>
    public sealed class BinarySearchTreeCollection<T> : ICollection, ICollection<T>
    {

        private BinaryTreeNode<T> _root;
        private readonly Comparer<T> _comparer = Comparer<T>.Default;
        private int _count;
        private object _syncRoot;

        /// <summary>
        /// Gets the node at the root of the BinarySearchTree(Of T).
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
        /// <param name="arrayList">A <see cref="T:Dsa.DataStructures.ArrayListCollection`1" /> to store the traversed node values.</param>
        /// <returns>A <see cref="T:Dsa.DataStructures.ArrayListCollection`1" /> populated with the items from the traversal.</returns>
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
        /// <param name="arrayList">A <see cref="T:Dsa.DataStructures.ArrayListCollection`1" /> to store the traversed node values.</param>
        /// <returns>A <see cref="T:Dsa.DataStructures.ArrayListCollection`1" /> populated with the items from the traversal.</returns>
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
        /// <param name="arrayList">A <see cref="T:Dsa.DataStructures.ArrayListCollection`1" /> to store the traversed node values.</param>
        /// <returns>A <see cref="T:Dsa.DataStructures.ArrayListCollection`1" /> populated with the items from the traversal.</returns>
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

        ///<summary>
        /// Traverses the BinarySearchTree in postorder traversal.
        ///</summary>
        ///<returns>A <see cref="T:System.Collections.Generic.IEnumerable`1" /> enumeator.</returns>
        public IEnumerable<T> GetPostorderEnumerator()
        {
            ArrayListCollection<T> arrayListCollection = new ArrayListCollection<T>();
            return postorderTraversal(_root, arrayListCollection);
        }

        /// <summary>
        /// Traverses the BinarySearchTree in inorder traversal.
        /// </summary>
        /// <returns>A <see cref="T:System.Collections.Generic.IEnumerable`1" /> enumeator.</returns>
        public  IEnumerable<T> GetInorderEnumerator()
        {
            ArrayListCollection<T> arrayListCollection = new ArrayListCollection<T>();
            return inorderTraversal(_root, arrayListCollection);
        }

        /// <summary>
        /// Finds smallest value in the bst.
        /// </summary>
        /// <returns>Smallest value in the bst.</returns>
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
        /// Finds the largest value in the bst.
        /// </summary>
        /// <returns>Largest value in the bst.</returns>
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

        #region ICollection<T> Members

        /// <summary>
        /// Inserts a new node with the specified value at the appropriate location
        /// in the BinarySearchTree.
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
        /// Removes all items from the BinarySearchTreeCollection.
        /// </summary>
        public void Clear()
        {
            _root = null;
            _count = 0;
        }

        public bool Contains(T item)
        {
            throw new System.NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Gets the number of items contained in the BinarySearchTree.
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

        public bool Remove(T item)
        {
            throw new System.NotImplementedException();
        }

        #endregion

        #region IEnumerable<T> Members

        ///<summary>
        /// An enumerator that iterates through the collection.  By default Preorder traversal of the tree.
        ///</summary>
        ///<returns>
        /// A <see cref="T:System.Collections.Generic.IEnumerator`1" /> that can be used to iterate through the collection.
        ///</returns>
        public IEnumerator<T> GetEnumerator()
        {
            ArrayListCollection<T> arrayListCollection = new ArrayListCollection<T>();
            return preorderTraveral(_root, arrayListCollection).GetEnumerator();
        }

        #endregion

        #region IEnumerable Members

        ///<summary>
        /// An enumerator that iterates through the collection.  By default Preorder traversal of the tree.
        ///</summary>
        ///<returns>
        /// A <see cref="T:System.Collections.Generic.IEnumerator" /> that can be used to iterate through the collection.
        ///</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion

        #region ICollection Members

        public void CopyTo(System.Array array, int index)
        {
            throw new System.NotImplementedException();
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
