namespace Dsa.DataStructures
{

    /// <summary>
    /// BinaryTreeNode(Of T).
    /// </summary>
    /// <typeparam name="T">Type of the BinaryTreeNode.</typeparam>
    public class BinaryTreeNode<T> : DoublyLinkedListNode<T>
    {

        /// <summary>
        /// Initializes a new instance of the BinaryTreeNode(Of T) class with a specified value.
        /// </summary>
        /// <param name="value"></param>
        public BinaryTreeNode(T value)
            : base(value) {}

        /// <summary>
        /// Gets the left child of the BinaryTreeNode.
        /// </summary>
        public BinaryTreeNode<T> Left
        {
            get { return Prev as BinaryTreeNode<T>; }
            set { Prev = value; }
        }

        /// <summary>
        /// Gets the right child of the BinaryTreeNode.
        /// </summary>
        public BinaryTreeNode<T> Right
        {
            get { return Next as BinaryTreeNode<T>; }
            set { Next = value; }
        }

    }
}
