using System;
using System.Collections.Generic;
using Dsa.Properties;

namespace Dsa.DataStructures
{

    /// <summary>
    /// <see cref="OrderedSet{T}"/> is an implementation of the mathematical set.  This is a <see cref="BinarySearchTree{T}"/> implementation (not balanced). 
    /// </summary>
    /// <typeparam name="T">Type of OrderedSet.</typeparam>
    public sealed class OrderedSet<T> : CollectionBase<T>, IComparerProvider<T>
    {

        private BinarySearchTree<T> _bst;
        private IComparer<T> _comparer = Comparer<T>.Default;

        /// <summary>
        /// Initializes a new <see cref="OrderedSet{T}"/> data structure.
        /// </summary>
        public OrderedSet()
        {
            _bst = new BinarySearchTree<T>();
        }

        /// <summary>
        /// Initializes a new <see cref="OrderedSet{T}"/> using a specified <see cref="IComparer{T}"/>.
        /// </summary>
        /// <param name="comparer"></param>
        public OrderedSet(IComparer<T> comparer) :
            this()
        {
            _comparer = comparer;
        }

        /// <summary>
        /// Adds an item to the <see cref="OrderedSet{T}"/>.
        /// </summary>
        /// <param name="item">Item to add to the OrderedSet.</param>
        public override void Add(T item)
        {
            // check to make sure that the OrderedSet doesn't already contain the item to be added
            if (!_bst.Contains(item))
            {
                _bst.Add(item);
                Count++;
            }
        }

        /// <summary>
        /// Clears al the items from the <see cref="OrderedSet{T}"/>.
        /// </summary>
        public override void Clear()
        {
            _bst.Clear();
            Count = 0;
        }

        /// <summary>
        /// Determines whether or not an item is contained within the <see cref="OrderedSet{T}"/>.
        /// </summary>
        /// <param name="item">Item to search the <see cref="OrderedSet{T}"/> for.</param>
        /// <returns>True if the item is contained within the <see cref="OrderedSet{T}"/>; othwerise false.</returns>
        public override bool Contains(T item)
        {
            return _bst.Contains(item);
        }

        /// <summary>
        /// Removes an item from the <see cref="OrderedSet{T}"/>.
        /// </summary>
        /// <param name="item">Item to remove from the <see cref="OrderedSet{T}"/>.</param>
        /// <returns>True if the item was removed; otherwise false.</returns>
        public override bool Remove(T item)
        {
            return _bst.Remove(item);
        }

        /// <summary>
        /// Returns an <see cref="IEnumerator{T}"/> to prvide a simple traversal through the items in the <see cref="OrderedSet{T}"/>.
        /// </summary>
        /// <returns>An <see cref="IEnumerator{T}"/> to traverse the <see cref="OrderedSet{T}"/>.</returns>
        public override IEnumerator<T> GetEnumerator()
        {
            return _bst.GetInorderEnumerator().GetEnumerator();
        }

        /// <summary>
        /// Returns the items in the <see cref="OrderedSet{T}"/> as a one-dimensional <see cref="Array"/>.
        /// </summary>
        /// <returns>An array populated with the items from the <see cref="OrderedSet{T}"/>.</returns>
        public override T[] ToArray()
        {
            // check to see that the set actually has some items in it
            if (Count < 1)
            {
                throw new InvalidOperationException(Resources.SetEmpty);
            }
            T[] array = new T[Count];
            int i = 0; // used for index
            foreach (T item in _bst.GetInorderEnumerator())
            {
                array[i] = item;
                i++;
            }
            return array;
        }

        /// <summary>
        /// Performs set union of two <see cref="OrderedSet{T}"/>.
        /// </summary>
        /// <param name="set1">First set.</param>
        /// <param name="set2">Second set.</param>
        /// <returns>The set union of the two sets if there is at least 1 item in the unioned set, otherwise null denoting an empty set..</returns>
        /// <exception cref="ArgumentNullException"><strong>set1</strong> is <strong>null</strong>.</exception>
        /// <exception cref="ArgumentNullException"><strong>set2</strong> is <strong>null</strong>.</exception>
        public static OrderedSet<T> Union(OrderedSet<T> set1, OrderedSet<T> set2)
        {
            if (set1 == null)
            {
                throw new ArgumentNullException("set1");
            }
            else if (set2 == null)
            {
                throw new ArgumentNullException("set2");
            }

            OrderedSet<T> union = new OrderedSet<T>();
            // add each item from each set to union
            foreach (T item in set1)
            {
                union.Add(item);
            }
            foreach (T item in set2)
            {
                union.Add(item);
            }
            // if the union set has 0 items then return null (empty set) otherwise return union
            return union.Count < 1 ? null : union;
        }

        /// <summary>
        /// Performs set intersection of two <see cref="OrderedSet{T}"/>.
        /// </summary>
        /// <param name="set1">First set.</param>
        /// <param name="set2">Second set.</param>
        /// <returns>The set intersection of the two sets if there is at least 1 item in the intersection set, otherwise null denoting an empty set.</returns>
        /// <exception cref="ArgumentNullException"><strong>set1</strong> is <strong>null</strong>.</exception>
        /// <exception cref="ArgumentNullException"><strong>set2</strong> is <strong>null</strong>.</exception>
        public static OrderedSet<T> Intersection(OrderedSet<T> set1, OrderedSet<T> set2)
        {
            if (set1 == null)
            {
                throw new ArgumentNullException("set1");
            }
            else if (set2 == null)
            {
                throw new ArgumentNullException("set2");
            }

            OrderedSet<T> intersection = new OrderedSet<T>();
            // loop through each item in set1 and check whether this item is in set2
            foreach (T item in set1)
            {
                if (set2.Contains(item))
                {
                    // set1 and set2 both contain this item so add it to the intersection set
                    intersection.Add(item);
                }
            }
            // if the intersection set has 0 items then return null (empty set) otherwise return union
            return intersection.Count < 1 ? null : intersection;
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
