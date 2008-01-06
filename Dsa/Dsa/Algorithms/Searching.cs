using System;
using System.Collections.Generic;
using Dsa.Utility;

namespace Dsa.Algorithms
{

    /// <summary>
    /// Searching algorithms.
    /// </summary>
    public static class Searching
    {

        /// <summary>
        /// A sequential search for an item within an <see cref="IList{T}"/>.
        /// </summary>
        /// <param name="list"><see cref="IList{T}"/> to search item for.</param>
        /// <param name="item">Item to search for.</param>
        /// <returns>The index of the item if found is returned, otherwise -1 denotes the item is not in the <see cref="IList{T}"/>.</returns>
        /// <exception cref="ArgumentNullException"><strong>list</strong> is <strong>null</strong>.</exception>
        public static int SequentialSearch<T>(this IList<T> list, T item)
        {
            if (list == null)
            {
                throw new ArgumentNullException("list");
            }

            int i = 0;
            Comparer<T> comparer = Comparer<T>.Default;
            // skip the item if it is not what we are looking for
            while (i < list.Count && !Compare.AreEqual(list[i], item, comparer))
            {
                i++;
            }
            /* if the item at index i is the item we are looking for then return i (the index at which it was found), else 
            return -1 we didn't find it in the array. */
            if (i < list.Count && Compare.AreEqual(list[i], item, comparer))
            {
                return i;
            }
            else
            {
                return -1; 
            }
        }

        /// <summary>
        /// Searches an <see cref="IList{T}"/> for a specifited item.  If the item is in the <see cref="IList{T}"/> then the item has its priority
        /// increased by swapping the item with the one before it.
        /// </summary>
        /// <param name="list"><see cref="IList{T}"/> to search.</param>
        /// <param name="item">The item to search the <see cref="IList{T}"/> for.</param>
        /// <returns>True if the item was found; false otherwise.</returns>
        /// <exception cref="ArgumentNullException"><strong>list</strong> is <strong>null</strong>.</exception>
        public static bool ProbabilitySearch<T>(this IList<T> list, T item)
        {
            if (list == null)
            {
                throw new ArgumentNullException("list");
            }

            int i = 0;
            Comparer<T> comparer = Comparer<T>.Default;
            // skip the current item if it is not what we are looking for
            while (i < list.Count && !Compare.AreEqual(list[i], item, comparer))
            {
                i++;
            }
            // check to see if the item at index i is the one we are looking for
            if (i < list.Count && Compare.AreEqual(list[i], item, comparer))
            {
                // we can increase the items priority as the item is not the first element in the array
                if (i > 0)
                {
                    T temp = list[i - 1];
                    list[i - 1] = list[i]; // increase the items priority
                    list[i] = temp;
                }
                return true;
            }
            else
            {
                return false; // item not found
            }
        }

    }

}
