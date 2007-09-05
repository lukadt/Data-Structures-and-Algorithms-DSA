namespace Dsa.DataStructures {

    public class StackCollection<T> {

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

    }

}
