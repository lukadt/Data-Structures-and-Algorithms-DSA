using System.Collections.Generic;

namespace Dsa.DataStructures
{
    /// <summary>
    /// Based on a standard mathematical set.
    /// </summary>
    /// <typeparam name="T">Type of the <see cref="UnorderedSet{T}"/>.</typeparam>
    public class UnorderedSet<T> : Set<T>
    {
        /// <summary>
        /// Initializes a new instance of <see cref="UnorderedSet{T}"/>.
        /// </summary>
        public UnorderedSet()
            : base(new SinglyLinkedList<T>())
        {
        }

        /// <summary>
        /// Returns an <see cref="IEnumerator{T}"/> to provide a simple traversal through the items in the <see cref="UnorderedSet{T}"/>.
        /// </summary>
        /// <returns>
        /// An <see cref="IEnumerator{T}"/> to traverse the <see cref="UnorderedSet{T}"/>.
        /// </returns>
        /// <remarks>
        /// This method is an O(n) operation where n is the number of items in the <see cref="UnorderedSet{T}"/>.
        /// </remarks>
        public override IEnumerator<T> GetEnumerator()
        {
            return Collection.GetEnumerator();
        }
    }
}