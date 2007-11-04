using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Dsa.Properties;
using System.Diagnostics;

namespace Dsa.DataStructures
{

    /// <summary>
    /// <see cref="StackCollection{T}"/> is a singly linked list implementation of the stack data structure.
    /// </summary>
    /// <typeparam name="T">Type of the <see cref="StackCollection{T}"/></typeparam>
    [Serializable]
    [DebuggerDisplay("Count={Count}")]
    [DebuggerTypeProxy(typeof(CollectionDebugView<>))]
    public sealed class StackCollection<T> : ICollection<T>, ICollection
    {

        [NonSerialized]
        private SinglyLinkedListCollection<T> _stack;
        [NonSerialized]
        private object _syncRoot;

        /// <summary>
        /// Initializes a new instance of the <see cref="StackCollection{T}"/> class.
        /// </summary>
        public StackCollection()
        {
            _stack = new SinglyLinkedListCollection<T>();
        }

        /// <summary>
        /// Pushes an item onto the top of the <see cref="StackCollection{T}"/>.
        /// </summary>
        /// <param name="item">Item to push onto top of the <see cref="StackCollection{T}"/>.</param>
        public void Push(T item)
        {
            _stack.AddLast(item);
        }

        /// <summary>
        /// Returns the item at the top of the <see cref="StackCollection{T}"/>.
        /// </summary>
        /// <returns>Item at the top of the <see cref="StackCollection{T}"/>.</returns>
        public T Peek()
        {
            return _stack.Tail.Value;
        }

        /// <summary>
        /// Removes and returns the item at the top of the <see cref="StackCollection{T}"/>.
        /// </summary>
        /// <returns>Item at the top of the <see cref="StackCollection{T}"/>.</returns>
        public T Pop()
        {
            T peek = _stack.Tail.Value;
            _stack.RemoveLast();
            return peek;
        }

        /// <summary>
        /// Converts the <see cref="StackCollection{T}"/> and its items to an <see cref="Array"/>.
        /// </summary>
        /// <returns>An <see cref="Array"/> containing the items from the <see cref="StackCollection{T}"/>.</returns>
        public T[] ToArray()
        {
            return _stack.ToReverseArray();
        }

        /// <summary>
        /// Determines whether or not the <see cref="StackCollection{T}"/> is empty.
        /// </summary>
        /// <returns>True if the stack is empty; false otherwise.</returns>
        public bool IsEmpty()
        {
            return _stack.IsEmpty();
        }

        #region ICollection<T> Members

        /// <summary>
        /// Adds an item to the <see cref="ICollection"/>.
        /// </summary>
        /// <param name="item">Item to add to the <see cref="ICollection"/>.</param>
        void ICollection<T>.Add(T item)
        {
            _stack.AddLast(item);
        }

        /// <summary>
        /// Resets the <see cref="StackCollection{T}"/> to its default state.
        /// </summary>
        public void Clear()
        {
            _stack.Clear();
        }

        /// <summary>
        /// Determines whether an item is in the <see cref="StackCollection{T}"/>
        /// </summary>
        /// <param name="item">Item to locate in the <see cref="StackCollection{T}"/>.</param>
        /// <returns>True if the item was found; false otherwise.</returns>
        public bool Contains(T item)
        {
            return _stack.Contains(item);
        }

        /// <summary>
        /// Copies the items in the <see cref="StackCollection{T}"/> to an <see cref="Array"/> starting at the specified array index.
        /// </summary>
        /// <param name="array">The one-dimensional Array that is the destination of the elements copied 
        /// from <see cref="StackCollection{T}"/>.</param>
        /// <param name="arrayIndex">The zero-based index in array at which copying begins.</param>
        public void CopyTo(T[] array, int arrayIndex)
        {
            _stack.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Gets the number of items stored in the <see cref="StackCollection{T}"/>.
        /// </summary>
        public int Count
        {
            get { return _stack.Count; }
        }

        /// <summary>
        /// Gets whether the <see cref="ICollection{T}"/> is read only.
        /// </summary>
        bool ICollection<T>.IsReadOnly
        {
            get { return false; }
        }

        /// <summary>
        /// Removes the first occurence of an item from the <see cref="ICollection{T}"/>.
        /// </summary>
        /// <param name="item">Item to remove from the <see cref="StackCollection{T}"/>.</param>
        /// <returns>True if the item was found and removed; false otherwise.</returns>
        bool ICollection<T>.Remove(T item)
        {
            return _stack.Remove(item);
        }

        #endregion

        #region IEnumerable<T> Members

        /// <summary>
        /// Returns an <see cref="IEnumerator{T}"/> that iterates through the <see cref="StackCollection{T}"/>.
        /// </summary>
        /// <returns>An <see cref="IEnumerator{T}"/> that can be used to traverse the items in the <see cref="StackCollection{T}"/>.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            return _stack.GetReverseEnumerator().GetEnumerator();
        }

        #endregion

        #region IEnumerable Members

        /// <summary>
        /// Returns an <see cref="IEnumerator"/> that iterates through the <see cref="IEnumerable"/>.
        /// </summary>
        /// <returns>An <see cref="IEnumerator"/> that can be used to traverse the items in the <see cref="IEnumerable"/>.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion

        #region ICollection Members

        /// <summary>
        /// Copies the elements of the <see cref="ICollection"/> to an <see cref="Array"/>, starting at a specified array index.
        /// </summary>
        /// <param name="array">Array to copy elements to.</param>
        /// <param name="index">Index of array to start copying to.</param>
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

    }

}
