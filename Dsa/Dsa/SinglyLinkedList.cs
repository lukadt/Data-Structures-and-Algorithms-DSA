namespace Dsa.DataStructures {

    /// <summary>
    /// SinglyLinkedList.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SinglyLinkedList<T> {

        private SinglyLinkedListNode<T> _head;
        private SinglyLinkedListNode<T> _tail;
        private int _count;

        /// <summary>
        /// Adds a node with specified value to the tail of the linked list.
        /// </summary>
        /// <param name="value"><typeparamref name="T"/> of node.</param>
        public void AddLast(T value) {
            SinglyLinkedListNode<T> n = new SinglyLinkedListNode<T>(value);
            if (IsEmpty()) {
                // this is the first node in the list, head and tail point to the same node
                _head = n;
                _tail = n;
            }
            else {
                _tail.Next = n;
                _tail = n;
            }
            _count++;
        }

        /// <summary>
        /// Adds a node with the specified value to the head of the linked list.
        /// </summary>
        /// <param name="value"><typeparamref name="T"/> of node.</param>
        public void AddFirst(T value) {
            SinglyLinkedListNode<T> n = new SinglyLinkedListNode<T>(value);
            if (IsEmpty()) {
                // this is the first node in the list, head and tail point to the same node
                _head = n;
                _tail = n;
            }
            else {
                n.Next = _head;
                _head = n;
            }
            _count++;
        }

        /// <summary>
        /// IsEmpty returns true if the SinglyLinkedList is empty or false otherwise.
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty() {
            return _head == null;
        }

        /// <summary>
        /// Get's node at the Head of the linked list.
        /// </summary>
        public SinglyLinkedListNode<T> Head {
            get { return _head; }
        }

        /// <summary>
        /// Get's the node at the Tail of the linked list.
        /// </summary>
        public SinglyLinkedListNode<T> Tail {
            get { return _tail; }
        }

        /// <summary>
        /// Get's the count of nodes in the linked list.
        /// </summary>
        public int Count {
            get { return _count; }
        }

    }

}
