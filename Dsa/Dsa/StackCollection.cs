using System.Collections.Generic;

namespace Dsa.DataStructures {

    public class StackCollection<T> : ICollection<T> {

        private SinglyLinkedListCollection<T> _stack;

        public StackCollection() {
            _stack = new SinglyLinkedListCollection<T>();
        }

        /// <summary>
        /// Pushes an item onto the top of the StackCollection.
        /// </summary>
        /// <param name="item">Item to push onto top of the StackCollection.</param>
        public void Push(T item) {
            _stack.AddLast(item);
        }

        /// <summary>
        /// Returns the item at the top of the StackCollection.
        /// </summary>
        /// <returns>Item at the top of the StackCollection.</returns>
        public T Peek() {
            return _stack.Tail.Value;
        }

        /// <summary>
        /// Removes and returns the item at the top of the StackCollection.
        /// </summary>
        /// <returns>Item at the top of the StackColleciton.</returns>
        public T Pop() {
            T peek = _stack.Tail.Value; 
            _stack.RemoveLast();
            return peek;
        }


        #region ICollection<T> Members

        /// <summary>
        /// Pushes an item onto the top of the StackCollection.
        /// </summary>
        /// <param name="item">Item to push onto top of the StackCollection.</param>
        void ICollection<T>.Add(T item) {
            _stack.AddLast(item);
        }

        /// <summary>
        /// Removes all items from the StackCollection(Of T).
        /// </summary>
        public void Clear() {
            _stack.Clear();
        }

        /// <summary>
        /// Determines where an item is in the StackCollection(Of T).
        /// </summary>
        /// <param name="item">Item to locate in the StackCollection(Of T).</param>
        /// <returns>True if the item was found in the StackCollection(Of T), false otherwise.</returns>
        public bool Contains(T item) {
            return _stack.Contains(item);
        }

        /// <summary>
        /// Copies the items in the StackCollection to an array starting at the specified array index.
        /// </summary>
        /// <param name="array">The one-dimensional Array that is the destination of the elements copied 
        /// from StackCollection. The Array must have zero-based indexing</param>
        /// <param name="arrayIndex">The zero-based index in array at which copying begins.</param>
        public void CopyTo(T[] array, int arrayIndex) {
            _stack.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Gets the number of items stored in the StackCollection.
        /// </summary>
        public int Count {
            get { return _stack.Count; }
        }

        /// <summary>
        /// Returns false.  StackCollection is not readonly.
        /// </summary>
        bool ICollection<T>.IsReadOnly {
            get { return false; }
        }

        /// <summary>
        /// Removes the first occurence of an item from the StackCollection.
        /// </summary>
        /// <param name="item">Item to remove from the StackCollection.</param>
        /// <returns>True if the item was found and removed, false otherwise.</returns>
        bool ICollection<T>.Remove(T item) {
            return _stack.Remove(item);
        }

        #endregion

        #region IEnumerable<T> Members

        /// <summary>
        /// Returns an enumerator that iterates through the StackCollection.
        /// </summary>
        /// <returns>A generic IEnumerator object.</returns>
        public IEnumerator<T> GetEnumerator() {
            return _stack.GetReverseEnumerator().GetEnumerator();
        }

        #endregion

        #region IEnumerable Members

        /// <summary>
        /// Returns an enumerator that iterates through the StackCollection.
        /// </summary>
        /// <returns>An IEnumerator object.</returns>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
            throw new System.NotImplementedException();
        }

        #endregion
    }

}
