using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using Dsa.Properties;

namespace Dsa.DataStructures {

    /// <summary>
    /// DoublyLinkedListCollection(Of T).
    /// </summary>
    /// <typeparam name="T">Type of collection.</typeparam>
    [Serializable]
    [DebuggerDisplay("Count={Count}")]
    [DebuggerTypeProxy(typeof(CollectionDebugView<>))]
    public sealed class DoublyLinkedListCollection<T> : ICollection<T>, ICollection where T: IEquatable<T> {

        [NonSerialized]
        private DoublyLinkedListNode<T> _head;
        [NonSerialized]
        private DoublyLinkedListNode<T> _tail;
        [NonSerialized]
        private int _count;
        [NonSerialized]
        private object _syncRoot;

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
            _count++;
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
            _count++;
        }

        /// <summary>
        /// Adds a node after a specified node in the DoublyLinkedListCollection(Of T).
        /// </summary>
        /// <param name="node">The node to add after.</param>
        /// <param name="value">The value of the node to add after the specified node.</param>
        public void AddAfter(DoublyLinkedListNode<T> node, T value) {
            validateAddArgs(node);
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
            _count++;
        }

        /// <summary>
        /// Adds a node before a specified node in the DoublyLinkedListCollection(Of T).
        /// </summary>
        /// <param name="node">The node to add before.</param>
        /// <param name="value">The value of the node to add after the specified node.</param>
        public void AddBefore(DoublyLinkedListNode<T> node, T value) {
            validateAddArgs(node);
            DoublyLinkedListNode<T> n = new DoublyLinkedListNode<T>(value);
            if (node == _head) {
                n.Next = _head;
                _head.Prev = n;
                _head = n;
            }
            else {
                n.Next = node;
                node.Prev.Next = n;
                n.Prev = node.Prev;
                node.Prev = n;
            }
            _count++;
        }

        /// <summary>
        /// Removes a node from the tail of the DoublyLinkedListCollection(Of T).
        /// </summary>
        public void RemoveLast() {
            if (IsEmpty()) {
                throw new InvalidOperationException(Resources.DoublyLinkedListEmpty);
            }
            if (_tail == _head) {
                _head = null;
                _tail = null;
            }
            else if (_head.Next == _tail) {
                _tail = _head;
                _head.Next = null;
            }
            else {
                _tail = _tail.Prev;
                _tail.Next = null;
            }
            _count--;
        }

        /// <summary>
        /// Removes the node at the head of the DoublyLinkedListCollection(Of T).
        /// </summary>
        public void RemoveFirst() {
            if (IsEmpty()) {
                throw new InvalidOperationException(Resources.DoublyLinkedListEmpty);
            }
            if (_head.Next == null) {
                _head = null;
                _tail = null;
            }
            else if (_head.Next == _tail) {
                _head = _tail;
                _head.Prev = null;
            }
            else {
                _head = _head.Next;
                _head.Prev = null;
            }
            _count--;
        }

        /// <summary>
        /// Returns an array containing all the values of the nodes contained within the DoublyLinkedListCollection(Of T).
        /// </summary>
        /// <returns>Array containing the values of the nodes contained in the DoublyLinkedListCollection(Of T).</returns>
        public T[] ToArray() {
            if (IsEmpty()) {
                throw new InvalidOperationException(Resources.DoublyLinkedListEmpty);
            }
            int index = 0;
            T[] resultArray = new T[_count];
            foreach (T value in this) {
                resultArray[index] = value;
                index++;
            }
            return resultArray;
        }

        /// <summary>
        /// Method that validates the state of the DoublyLinkedListCollection(Of T) as well as if the node passed in is null.
        /// This method is used by AddAfter, and AddBefore.
        /// </summary>
        /// <param name="node">Node to verify whether or not is null.</param>
        private void validateAddArgs(DoublyLinkedListNode<T> node) {
            if (IsEmpty()) {
                throw new InvalidOperationException(Resources.DoublyLinkedListEmpty);
            }
            else if (node == null) {
                throw new ArgumentNullException("node");
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


        #region ICollection<T> Members

        /// <summary>
        /// Adds an item to the DoublyLinkedListCollection(Of T).
        /// </summary>
        /// <param name="item">Item to add to the DoublyLinkedListCollection(Of T).</param>
        void ICollection<T>.Add(T item) {
            AddLast(item);
        }

        /// <summary>
        /// Removes all nodes from the DoublyLinkedListCollection(Of T).
        /// </summary>
        public void Clear() {
            _head = null;
            _tail = null;
            _count = 0;
        }

        /// <summary>
        /// Determines whether a value is in the DoublyLinkedListCollection(Of T).
        /// </summary>
        /// <param name="item">Value to search the DoublyLinkedListCollection(Of T) for.</param>
        /// <returns>True if the value was found, false otherwise.</returns>
        public bool Contains(T item) {
            EqualityComparer<T> comparer = EqualityComparer<T>.Default;
            foreach (T value in this) {
                if (comparer.Equals(value, item)) return true;
            }
            return false;
        }

        /// <summary>
        /// Copies the entire DoublyLinkedListCollection(Of T) to a compatible one-dimensional Array, starting at the specified index of the target array.
        /// </summary>
        /// <param name="array">Array to copy values of DoublyLinkedListCollection(Of T) to.</param>
        /// <param name="arrayIndex">Index of array to start copying to.</param>
        public void CopyTo(T[] array, int arrayIndex) {
            Array.Copy(ToArray(), array, _count);
        }

        /// <summary>
        /// Gets the number of nodes contained in the DoublyLinkedListCollection(Of T).
        /// </summary>
        public int Count {
            get { return _count; }
        }

        /// <summary>
        /// Gets whether or not the DoublyLinkedListCollection(Of T) is readonly.
        /// </summary>
        bool ICollection<T>.IsReadOnly {
            get { return false; }
        }

        /// <summary>
        /// Removes the first occurrence of a value from the DoublyLinkedListCollection(Of T).
        /// </summary>
        /// <param name="item">Value to remove from the DoublyLinkedListCollection(Of T) if found.</param>
        /// <returns>True if the value was found in the DoublyLinkedListCollection(Of T) and removed, false otherwise.</returns>
        public bool Remove(T item) {
            if (IsEmpty()) {
                throw new InvalidOperationException(Resources.DoublyLinkedListEmpty);
            }
            EqualityComparer<T> comparer = EqualityComparer<T>.Default;
            if (_head.Next == null && comparer.Equals(_head.Value, item)) {
                _head = null;
                _tail = null;
                _count--;
                return true;
            }
            else if (_head.Next == _tail) {
                if (comparer.Equals(_head.Value, item)) {
                    _head = _head.Next;
                    _head.Prev = null;
                    _count--;
                    return true;
                }
                else if (comparer.Equals(_tail.Value, item)) {
                    _tail = _head;
                    _head.Next = null;
                    _count--;
                    return true;
                }
            }
            else {
                DoublyLinkedListNode<T> n = _head;
                while (n != null) {
                    if (comparer.Equals(n.Value, item)) {
                        if (n == _head) {
                            _head = _head.Next;
                            _head.Prev = null;
                        }
                        else if (n == _tail) {
                            _tail = _tail.Prev;
                            _tail.Next = null;
                        }
                        else {
                            n.Prev.Next = n.Next;
                            n.Next.Prev = n.Prev;
                        }
                        _count--;
                        return true;
                    }
                    n = n.Next;
                }
            }
            return false;
        }

        #endregion

        #region IEnumerable<T> Members

        /// <summary>
        /// Returns an enumerator that iterates through the DoublyLinkedListCollection(Of T).
        /// </summary>
        /// <returns>IEnumerator(Of T).</returns>
        public IEnumerator<T> GetEnumerator() {
            DoublyLinkedListNode<T> n = _head;
            while (n != null) {
                yield return n.Value;
                n = n.Next;
            }
        }

        #endregion

        #region IEnumerable Members

        /// <summary>
        /// Returns an enumerator that iterates through the DoublyLinkedListCollection(Of T).
        /// </summary>
        /// <returns>IEnumerator.</returns>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        #endregion

        #region ICollection Members

        /// <summary>
        /// Copies the elements of the ICollection to an Array, starting at a particular Array index.
        /// </summary>
        /// <param name="array">Array to copy elements to.</param>
        /// <param name="index">Index of array to start copying to.</param>
        void ICollection.CopyTo(Array array, int index) {
            throw new NotSupportedException(Resources.ICollectionCopyToNotSupported);
        }

        /// <summary>
        /// Gets a value indicating whether access to the ICollection is synchronized (thread safe).
        /// </summary>
        bool ICollection.IsSynchronized {
            get { return false; }
        }

        /// <summary>
        /// Gets an object that can be used to synchronize access to the ICollection.
        /// </summary>
        object ICollection.SyncRoot {
            get {
                if (_syncRoot == null) {
                    Interlocked.CompareExchange(ref _syncRoot, new object(), null);
                }
                return _syncRoot;
            }
        }

        #endregion
    }

}
