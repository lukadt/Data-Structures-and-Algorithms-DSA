using System.Collections.Generic;

namespace Dsa.DataStructures
{

    /// <summary>
    /// BinarySearchTree(Of T).
    /// </summary>
    /// <typeparam name="T">Type of BinarySearchTree.</typeparam>
    public class BinarySearchTree<T>
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
        /// Inserts a new node with the specified value at the appropriate location
        /// in the BinarySearchTree.
        /// </summary>
        /// <param name="value">Value to insert.</param>
        public void Insert(T value)
        {
            if (_root == null)
            {
                _root = new BinaryTreeNode<T>(value); // first node to be inserted into the tree.
            }
            else
            {
                insertNode(_root, value); // call the recursive method insertNode to see where this value is to be placed in the tree.
            }
        }

        /// <summary>
        /// Finds the location where to put the node in the BinarySearchTree.
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

    }

}
