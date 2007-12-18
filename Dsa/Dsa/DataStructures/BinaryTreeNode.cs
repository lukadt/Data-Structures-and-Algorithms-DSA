namespace Dsa.DataStructures
{

    /// <summary>
    /// <see cref="BinaryTreeNode{T}"/> is an implementation of a node used with a tree data structure.
    /// </summary>
    /// <typeparam name="T">Type of the <see cref="BinaryTreeNode{T}"/>.</typeparam>
    public sealed class BinaryTreeNode<T> : DoublyLinkedListNode<T>
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="BinaryTreeNode{T}"/> class with a specified value.
        /// </summary>
        /// <param name="value">Value of the node.</param>
        public BinaryTreeNode(T value)
            : base(value) {}

        /// <summary>
        /// Gets or Sets the left child of the <see cref="BinaryTreeNode{T}"/>.
        /// </summary>
        public BinaryTreeNode<T> Left
        {
            get { return Previous as BinaryTreeNode<T>; }
            set { Previous = value; }
        }

        /// <summary>
        /// Gets or Sets the right child of the <see cref="BinaryTreeNode{T}"/>.
        /// </summary>
        public BinaryTreeNode<T> Right
        {
            get { return Next as BinaryTreeNode<T>; }
            set { Next = value; }
        }

    }
}
