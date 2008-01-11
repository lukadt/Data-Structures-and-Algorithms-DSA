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
