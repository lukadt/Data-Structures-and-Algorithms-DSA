using System;
using System.Collections.Generic;
using Dsa.Properties;

namespace Dsa.DataStructures {

    /// <summary>
    /// Dsa.DataStructures.SinglyLinkedListCollection.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed class SinglyLinkedListCollection<T> : IEnumerable<T>, ICollection<T> {

        private SinglyLinkedListNode<T> _head;
        private SinglyLinkedListNode<T> _tail;
        private int _count;

        /// <summary>
        /// Adds a node to the tail of the SinglyLinkedListCollection.
        /// </summary>
        /// <param name="item">Item to add to the SinglyLinkedListCollection.</param>
        public void AddLast(T item) {
            SinglyLinkedListNode<T> n = new SinglyLinkedListNode<T>(item);
            if (IsEmpty()) {
                // this is the first node in the SinglyLinkedListCollection, head and tail point to the same node
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
        /// Adds a node to the head of the SinglyLinkedListCollection.
        /// </summary>
        /// <param name="item">Item to add to the SinglyLinkedListCollection.</param>
        public void AddFirst(T item) {
            SinglyLinkedListNode<T> n = new SinglyLinkedListNode<T>(item);
            if (IsEmpty()) {
                // this is the first node in the SinglyLinkedListCollection, head and tail point to the same node
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
        /// Adds a node after the specified node with the value of item.
        /// </summary>
        /// <param name="node">Node in SinglyLinkedListCollection to add node after.</param>
        /// <param name="item">Item to add to SinglyLinkedListCollection.</param>
        public void AddAfter(SinglyLinkedListNode<T> node, T item) {
            if (IsEmpty()) {
                throw new InvalidOperationException(Resources.SinglyLinkedListEmpty);
            }
            if (node == null) {
                throw new ArgumentNullException("node");
            }
            else {
                SinglyLinkedListNode<T> n = new SinglyLinkedListNode<T>(item);
                if (node == _head && node == _tail) {
                    // node passed in is the only node in the SinglyLinkedListCollection
                    _head.Next = n;
                    _tail = n;
                }
                else if (node == _tail) {
                    // node passed in is the tail node
                    _tail.Next = n;
                    _tail = n;
                }
                else {
                    n.Next = node.Next;
                    node.Next = n;
                }
                _count++;
            }
        }

        /// <summary>
        /// Adds a node before the specified node with the value of the item.
        /// </summary>
        /// <param name="node">Node in the SinglyLinkedListCollection to add node before.</param>
        /// <param name="item">Item to add to the SinglyLinkedListCollection.</param>
        public void AddBefore(SinglyLinkedListNode<T> node, T item) {
            if (IsEmpty()) {
                throw new InvalidOperationException(Resources.SinglyLinkedListEmpty);
            }
            if (node == null) {
                throw new ArgumentNullException("node");
            }
            else {
                SinglyLinkedListNode<T> n = new SinglyLinkedListNode<T>(item);
                if (node == _head) {
                    // we are adding a node before the head node
                    n.Next = _head;
                    _head = n;
                }
                else {
                    SinglyLinkedListNode<T> curr = _head;
                    while (curr != null) {
                        if (curr.Next == node) {
                            n.Next = node;
                            curr.Next = n;
                            break;
                        }
                        curr = curr.Next;
                    }
                }
                _count++;
            }
        }

        /// <summary>
        /// Determines whether the SinglyLinkedListCollection is empty.
        /// </summary>
        /// <returns>True if the SinglyLinkedListCollection is empty, false otherwise.</returns>
        public bool IsEmpty() {
            return _head == null;
        }

        /// <summary>
        /// Converts the SinglyLinkedListCollection and its items to an array.
        /// </summary>
        /// <returns>An array containing the items from the SinglyLinkedListCollection.</returns>
        public T[] ToArray() {
            if (IsEmpty()) {
                throw new InvalidOperationException(Resources.SinglyLinkedListEmpty);
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
        /// Removes the last node from the SinglyLinkedListCollection.
        /// </summary>
        public void RemoveLast() {
            if (IsEmpty()) {
                throw new InvalidOperationException(Resources.SinglyLinkedListEmpty);
            }
            else {
                if (_head.Next == null) {
                    // only one node in the SinglyLinkedListCollection
                    _head = null;
                    _tail = null;
                }
                else {
                    // traverse SinglyLinkedListCollection until we find the tail
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
        /// Removes the first node from the SinglyLinkedListCollection.
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
        /// Get's the node at the head of the SinglyLinkedListCollection.
        /// </summary>
        public SinglyLinkedListNode<T> Head {
            get { return _head; }
        }

        /// <summary>
        /// Get's the node at the tail of the SinglyLinkedListCollection.
        /// </summary>
        public SinglyLinkedListNode<T> Tail {
            get { return _tail; }
        }

        #region IEnumerable<T> Members

        /// <summary>
        /// Returns an enumerator that iterates through the SinglyLinkedListCollection.
        /// </summary>
        /// <returns>A generic IEnumerator object.</returns>
        public IEnumerator<T> GetEnumerator() {
            SinglyLinkedListNode<T> n = Head;
            while (n != null) {
                yield return n.Value;
                n = n.Next;
            }
        }

        #endregion

        #region IEnumerable Members

        /// <summary>
        /// Returns an enumerator that iterates through the SinglyLinkedListCollection.
        /// </summary>
        /// <returns>An IEnumerator object.</returns>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        #endregion

        #region ICollection<T> Members

        /// <summary>
        /// Adds a node to the tail of the SinglyLinkedListCollection.
        /// </summary>
        /// <param name="item">Item to add to the SinglyLinkedListCollection.</param>
        public void Add(T item) {
            AddLast(item);
        }

        /// <summary>
        /// Removes all the nodes from the SinglyLinkedListCollection.
        /// </summary>
        public void Clear() {
            _head = null;
            _tail = null;
            _count = 0;
        }

        /// <summary>
        /// Determines whether a value is in the SinglyLinkedListCollection.
        /// </summary>
        /// <param name="item">Value to search for.</param>
        /// <returns>True if the value is in the collection, false otherwise.</returns>
        public bool Contains(T item) {
            SinglyLinkedListNode<T> n = _head;
            EqualityComparer<T> comparer = EqualityComparer<T>.Default;
            while (n != null) {
                if (comparer.Equals(n.Value, item)) {
                    return true;
                }
                n = n.Next;
            }
            return false;
        }

        /// <summary>
        /// Copies the entire SinglyLinkedListCollection to a compatible one-dimensional Array.
        /// </summary>
        /// <param name="array">Array to copy SinglyLinkedListCollection to.</param>
        public void CopyTo(T[] array) {
            Array.Copy(ToArray(), array, _count);
        }

        /// <summary>
        /// Copies the entire SinglyLinkedListCollection to a compatible one-dimensional Array, starting at the specified index of the target array.
        /// </summary>
        /// <param name="array">Array to copy SinglyLinkedListCollection to.</param>
        /// <param name="arrayIndex">Index of array to start copying to.</param>
        public void CopyTo(T[] array, int arrayIndex) {
            Array.Copy(ToArray(), 0, array, arrayIndex, _count);
        }

        /// <summary>
        /// Removes the first occurrence of a value from the SinglyLinkedListCollection.
        /// </summary>
        /// <param name="item">Value to remove</param>
        /// <returns>True if the value was found and removed, false otherwise.</returns>
        public bool Remove(T item) {
            if (IsEmpty()) {
                throw new InvalidOperationException(Resources.SinglyLinkedListEmpty);
            }
            else {
                SinglyLinkedListNode<T> n = _head;
                EqualityComparer<T> comparer = EqualityComparer<T>.Default;
                if (comparer.Equals(n.Value, item)) {
                    // node to be removed is the head node
                    if (n == _tail) {
                        _tail = null; // n is head and tail, make tail null
                    }
                    // if n was the only node in the list then head is now null as well as tail, if not head has been updated to its next node
                    _head = _head.Next; 
                    _count--;
                    return true;
                }
                else {
                    while (n != null) {
                        if (!comparer.Equals(n.Value, item) && n.Next == null) {
                            // check the last nodes value for item, if its not equal then we are searching for something that is not present
                            return false;
                        }
                        else if (comparer.Equals(n.Next.Value, item)) {
                            if (n.Next == _tail) {
                                // the node to be removed was the tail so we need to make n the new tail
                                _tail = n;
                                n.Next = null;
                                _count--;
                                return true;
                            }
                            else {
                                n.Next = n.Next.Next;
                                _count--;
                                return true;
                            }
                        }
                        else {
                            n = n.Next;
                        }
                    }
                    return false;
                }
            }
        }

        /// <summary>
        /// Determines whether the SinglyLinkedListCollection is readonly.
        /// </summary>
        public bool IsReadOnly {
            get { return false; }
        }

        /// <summary>
        /// Get's the count of nodes in the SinglyLinkedListCollection.
        /// </summary>
        public int Count {
            get { return _count; }
        }

        #endregion

    }

}
