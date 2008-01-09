using System.Collections.Generic;

namespace Dsa.DataStructures
{
    /// <summary>
    /// <see cref="UnorderedSet{T}"/> is an implementation of a mathematical set where the items in the set are unordered.
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
        /// 
        /// </summary>
        /// <returns></returns>
        public override IEnumerator<T> GetEnumerator()
        {
            return Collection.GetEnumerator();
        }

    }
}
