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
        /// Adds a node with specified value to the tail of the SinglyLinkedListCollection.
        /// </summary>
        /// <param name="value"><typeparamref name="T"/> of node.</param>
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
        /// Adds a node with the specified value to the head of the SinglyLinkedListCollection.
        /// </summary>
        /// <param name="value"><typeparamref name="T"/> of node.</param>
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
        /// IsEmpty returns true if the SinglyLinkedListCollection is empty or false otherwise.
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty() {
            return _head == null;
        }

        /// <summary>
        /// ToArray converts the SinglyLinkedListCollection to an array of type T.
        /// </summary>
        /// <returns>An array of type T containing all the values of the nodes in the SinglyLinkedListCollection.</returns>
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
        /// Removes the head node from the SinglyLinkedListCollection.
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
        /// Get's node at the Head of the SinglyLinkedListCollection.
        /// </summary>
        public SinglyLinkedListNode<T> Head {
            get { return _head; }
        }

        /// <summary>
        /// Get's the node at the Tail of the SinglyLinkedListCollection.
        /// </summary>
        public SinglyLinkedListNode<T> Tail {
            get { return _tail; }
        }

        #region IEnumerable<T> Members

        /// <summary>
        /// GetEnumerator provides simple iteration over the SinglyLinkedListCollection by 
        /// returning a generic IEnumerator object.
        /// </summary>
        /// <returns></returns>
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
        /// GetEnumerator (non generic) calls the generic GetEnumerator.
        /// </summary>
        /// <returns></returns>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        #endregion

        #region ICollection<T> Members

        /// <summary>
        /// Adds a node with specified value to the tail of the SinglyLinkedListCollection.
        /// </summary>
        /// <param name="item"><typeparamref name="T"/> of node.</param>
        public void Add(T item) {
            AddLast(item);
        }

        /// <summary>
        /// Clears the SinglyLinkedListCollection retuning the object to its default state.
        /// </summary>
        public void Clear() {
            _head = null;
            _tail = null;
            _count = 0;
        }

        /// <summary>
        /// Contains checks whether the item is in the SinglyLinkedListCollection.
        /// </summary>
        /// <param name="item"><typeparamref name="T"/> item.</param>
        /// <returns>True if the item is in the collection, false otherwise.</returns>
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
        /// Copies all the node values in the SinglyLinkedListCollection to the provided array.
        /// </summary>
        /// <param name="array"><typeparamref name="T"/> array to copy values to.</param>
        public void CopyTo(T[] array) {
            Array.Copy(ToArray(), array, _count);
        }

        /// <summary>
        /// Copies all the node values in the SinglyLinkedListCollection to an array beginning at a user specified index.
        /// </summary>
        /// <param name="array"><typeparamref name="T"/> array to populate.</param>
        /// <param name="arrayIndex"> index of array to start populating at.</param>
        public void CopyTo(T[] array, int arrayIndex) {
            Array.Copy(ToArray(), 0, array, arrayIndex, _count);
        }

        public bool Remove(T item) {
            throw new NotImplementedException();
        }

        /// <summary>
        /// IsReadOnly returns false.  The SinglyLinkedListCollection is not readonly.
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
