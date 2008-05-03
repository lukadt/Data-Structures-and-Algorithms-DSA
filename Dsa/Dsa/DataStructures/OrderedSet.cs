using System;
using System.Collections.Generic;

namespace Dsa.DataStructures
{
    /// <summary>
    /// An ordered set where the items are ordered using a default <see cref="Comparer{T}"/> or a provided <see cref="IComparer{T}"/>.  
    /// </summary>
    /// <typeparam name="T">Type of OrderedSet.</typeparam>
    public sealed class OrderedSet<T> : Set<T>, IComparerProvider<T>
    {
        // note: should this just derive from Bst? 
        // note: I need to test that the uniqueness of items works with complex types
        [NonSerialized]
        private IComparer<T> _comparer = Comparer<T>.Default;

        /// <summary>
        /// Initializes a new <see cref="OrderedSet{T}"/> data structure.
        /// </summary>
        public OrderedSet()
            : base(new BinarySearchTree<T>()) { }

        /// <summary>
        /// Initializes a new <see cref="OrderedSet{T}"/> using a specified <see cref="IComparer{T}"/>.
        /// </summary>
        /// <param name="comparer"></param>
        public OrderedSet(IComparer<T> comparer) :
            base(new BinarySearchTree<T>(comparer))
        {
            _comparer = comparer;
        }

        /// <summary>
        /// Returns an <see cref="IEnumerator{T}"/> to provide a simple traversal through the items in the <see cref="OrderedSet{T}"/>.
        /// </summary>
        /// <returns>An <see cref="IEnumerator{T}"/> to traverse the <see cref="OrderedSet{T}"/>.</returns>
        /// <remarks>
        /// This method is an O(n) operation where n is the number of items in the <see cref="OrderedSet{T}"/>.
        /// </remarks>
        public override IEnumerator<T> GetEnumerator()
        {
            return (Collection as BinarySearchTree<T>).GetInorderEnumerator().GetEnumerator();
        }      

        /// <summary>
        /// Gets the comparer used for the <see cref="OrderedSet{T}"/>.
        /// </summary>
        IComparer<T> IComparerProvider<T>.Comparer
        {
            get { return _comparer; }
        }
    }
}
