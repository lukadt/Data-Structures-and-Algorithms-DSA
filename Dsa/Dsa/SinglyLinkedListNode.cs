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
        /// Gets Value of node.
        /// </summary>
        public T Value {
            get { return _value; }
        }

        /// <summary>
        /// Gets pointer to the next node, or sets the pointer to the next node.
        /// </summary>
        public SinglyLinkedListNode<T> Next {
            get { return _next; }
            set { _next = value; }
        }

    }

}
