using System.Collections.Generic;

namespace Dsa.DataStructures
{

    /// <summary>
    /// <see cref="OrderedSet{T}"/> is an implementation of the mathematical set where the items in the set are ordered.  
    /// This is a <see cref="BinarySearchTree{T}"/> implementation (not balanced). 
    /// </summary>
    /// <typeparam name="T">Type of OrderedSet.</typeparam>
    public sealed class OrderedSet<T> : Set<T>, IComparerProvider<T>
    {

        private IComparer<T> _comparer = Comparer<T>.Default;

        /// <summary>
        /// Initializes a new <see cref="OrderedSet{T}"/> data structure.
        /// </summary>
        public OrderedSet() 
            : base(new BinarySearchTree<T>())
        {
        }

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

        #region IComparerProvider<T> Members

        /// <summary>
        /// Gets the comparer used for the <see cref="OrderedSet{T}"/>.
        /// </summary>
        IComparer<T> IComparerProvider<T>.Comparer
        {
            get { return _comparer; }
        }

        #endregion
    }

}
