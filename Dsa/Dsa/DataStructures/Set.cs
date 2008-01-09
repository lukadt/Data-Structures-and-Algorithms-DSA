using System;
using Dsa.Properties;

namespace Dsa.DataStructures
{

    /// <summary>
    /// Base class for all sets.
    /// </summary>
    /// <typeparam name="T">Type of <see cref="Set{T}"/>.</typeparam>
    public class Set<T> : CollectionBase<T>
    {

        private readonly CollectionBase<T> _collection;

        /// <summary>
        /// Initializes a new instance of <see cref="Set{T}"/>.
        /// </summary>
        /// <param name="collection"></param>
        public Set(CollectionBase<T> collection)
        {
            _collection = collection;
        }

        /// <summary>
        /// Adds an item to the <see cref="Set{T}"/>.
        /// </summary>
        /// <param name="item">Item to add to the <see cref="Set{T}"/>.</param>
        public override void Add(T item)
        {
            // check to make sure that the OrderedSet doesn't already contain the item to be added
            if (!_collection.Contains(item))
            {
                _collection.Add(item);
                Count++;
            }
        }

        /// <summary>
        /// Clears all the items from the <see cref="Set{T}"/>.
        /// </summary>
        public override void Clear()
        {
            _collection.Clear();
            Count = 0;
        }

        /// <summary>
        /// Determines whether or not an item is contained within the <see cref="UnorderedSet{T}"/>.
        /// </summary>
        /// <param name="item">Item to search the <see cref="Set{T}"/> for.</param>
        /// <returns>True if the item is contained within the <see cref="Set{T}"/>; othwerise false.</returns>
        public override bool Contains(T item)
        {
            return _collection.Contains(item);
        }

        /// <summary>
        /// Removes an item from the <see cref="Set{T}"/>.
        /// </summary>
        /// <param name="item">Item to remove from the <see cref="Set{T}"/>.</param>
        /// <returns>True if the item was removed; false otherwise.</returns>
        public override bool Remove(T item)
        {
            // HACK check this code over!!!!
            int count = Count;
            if (_collection.Remove(item))
            {
                Count--;
            }
            return Count < count ? true : false;
        }

        /// <summary>
        /// Performs set intersection of two <see cref="Set{T}"/>.
        /// </summary>
        /// <param name="set1">First set.</param>
        /// <param name="set2">Second set.</param>
        /// <returns>The set intersection of the two sets if there is at least 1 item in the intersection set, otherwise null denoting an empty set.</returns>
        /// <exception cref="ArgumentNullException"><strong>set1</strong> is <strong>null</strong>.</exception>
        /// <exception cref="ArgumentNullException"><strong>set2</strong> is <strong>null</strong>.</exception>
        public static Set<T> Intersection(Set<T> set1, Set<T> set2)
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

        /// <summary>
        /// Performs set union of two <see cref="Set{T}"/>.
        /// </summary>
        /// <param name="set1">First set.</param>
        /// <param name="set2">Second set.</param>
        /// <returns>The set union of the two sets if there is at least 1 item in the unioned set, otherwise null denoting an empty set..</returns>
        /// <exception cref="ArgumentNullException"><strong>set1</strong> is <strong>null</strong>.</exception>
        /// <exception cref="ArgumentNullException"><strong>set2</strong> is <strong>null</strong>.</exception>
        public static Set<T> Union(Set<T> set1, Set<T> set2)
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
        /// Gets the collection being used for the set implementation.
        /// </summary>
        protected CollectionBase<T> Collection
        {
            get { return _collection; }
        }

        /// <summary>
        /// Returns the items in the <see cref="Set{T}"/> as a one-dimensional <see cref="Array"/>.
        /// </summary>
        /// <returns>An array populated with the items from the <see cref="Set{T}"/>.</returns>
        public override T[] ToArray()
        {
            // check to see that the set actually has some items in it
            if (Count < 1)
            {
                throw new InvalidOperationException(Resources.SetEmpty);
            }
            T[] array = new T[Count];
            int i = 0; // used for index
            foreach (T item in this)
            {
                array[i] = item;
                i++;
            }
            return array;
        }  

    }
}
