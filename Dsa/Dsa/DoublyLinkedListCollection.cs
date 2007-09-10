using System;
using Dsa.Properties;

namespace Dsa.DataStructures {

    /// <summary>
    /// DoublyLinkedListCollection(Of T).
    /// </summary>
    /// <typeparam name="T">Type of collection.</typeparam>
    public class DoublyLinkedListCollection<T> {

        private DoublyLinkedListNode<T> _head;
        private DoublyLinkedListNode<T> _tail;

        /// <summary>
        /// Adds a node to the tail of the DoublyLinkedListCollection(Of T).
        /// </summary>
        /// <param name="value">Value to add to the DoublyLinkedListCollection(Of T).</param>
        public void AddLast(T value) {
            DoublyLinkedListNode<T> n = new DoublyLinkedListNode<T>(value);
            if (IsEmpty()) {
                _head = n;
                _tail = n;
            }
            else {
                _tail.Next = n;
                n.Prev = _tail;
                _tail = n;
            }
        }

        /// <summary>
        /// Adds a node to the head of the DoublyLinkedListCollection(Of T).
        /// </summary>
        /// <param name="value">Value to add to the DoublyLinkedListCollection(Of T).</param>
        public void AddFirst(T value) {
            DoublyLinkedListNode<T> n = new DoublyLinkedListNode<T>(value);
            if (IsEmpty()) {
                _head = n;
                _tail = n;
            }
            else {
                _head.Prev = n;
                n.Next = _head;
                _head = n;
            }
        }

        /// <summary>
        /// Adds a node after a specified node in the DoublyLinkedListCollection(Of T).
        /// </summary>
        /// <param name="node">The node to add after.</param>
        /// <param name="value">The value of the node to add after the specified node.</param>
        public void AddAfter(DoublyLinkedListNode<T> node, T value) {
            if (IsEmpty()) {
                throw new InvalidOperationException(Resources.DoublyLinkedListEmpty);
            }
            else if (node == null) {
                throw new ArgumentNullException("node");
            }
            DoublyLinkedListNode<T> n = new DoublyLinkedListNode<T>(value);
            if (node == _tail) {
                n.Prev = _tail;
                _tail.Next = n;
                _tail = n;
            }
            else {
                n.Next = node.Next;
                n.Next.Prev = n;
                node.Next = n;
                n.Prev = node;
            }
        }

        /// <summary>
        /// Indicates whether the DoublyLinkedListCollection(Of T) is empty or not.
        /// </summary>
        /// <returns>Returns true if the DoublyLinkedListCollection(Of T) is empty, or false otherwise.</returns>
        public bool IsEmpty() {
            return _head == null;
        }

        /// <summary>
        /// Gets the node at the head of the DoublyLinkedListCollection(Of T).
        /// </summary>
        public DoublyLinkedListNode<T> Head {
            get { return _head; }
        }

        /// <summary>
        /// Gets the node at the end of the DoublyLinkedListCollection(Of T).
        /// </summary>
        public DoublyLinkedListNode<T> Tail {
            get { return _tail; }
        }

    }

}
