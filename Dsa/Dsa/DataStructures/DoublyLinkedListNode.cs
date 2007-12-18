namespace Dsa.DataStructures
{

    /// <summary>
    /// <see cref="DoublyLinkedListNode{T}"/> is an implementation of a node used in a doubly linked list data structure.
    /// </summary>
    /// <typeparam name="T">Type of <see cref="DoublyLinkedListNode{T}"/>.</typeparam>
    public class DoublyLinkedListNode<T>
    {

        private T _value;
        private DoublyLinkedListNode<T> _next;
        private DoublyLinkedListNode<T> _previous;

        /// <summary>
        /// Initializes a new instance of the <see cref="DoublyLinkedListNode{T}"/> class with a specified value.
        /// </summary>
        /// <param name="value">Value of the node.</param>
        public DoublyLinkedListNode(T value)
        {
            _value = value;
        }

        /// <summary>
        /// Gets or sets the value of the <see cref="DoublyLinkedListNode{T}"/>.
        /// </summary>
        public T Value
        {
            get { return _value; }
            set { _value = value; }
        }

        /// <summary>
        /// Gets or sets the next <see cref="DoublyLinkedListNode{T}"/> that this <see cref="DoublyLinkedListNode{T}"/> links to.
        /// </summary>
        public DoublyLinkedListNode<T> Next
        {
            get { return _next; }
            set { _next = value; }
        }

        /// <summary>
        /// Gets or sets the Previous <see cref="DoublyLinkedListNode{T}"/> that this <see cref="DoublyLinkedListNode{T}"/> links to.
        /// </summary>
        public DoublyLinkedListNode<T> Previous
        {
            get { return _previous; }
            set { _previous = value; }
        }

    }

}
