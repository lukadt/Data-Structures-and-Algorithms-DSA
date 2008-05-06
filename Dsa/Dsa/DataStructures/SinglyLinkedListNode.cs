namespace Dsa.DataStructures
{
    /// <summary>
    /// Node used in <see cref="SinglyLinkedList{T}"/>.
    /// </summary>
    /// <typeparam name="T">Type of the <see cref="SinglyLinkedListNode{T}"/>.</typeparam>
    public sealed class SinglyLinkedListNode<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SinglyLinkedListNode{T}"/> class with a specified value.
        /// </summary>
        /// <param name="value">Value of node.</param>
        public SinglyLinkedListNode(T value)
        {
            Value = value;
        }

        /// <summary>
        /// Gets the value of <see cref="SinglyLinkedListNode{T}"/>.
        /// </summary>
        public T Value { get; private set; }

        /// <summary>
        /// Gets or sets the pointer to the next <see cref="SinglyLinkedListNode{T}"/>.
        /// </summary>
        public SinglyLinkedListNode<T> Next { get; set; }
    }
}