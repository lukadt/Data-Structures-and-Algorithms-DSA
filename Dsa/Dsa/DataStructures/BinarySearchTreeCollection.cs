using System.Collections;
using System.Collections.Generic;

namespace Dsa.DataStructures
{

    /// <summary>
    /// BinarySearchTree(Of T).
    /// </summary>
    /// <typeparam name="T">Type of BinarySearchTree.</typeparam>
    public class BinarySearchTreeCollection<T> : ICollection, ICollection<T>
    {

        private BinaryTreeNode<T> _root;
        private readonly Comparer<T> _comparer = Comparer<T>.Default;

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
                arrayList.Add(root.Value); // add the value of the current node to the arraylist.
                preorderTraveral(root.Left, arrayList); // make a recursive call to preorderTraveral passing the left child of the current node.
                preorderTraveral(root.Right, arrayList); // make a recursive call to preorderTraveral passing the right child of the current node.
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
                postorderTraversal(root.Left, arrayList);  // make a recursive call to postorderTraversal passing the left child of the current node.
                postorderTraversal(root.Right, arrayList);  // make a recursive call to postorderTraversal passing the right child of the current node.
                arrayList.Add(root.Value); // add the value of the current node to the arraylist.
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
        }

        public void Clear()
        {
            throw new System.NotImplementedException();
        }

        public bool Contains(T item)
        {
            throw new System.NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new System.NotImplementedException();
        }

        public int Count
        {
            get { throw new System.NotImplementedException(); }
        }

        public bool IsReadOnly
        {
            get { throw new System.NotImplementedException(); }
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

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

        #endregion

        #region ICollection Members

        public void CopyTo(System.Array array, int index)
        {
            throw new System.NotImplementedException();
        }

        public bool IsSynchronized
        {
            get { throw new System.NotImplementedException(); }
        }

        public object SyncRoot
        {
            get { throw new System.NotImplementedException(); }
        }

        #endregion
    }

}
