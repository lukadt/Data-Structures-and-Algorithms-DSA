namespace Dsa.DataStructures {

    /// <summary>
    /// SinglyLinkedListNode is the node used internally by the SinglyLinkedList data structure.
    /// </summary>
    /// <typeparam name="T"> value of the node.</typeparam>
    public class SinglyLinkedListNode<T> {

        private T _value;
        private SinglyLinkedListNode<T> _next;

        /// <summary>
        /// Initializes a new instance of the SinglyLinkedListNode class with a specified value.
        /// </summary>
        /// <param name="value"> <typeparamref name="T"/> of node.</param>
        public SinglyLinkedListNode(T value) {
            _value = value;
        }

        /// <summary>
        /// Initializes a new instance of the SinglyLinkedListNode class with a specified value and next node.
        /// </summary>
        /// <param name="value"> <paramref name="T"/> of node.</param>
        /// <param name="next"> <typeparamref name="SinglyLinkedListNode<T>"/> node to link to.</param>
        public SinglyLinkedListNode(T value, SinglyLinkedListNode<T> next)
            : this(value) {
            _next = next;
        }

        /// <summary>
        /// Gets Value of node.
        /// </summary>
        public T Value {
            get { return _value; }
        }

        /// <summary>
        /// Gets pointer to the next node.
        /// </summary>
        public SinglyLinkedListNode<T> Next {
            get { return _next; }
        }

    }

}
