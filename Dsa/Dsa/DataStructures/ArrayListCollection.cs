using System;
using System.Collections;
using System.Collections.Generic;

namespace Dsa.DataStructures {
    
    public class ArrayListCollection<T> : ICollection<T>, IList, IList<T> {

        private int _count;
        private int _capacity = 4;
        private T[] _items;

        /// <summary>
        /// Initializes a new instance of the ArrayListCollection class that is empty and has the default initial capacity.
        /// </summary>
        public ArrayListCollection() {
            _items = new T[_capacity];
        }

        /// <summary>
        /// Adds a value to the end of the ArrayListCollection(Of T).
        /// </summary>
        /// <param name="value">Value to add to the ArrayListCollection(Of T).</param>
        /// <returns>The index of the ArrayListCollection(Of T) the value was added to.</returns>
        public int Add(T value) {
            if (_count == _capacity) {
                Array.Resize<T>(ref _items, _capacity *= 2);
            }
            _items[_count] = value;
            return _count++;
        }

        /// <summary>
        /// Gets the capacity of the ArrayListCollection(Of T).
        /// </summary>
        public int Capacity {
            get { return _capacity; }
        }

        #region IList Members

        /// <summary>
        /// Adds a value to the end of the ArrayListCollection(Of T).
        /// </summary>
        /// <param name="value">Value to add to the ArrayListCollection(Of T).</param>
        /// <returns>The index of the ArrayListCollection(Of T) the value was added to.</returns>
        int IList.Add(object value) {
            throw new System.NotImplementedException();
        }

        void IList.Clear() {
            throw new System.NotImplementedException();
        }

        bool IList.Contains(object value) {
            throw new System.NotImplementedException();
        }

        int IList.IndexOf(object value) {
            throw new System.NotImplementedException();
        }

        void IList.Insert(int index, object value) {
            throw new System.NotImplementedException();
        }

        bool IList.IsFixedSize {
            get { throw new System.NotImplementedException(); }
        }

        bool IList.IsReadOnly {
            get { throw new System.NotImplementedException(); }
        }

        void IList.Remove(object value) {
            throw new System.NotImplementedException();
        }

        void IList.RemoveAt(int index) {
            throw new System.NotImplementedException();
        }

        object IList.this[int index] {
            get {
                throw new System.NotImplementedException();
            }
            set {
                throw new System.NotImplementedException();
            }
        }

        #endregion

        #region ICollection<T> Members

        void ICollection<T>.Add(T item) {
            throw new System.NotImplementedException();
        }

        void ICollection<T>.Clear() {
            throw new System.NotImplementedException();
        }

        bool ICollection<T>.Contains(T item) {
            throw new System.NotImplementedException();
        }

        void ICollection<T>.CopyTo(T[] array, int arrayIndex) {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Gets the number of elements contained in the ICollection(Of T).
        /// </summary>
        public int Count {
            get { return _count; }
        }

        bool ICollection<T>.IsReadOnly {
            get { throw new System.NotImplementedException(); }
        }

        bool ICollection<T>.Remove(T item) {
            throw new System.NotImplementedException();
        }

        #endregion

        #region IEnumerable<T> Members

        IEnumerator<T> IEnumerable<T>.GetEnumerator() {
            throw new System.NotImplementedException();
        }

        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
            throw new System.NotImplementedException();
        }

        #endregion

        #region ICollection Members

        void ICollection.CopyTo(System.Array array, int index) {
            throw new System.NotImplementedException();
        }

        bool ICollection.IsSynchronized {
            get { throw new System.NotImplementedException(); }
        }

        object ICollection.SyncRoot {
            get { throw new System.NotImplementedException(); }
        }

        #endregion

        #region IList<T> Members

        /// <summary>
        /// Searches for the specified object and returns the zero-based index of the first occurrence within the entire ArrayListCollection(Of T).
        /// </summary>
        /// <param name="item">The object to locate in the ArrayListCollection(Of T). The value can be null for reference types.</param>
        /// <returns>The zero-based index of the first occurrence of item within the entire ArrayListCollection(Of T), if found; otherwise, –1.</returns>
        public int IndexOf(T item) {
            return Array.IndexOf(_items, item);
        }

        void IList<T>.Insert(int index, T item) {
            throw new NotImplementedException();
        }

        void IList<T>.RemoveAt(int index) {
            throw new NotImplementedException();
        }

        T IList<T>.this[int index] {
            get {
                throw new NotImplementedException();
            }
            set {
                throw new NotImplementedException();
            }
        }

        #endregion

        #region ICollection<T> Members


        int ICollection<T>.Count {
            get { throw new NotImplementedException(); }
        }

        #endregion
    }

}
