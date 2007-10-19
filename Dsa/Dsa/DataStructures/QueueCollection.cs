using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using Dsa.Properties;

namespace Dsa.DataStructures
{

    /// <summary>
    /// Queue(Of T).
    /// SinglyLinkedList implementation.
    /// </summary>
    /// <typeparam name="T">Type of the QueueCollection.</typeparam>
    [Serializable]
    [DebuggerDisplay("Count={Count}")]
    [DebuggerTypeProxy(typeof(CollectionDebugView<>))]
    public sealed class QueueCollection<T> : ICollection<T>, ICollection where T : IEquatable<T>
    {

        [NonSerialized]
        private SinglyLinkedListCollection<T> _queue;
        [NonSerialized]
        private object _syncRoot;

        /// <summary>
        /// Initializes a new instance of the QueueCollection(Of T) class.
        /// </summary>
        public QueueCollection()
        {
            _queue = new SinglyLinkedListCollection<T>();
        }

        /// <summary>
        /// Add an item to the back of the queue.
        /// </summary>
        /// <param name="item">Item to add to the back of the queue.</param>
        public void Enqueue(T item)
        {
            _queue.AddLast(item);
        }

        /// <summary>
        /// Gets the item at the front of the queue without removing it from the queue.
        /// </summary>
        /// <returns>Item at the front of the queue.</returns>
        public T Peek()
        {
            return _queue.Head.Value;
        }

        /// <summary>
        /// Gets the item at the front of the queue and removes it from the queue.
        /// </summary>
        /// <returns>Item at the front of the queue.</returns>
        public T Dequeue()
        {
            T front = _queue.Head.Value;
            _queue.RemoveFirst();
            return front;
        }

        /// <summary>
        /// Converts the QueueCollection and its items to an array.
        /// </summary>
        /// <returns>An array containing the items from the QueueCollection.</returns>
        public T[] ToArray()
        {
            return _queue.ToArray();
        }


        #region ICollection<T> Members

        /// <summary>
        /// Adds an item to the back of the QueueCollection.
        /// </summary>
        /// <param name="item">Item to add to the back of the QueueCollection.</param>
        void ICollection<T>.Add(T item)
        {
            Enqueue(item);
        }

        /// <summary>
        /// Removes all items from the QueueCollection(Of T).
        /// </summary>
        public void Clear()
        {
            _queue.Clear();
        }

        /// <summary>
        /// Determines where an item is in the QueueCollection(Of T).
        /// </summary>
        /// <param name="item">Item to locate in the QueueCollection(Of T).</param>
        /// <returns>True if the item was found in the QueueCollection(Of T), false otherwise.</returns>
        public bool Contains(T item)
        {
            return _queue.Contains(item);
        }

        /// <summary>
        /// Copies the items in the QueueCollection to an array starting at the specified array index.
        /// </summary>
        /// <param name="array">The one-dimensional Array that is the destination of the elements copied 
        /// from QueueCollection. The Array must have zero-based indexing</param>
        /// <param name="arrayIndex">The zero-based index in array at which copying begins.</param>
        public void CopyTo(T[] array, int arrayIndex)
        {
            _queue.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Gets the number of items stored in the QueueCollection.
        /// </summary>
        public int Count
        {
            get { return _queue.Count; }
        }

        /// <summary>
        /// Returns false.  QueueCollection is not readonly.
        /// </summary>
        bool ICollection<T>.IsReadOnly
        {
            get { return false; }
        }

        /// <summary>
        /// Removes the first occurence of an item from the QueueCollection.
        /// </summary>
        /// <param name="item">Item to remove from the QueueCollection.</param>
        /// <returns>True if the item was found and removed, false otherwise.</returns>
        bool ICollection<T>.Remove(T item)
        {
            return _queue.Remove(item);
        }

        #endregion

        #region IEnumerable<T> Members

        /// <summary>
        /// Returns an enumerator that iterates through the items in the QueueCollection.
        /// </summary>
        /// <returns>A generic IEnumerator object.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            return _queue.GetEnumerator();
        }

        #endregion

        #region IEnumerable Members

        /// <summary>
        /// Returns an enumerator that iterates through the QueueCollection.
        /// </summary>
        /// <returns>An IEnumerator object.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion

        #region ICollection Members

        /// <summary>
        /// Copies the elements of the ICollection to an Array, starting at a particular Array index.
        /// </summary>
        /// <param name="array">Array to copy elements to.</param>
        /// <param name="index">Index of array to start copying to.</param>
        void ICollection.CopyTo(Array array, int index)
        {
            throw new NotSupportedException(Resources.ICollectionCopyToNotSupported);
        }

        /// <summary>
        /// Gets a value indicating whether access to the ICollection is synchronized (thread safe).
        /// </summary>
        bool ICollection.IsSynchronized
        {
            get { return false; }
        }

        /// <summary>
        /// Gets an object that can be used to synchronize access to the ICollection.
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
