using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using Dsa.Properties;

namespace Dsa.DataStructures {
    
    /// <summary>
    /// ArrayListCollection(Of T).
    /// </summary>
    /// <typeparam name="T">Type of items to be stored in the ArrayListCollection(Of T).</typeparam>
    [Serializable]
    [DebuggerDisplay("Count={Count}")]
    [DebuggerTypeProxy(typeof(CollectionDebugView<>))]
    public sealed class ArrayListCollection<T> : ICollection<T>, ICollection, IList, IList<T> where T: IEquatable<T> {

        [NonSerialized]
        private int _currentIndex;
        [NonSerialized]
        private int _count;
        [NonSerialized]
        private int _capacity = 4;
        [NonSerialized]
        private T[] _items;
        [NonSerialized]
        private object _syncRoot;

        /// <summary>
        /// Initializes a new instance of the ArrayListCollection class that is empty and has the default initial capacity.
        /// </summary>
        public ArrayListCollection() { // t: a constructor that allows you to set the default size.
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
            EqualityComparer<T> comparer = EqualityComparer<T>.Default;
            while (!comparer.Equals(_items[_currentIndex], default(T))) _currentIndex++;
            _count++;
            _items[_currentIndex] = value;
            return _currentIndex++;
        }

        /// <summary>
        /// Gets the capacity of the ArrayListCollection(Of T).
        /// </summary>
        public int Capacity {
            get { return _capacity; }
        }

        /// <summary>
        /// Helper method to detect whether or not the index specified is within range
        /// of the items array.
        /// </summary>
        /// <param name="index">Index of items array to access.</param>
        /// <returns>True if the index within the range of the array; otherwise false.</returns>
        private bool isInRange(int index) {
            return (index < 0 || index > _items.Length - 1) ? false : true;
        }

        /// <summary>
        /// Checks to see if the object is compatiable with this colleciton.
        /// The object must be of type T, not null and not a value type.
        /// </summary>
        /// <param name="value">Value of object.</param>
        /// <returns>True if the object can be safely casted to type T; otherwise false.</returns>
        private static bool isCompatibleType(object value) {
            return (!(value is T) || value == null || typeof(T).IsValueType) ? false : true;
        }

        #region IList Members

        /// <summary>
        /// Adds a value to the end of the ArrayListCollection(Of T).
        /// </summary>
        /// <param name="value">Value to add to the ArrayListCollection(Of T).  Must be a reference type that is the same
        /// as T or a derivitive of T and not null.</param>
        /// <returns>The index of the ArrayListCollection(Of T) the value was added to.</returns>
        int IList.Add(object value) {
            if (!isCompatibleType(value)) {
                throw new ArgumentException(Resources.TypeNotCompatible);
            }
            return Add((T)value);
        }

        /// <summary>
        /// Determines whether the IList contains a specific value.
        /// </summary>
        /// <param name="value">Value to locate in the IList.</param>
        /// <returns>True if the value was located in the IList; otherwise false.</returns>
        bool IList.Contains(object value) {
            if (!isCompatibleType(value)) {
                throw new ArgumentException(Resources.TypeNotCompatible);
            }
            return IndexOf((T)value) < 0 ? false : true;
        }

        /// <summary>
        /// Searches for the specified object and returns the zero-based index of the first occurrence within the entire IList.
        /// </summary>
        /// <param name="value">The object to locate in the IList.</param>
        /// <returns>The zero-based index of the first occurrence of item within the entire IList, if found; otherwise, –1.</returns>
        int IList.IndexOf(object value) {
            if (!isCompatibleType(value)) {
                throw new ArgumentException(Resources.TypeNotCompatible);
            }
            return IndexOf((T)value);
        }

        /// <summary>
        /// Inserts an element into the IList at the specified index.
        /// </summary>
        /// <param name="index">Index to insert item at.</param>
        /// <param name="value">Value to insert into the IList.</param>
        void IList.Insert(int index, object value) {
            if (!isCompatibleType(value)) {
                throw new ArgumentException(Resources.TypeNotCompatible);
            }
            Insert(index, (T)value);
        }

        /// <summary>
        /// Gets a value indicating whether the IList has a fixed size.
        /// </summary>
        bool IList.IsFixedSize {
            get { return false; }
        }

        /// <summary>
        /// Removes the first occurrence of a specific value from the IList.
        /// </summary>
        /// <param name="value">Value to remove.</param>
        void IList.Remove(object value) {
            if (!isCompatibleType(value)) {
                throw new ArgumentException(Resources.TypeNotCompatible);
            }
            Remove((T)value);
        }

        /// <summary>
        /// Removes the element at the specified index of the IList.
        /// </summary>
        /// <param name="index">Index of item to remove.</param>
        void IList.RemoveAt(int index) {
            RemoveAt(index);
        }

        /// <summary>
        /// Gets or sets the element at the specified index in IList.
        /// </summary>
        /// <param name="index">Index of item to get or set.</param>
        /// <returns>Item at the specified index.</returns>
        object IList.this[int index] {
            get {
                return this[index];
            }
            set {
                if (!isCompatibleType(value)) {
                    throw new ArgumentException(Resources.TypeNotCompatible);
                }
                this[index] = (T)value;
            }
        }

        #endregion

        #region ICollection<T> Members

        /// <summary>
        /// Adds an item to the ICollection(Of T).
        /// </summary>
        /// <param name="item">Item to add to the ICollection(Of T).</param>
        void ICollection<T>.Add(T item) {
            Add(item);
        }

        /// <summary>
        /// Removes all elements from the ArrayListCollection(Of T).
        /// Does not change the capacity to its default size.
        /// </summary>
        public void Clear() {
            for (int i = 0; i < _count; i++) {
                _items[i] = default(T);
            }
            _count = 0;
        }

        /// <summary>
        /// Determines whether an element is in the ArrayListCollection(Of T).
        /// </summary>
        /// <param name="item">Item to locate in the ArrayListCollection(Of T).</param>
        /// <returns>True if the item was located; otherwise false.</returns>
        public bool Contains(T item) {
            return IndexOf(item) < 0 ? false : true;
        }

        /// <summary>
        /// Copies the entire ArrayListCollection(Of T) to a compatible one-dimensional Array, starting at the specified index of the target array.
        /// </summary>
        /// <param name="array">One-dimensional array to copy ArrayListCollection(Of T) items to.</param>
        /// <param name="arrayIndex">Index of target array to start copy at.</param>
        public void CopyTo(T[] array, int arrayIndex) {
            Array.Copy(_items, 0, array, arrayIndex, _count);
        }

        /// <summary>
        /// Gets the number of elements contained in the ICollection(Of T).
        /// </summary>
        public int Count {
            get { return _count; }
        }

        /// <summary>
        /// Gets a value indicating whether the IList is read-only.
        /// </summary>
        public bool IsReadOnly {
            get { return false; }
        }

        /// <summary>
        /// Removes the first occurrence of a specific object from the ArrayListCollection(Of T).
        /// </summary>
        /// <param name="item">Item to remove.</param>
        /// <returns>Returns true if the item was found and removed; otherwise false.</returns>
        public bool Remove(T item) {
            if (IndexOf(item) < 0) return false;
            RemoveAt(IndexOf(item));
            return true;
        }

        #endregion

        #region IEnumerable<T> Members

        /// <summary>
        /// Returns an enumerator that iterates through the ArrayListCollection(Of T).
        /// </summary>
        /// <returns>IEnumerator(Of T).</returns>
        public IEnumerator<T> GetEnumerator() {
            EqualityComparer<T> comparer = EqualityComparer<T>.Default;
            for (int i = 0; i < _count; i++) {
                while (comparer.Equals(_items[i], default(T))) i++;
                yield return _items[i];
            }
        }

        #endregion

        #region IEnumerable Members

        /// <summary>
        /// Returns an enumerator that iterates through the IEnumerable.
        /// </summary>
        /// <returns>IEnumerator.</returns>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        #endregion

        #region ICollection Members

        /// <summary>
        /// Copies the entire ICollection to a compatible one-dimensional Array, starting at the specified index of the target array.
        /// </summary>
        /// <param name="array">One-dimensional array to copy ICollection items to.</param>
        /// <param name="index">Index of target array to start copy at.</param>
        void ICollection.CopyTo(System.Array array, int index) {
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

        #region IList<T> Members

        /// <summary>
        /// Searches for the specified object and returns the zero-based index of the first occurrence within the entire ArrayListCollection(Of T).
        /// </summary>
        /// <param name="item">The object to locate in the ArrayListCollection(Of T). The value can be null for reference types.</param>
        /// <returns>The zero-based index of the first occurrence of item within the entire ArrayListCollection(Of T), if found; otherwise, –1.</returns>
        public int IndexOf(T item) {
            return Array.IndexOf(_items, item);
        }

        /// <summary>
        /// Inserts an element into the ArrayListCollection(Of T) at the specified index.
        /// </summary>
        /// <param name="index">Index to insert item at.</param>
        /// <param name="item">Item to insert into the ArrayListCollection(Of T).</param>
        public void Insert(int index, T item) {
            if (isInRange(index)) {
                if (index < _currentIndex) {
                    _items[index] = item;
                }
                else {
                    _items[index] = item;
                    _count++;
                }
            }
            else {
                throw new ArgumentOutOfRangeException("index");
            }
        }

        /// <summary>
        /// Removes the element at the specified index of the ArrayListCollection(Of T).
        /// </summary>
        /// <param name="index">Index of item to remove.</param>
        public void RemoveAt(int index) {
            if (isInRange(index)) {
                _count--;
                _currentIndex--;
                if (index < _count) {
                    Array.Copy(_items, index + 1, _items, index, 1);
                }
                _items[_count] = default(T);
            }
            else {
                throw new ArgumentOutOfRangeException("index");
            }
        }

        /// <summary>
        /// Gets or sets the element at the specified index.
        /// </summary>
        /// <param name="index">Index of item to get or set.</param>
        /// <returns>Item at the specified index.</returns>
        public T this[int index] {
            get {
                return _items[index];
            }
            set {
                if (!(index < _count)) {
                    _count++;
                }
                _items[index] = value;
            }
        }

        #endregion

    }

}
