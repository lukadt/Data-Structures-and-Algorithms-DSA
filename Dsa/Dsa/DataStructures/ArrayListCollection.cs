using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using Dsa.Properties;

namespace Dsa.DataStructures
{

    /// <summary>
    /// An implementation of <see cref="List{T}"/>.
    /// </summary>
    /// <typeparam name="T">Type of items to be stored in the <see cref="ArrayListCollection{T}" />.</typeparam>
    [Serializable]
    [DebuggerDisplay("Count={Count}")]
    [DebuggerTypeProxy(typeof(CollectionDebugView<>))]
    public sealed class ArrayListCollection<T> : ComparerProvider<T>, IList, IList<T>
    {

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
        /// Initializes a new instance of the <see cref="ArrayListCollection{T}"/> class that is empty and has the default initial capacity of 4.
        /// </summary>
        public ArrayListCollection()
        { 
            _items = new T[_capacity];
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArrayListCollection{T}"/> class that is empty and has the default initial capacity of 4 with a 
        /// specified <see cref="IComparer{T}"/>.
        /// </summary>
        /// <param name="comparer">The comparer to use.</param>
        /// <exception cref="ArgumentNullException"><strong>comparer</strong> is <strong>null</strong>.</exception>
        public ArrayListCollection(IComparer<T> comparer) : base(comparer) 
        {
            _items = new T[_capacity];
        }

        /// <summary>
        /// Adds a value to the <see cref="ArrayListCollection{T}"/>. 
        /// </summary>
        /// <remarks>
        /// By default at the next free location in the array.
        /// </remarks>
        /// <param name="value">Value to add to the <see cref="ArrayListCollection{T}"/>.</param>
        /// <returns>The index of the <see cref="ArrayListCollection{T}"/> where the value is stored.</returns>
        public int Add(T value)
        {
            if (_count == _capacity)
            {
                Array.Resize(ref _items, _capacity *= 2); // we need to double the size of the array
            }
            while (Comparer.Compare(_items[_currentIndex], default(T)) != 0)
            {
                /* honour the values that have been added by explicitly stating the index to which they should to stored at 
                 * within the _items array.  We skip all values which are not the default for that particular type. */
                _currentIndex++;
            }
            _count++;
            _items[_currentIndex] = value;
            return _currentIndex++;
        }

        /// <summary>
        /// Gets the capacity of the <see cref="ArrayListCollection{T}"/>.
        /// </summary>
        /// <remarks>
        /// The capacity property is the size of the array that <see cref="ArrayListCollection{T}"/> uses internally, the capacity
        /// just like a Vector in C++, <see cref="ArrayList"/> and <see cref="List{T}"/> is resized when the internal array becomes full.
        /// When the internal <see cref="Array"/>'s capacity is full it's capacity is doubled.
        /// </remarks>
        public int Capacity
        {
            get { return _capacity; }
        }

        /// <summary>
        /// Helper method to detect whether or not the index specified is within range
        /// of the items array.
        /// </summary>
        /// <param name="index">Index of items array to access.</param>
        /// <returns>True if the index within the range of the array; otherwise false.</returns>
        private bool isInRange(int index)
        {
            return (index < 0 || index > _items.Length - 1) ? false : true;
        }

        /// <summary>
        /// Checks to see if the object is compatiable with this colleciton.
        /// The object must be of type T, not null and not a value type.
        /// </summary>
        /// <param name="value">Object to test for compatibility.</param>
        /// <returns>True if the object can be safely casted to type T; otherwise false.</returns>
        private static bool isCompatibleType(object value)
        {
            return (!(value is T) && value != null || typeof(T).IsValueType) ? false : true;
        }

        #region IList Members

        /// <summary>
        /// Adds a value to the <see cref="IList"/>.
        /// </summary>
        /// <param name="value">Value to add to the <see cref="IList"/>.</param>
        /// <returns>The index of the <see cref="IList"/> the value was added to.</returns>
        int IList.Add(object value)
        {
            if (!isCompatibleType(value))
            {
                throw new ArgumentException(Resources.TypeNotCompatible);
            }
            return Add((T)value);
        }

        /// <summary>
        /// Determines whether the <see cref="IList"/> contains a specific value.
        /// </summary>
        /// <param name="value">Value to locate in the <see cref="IList"/>.</param>
        /// <returns>True if the value was located in the <see cref="IList"/>; otherwise false.</returns>
        bool IList.Contains(object value)
        {
            if (!isCompatibleType(value))
            {
                throw new ArgumentException(Resources.TypeNotCompatible);
            }
            return IndexOf((T)value) < 0 ? false : true;
        }

        /// <summary>
        /// Searches for the specified value and returns the zero-based index of the first occurrence within the entire <see cref="IList"/>.
        /// </summary>
        /// <param name="value">The value to locate in the <see cref="IList"/>.</param>
        /// <returns>The zero-based index of the first occurrence of item within the entire <see cref="IList"/>, if found; otherwise, –1.</returns>
        int IList.IndexOf(object value)
        {
            if (!isCompatibleType(value))
            {
                throw new ArgumentException(Resources.TypeNotCompatible);
            }
            return IndexOf((T)value);
        }

        /// <summary>
        /// Inserts a value into the <see cref="IList"/> at the specified index.
        /// </summary>
        /// <param name="index">Index to insert item at.</param>
        /// <param name="value">Value to insert into the <see cref="IList"/>.</param>
        void IList.Insert(int index, object value)
        {
            if (!isCompatibleType(value))
            {
                throw new ArgumentException(Resources.TypeNotCompatible);
            }
            Insert(index, (T)value);
        }

        /// <summary>
        /// Gets a value indicating whether the <see cref="IList"/> has a fixed size.
        /// </summary>
        bool IList.IsFixedSize
        {
            get { return false; }
        }

        /// <summary>
        /// Removes the first occurrence of a specific value from the <see cref="IList"/>.
        /// </summary>
        /// <param name="value">Value to remove.</param>
        void IList.Remove(object value)
        {
            if (!isCompatibleType(value))
            {
                throw new ArgumentException(Resources.TypeNotCompatible);
            }
            Remove((T)value);
        }

        /// <summary>
        /// Removes the element at the specified index of the <see cref="IList"/>.
        /// </summary>
        /// <param name="index">Index of item to remove.</param>
        void IList.RemoveAt(int index)
        {
            RemoveAt(index);
        }

        /// <summary>
        /// Gets or sets the element at the specified index in the <see cref="IList"/>.
        /// </summary>
        /// <param name="index">Index of item to get or set.</param>
        /// <returns>Item at the specified index.</returns>
        object IList.this[int index]
        {
            get
            {
                return this[index];
            }
            set
            {
                if (!isCompatibleType(value))
                {
                    throw new ArgumentException(Resources.TypeNotCompatible);
                }
                this[index] = (T)value;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the <see cref="IList"/> is read-only.
        /// </summary>
        bool IList.IsReadOnly
        {
            get { return false; }
        }

        #endregion

        #region ICollection<T> Members

        /// <summary>
        /// Adds an item to the <see cref="ICollection{T}"/>.
        /// </summary>
        /// <param name="item">Item to add to the <see cref="ICollection{T}"/>.</param>
        void ICollection<T>.Add(T item)
        {
            Add(item);
        }

        /// <summary>
        /// Removes all elements from the <see cref="ArrayListCollection{T}"/>.
        /// Does not change the capacity to its default size.
        /// </summary>
        public void Clear()
        {
            _count = 0;
            _currentIndex = 0;
            _capacity = 4; // reset capacity to default size
            _items = new T[_capacity]; // let the GC clean the old items array up, we simply assign items to a new array with the deafult capacity size
        }

        /// <summary>
        /// Determines whether an element is in the <see cref="ArrayListCollection{T}"/>.
        /// </summary>
        /// <param name="item">Item to locate in the <see cref="ArrayListCollection{T}"/>.</param>
        /// <returns>True if the item was located; otherwise false.</returns>
        public bool Contains(T item)
        {
            return IndexOf(item) < 0 ? false : true;
        }

        /// <summary>
        /// Copies the entire <see cref="ArrayListCollection{T}"/> to a compatible one-dimensional Array, starting at the specified index of the target array.
        /// </summary>
        /// <param name="array">One-dimensional array to copy <see cref="ArrayListCollection{T}"/> items to.</param>
        /// <param name="arrayIndex">Index of target array to start copy at.</param>
        public void CopyTo(T[] array, int arrayIndex)
        {
            Array.Copy(_items, 0, array, arrayIndex, _count);
        }

        /// <summary>
        /// Gets the number of elements contained in the <see cref="ArrayListCollection{T}"/>.
        /// </summary>
        public int Count
        {
            get { return _count; }
        }

        /// <summary>
        /// Removes the first occurrence of a specific object from the <see cref="ArrayListCollection{T}"/>.
        /// </summary>
        /// <param name="item">Item to remove.</param>
        /// <returns>True if the item was found and removed; otherwise false.</returns>
        public bool Remove(T item)
        {
            if (IndexOf(item) < 0) return false;
            RemoveAt(IndexOf(item));
            return true;
        }

        /// <summary>
        /// Gets a value indicating whether the <see cref="ICollection{T}"/> is read-only.
        /// </summary>
        bool ICollection<T>.IsReadOnly
        {
            get { return false; }
        }

        #endregion

        #region IEnumerable<T> Members

        /// <summary>
        /// Returns an enumerator that iterates through the <see cref="ArrayListCollection{T}"/>.
        /// </summary>
        /// <returns><see cref="IEnumerator{T}"/></returns>
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < _count; i++)
            {
                yield return _items[i];
            }
        }

        #endregion

        #region IEnumerable Members

        /// <summary>
        /// Returns an enumerator that iterates through the <see cref="ArrayListCollection{T}"/>.
        /// </summary>
        /// <returns><see cref="IEnumerator"/>.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion

        #region ICollection Members

        /// <summary>
        /// Copies the entire <see cref="ICollection"/> to a compatible one-dimensional Array, starting at the specified index of the target array.
        /// </summary>
        /// <param name="array">One-dimensional array to copy <see cref="ICollection"/> items to.</param>
        /// <param name="index">Index of target array to start copy at.</param>
        void ICollection.CopyTo(Array array, int index)
        {
            throw new NotSupportedException(Resources.ICollectionCopyToNotSupported);
        }

        /// <summary>
        /// Gets a value indicating whether access to the <see cref="ICollection"/> is synchronized (thread safe).
        /// </summary>
        bool ICollection.IsSynchronized
        {
            get { return false; }
        }

        /// <summary>
        /// Gets an object that can be used to synchronize access to the <see cref="ICollection"/>.
        /// </summary>
        object ICollection.SyncRoot
        {
            get
            {
                if (_syncRoot == null)
                {
                    Interlocked.CompareExchange(ref _syncRoot, new object(), null);
                }
                return _syncRoot;
            }
        }

        #endregion

        #region IList<T> Members

        /// <summary>
        /// Searches for the specified object and returns the zero-based index of the first occurrence within the entire <see cref="ArrayListCollection{T}"/>.
        /// </summary>
        /// <param name="item">Item to locate in the <see cref="ArrayListCollection{T}"/>. The item can be null for reference types.</param>
        /// <returns>The zero-based index of the first occurrence of item within the entire <see cref="ArrayListCollection{T}"/> 
        /// if found; otherwise, –1.</returns>
        public int IndexOf(T item)
        {
            return Array.IndexOf(_items, item);
        }

        /// <summary>
        /// Inserts an element into the <see cref="ArrayListCollection{T}"/> at the specified index.
        /// </summary>
        /// <param name="index">Index to insert item at.</param>
        /// <param name="item">Item to insert into the <see cref="ArrayListCollection{T}"/>.</param>
        /// <exception cref="ArgumentOutOfRangeException"><strong>index</strong> has a value that is outside the bounds of the 
        /// <see cref="ArrayListCollection{T}"/>'s array.</exception>
        public void Insert(int index, T item)
        {
            if (isInRange(index))
            {
                if (index < _currentIndex)
                {
                    _items[index] = item;
                }
                else
                {
                    _items[index] = item;
                    _count++;
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException("index");
            }
        }

        /// <summary>
        /// Removes the element at the specified index of the <see cref="ArrayListCollection{T}"/>.
        /// </summary>
        /// <param name="index">Index of item to remove.</param>
        /// <exception cref="ArgumentOutOfRangeException"><strong>index</strong> has a value that is outside the bounds of the 
        /// <see cref="ArrayListCollection{T}"/>'s array.</exception>
        public void RemoveAt(int index)
        {
            if (isInRange(index))
            {
                _count--;
                _currentIndex--;
                if (index < _count)
                {
                    Array.Copy(_items, index + 1, _items, index, 1);
                }
                _items[_count] = default(T);
            }
            else
            {
                throw new ArgumentOutOfRangeException("index");
            }
        }

        /// <summary>
        /// Gets or sets the element at the specified index in the <see cref="ArrayListCollection{T}"/>.
        /// </summary>
        /// <remarks>
        /// The value inserted by index will not be overwritten when calling the <see cref="ArrayListCollection{T}.Add"/> method.
        /// </remarks>
        /// <param name="index">Index of item to get or set.</param>
        /// <returns>Item at the specified index.</returns>
        public T this[int index]
        {
            get
            {
                return _items[index];
            }
            set
            {
                if (!(index < _count))
                {
                    _count++;
                }
                _items[index] = value;
            }
        }

        #endregion

    }

}
