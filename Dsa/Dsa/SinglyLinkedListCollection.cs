using System;
using System.Collections.Generic;
using Dsa.Properties;

namespace Dsa.DataStructures {

    /// <summary>
    /// SinglyLinkedList.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed class SinglyLinkedListCollection<T> : IEnumerable<T> {

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
        /// ToArray converts the singly linked list to an array of type T.
        /// </summary>
        /// <returns>An array of type T containing all the values of the nodes in the singly linked list.</returns>
        public T[] ToArray() {
            if (IsEmpty()) {
                throw new InvalidOperationException("ToArray cannot be called on a SinglyLinkedList object that contains 0 nodes.");
            }
            else {
                int curr = 0; // index of array at which current nodes value is stored
                T[] arrayResult = new T[_count];
                SinglyLinkedListNode<T> n = _head;
                while (n != null) {
                    arrayResult[curr] = n.Value;
                    n = n.Next;
                    curr++;
                }
                return arrayResult;
            }
        }

        /// <summary>
        /// Removes the last node from the singly linked list.
        /// </summary>
        public void RemoveLast() {
            if (IsEmpty()) {
                throw new InvalidOperationException(Resources.SinglyLinkedListEmpty);
            }
            else {
                if (_head.Next == null) {
                    // only one node in the singly linked list
                    _head = null;
                    _tail = null;
                }
                else {
                    // traverse singly linked list until we find the tail
                    SinglyLinkedListNode<T> n = _head;
                    while (n != null) {
                        if (n.Next == _tail) {
                            _tail = n;
                            _tail.Next = null;
                            break;
                        }
                        n = n.Next;
                    }
                }
                _count--;
            }
        }

        /// <summary>
        /// Removes the head node from the singly linked list.
        /// </summary>
        public void RemoveFirst() {
            if (IsEmpty()) {
                throw new InvalidOperationException(Resources.SinglyLinkedListEmpty);
            }
            else {
                if (_head.Next == null) {
                    _head = null;
                    _tail = null;
                }
                else {
                    _head = _head.Next;
                }
                _count--;
            }
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


        #region IEnumerable<T> Members

        public IEnumerator<T> GetEnumerator() {
            SinglyLinkedListNode<T> n = Head;
            while (n != null) {
                yield return n.Value;
                n = n.Next;
            }
        }

        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        #endregion
    }

}
