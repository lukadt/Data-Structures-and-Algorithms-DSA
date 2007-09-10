namespace Dsa.DataStructures {

    /// <summary>
    /// DoublyLinkedListNode(Of T).
    /// </summary>
    /// <typeparam name="T">Type of node.</typeparam>
    public class DoublyLinkedListNode<T> {

        private T _value;
        private DoublyLinkedListNode<T> _next;
        private DoublyLinkedListNode<T> _prev;

        /// <summary>
        /// Initializes a new instance of the DoublyLinkedListNode(Of T) class with a specified value.
        /// </summary>
        /// <param name="value">Value of the node.</param>
        public DoublyLinkedListNode(T value) {
            _value = value;
        }

        /// <summary>
        /// Gets the value of the node.
        /// </summary>
        public T Value {
            get { return _value; }
        }

        /// <summary>
        /// Gets or sets the next node that this node links to.
        /// </summary>
        public DoublyLinkedListNode<T> Next {
            get { return _next; }
            set { _next = value; }
        }

        /// <summary>
        /// Gets or sets the previous node that this node links to.
        /// </summary>
        public DoublyLinkedListNode<T> Prev {
            get { return _prev; }
            set { _prev = value; }
        }

    }

}
