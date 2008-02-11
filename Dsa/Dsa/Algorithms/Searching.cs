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
        /// Sequential search for an item within an <see cref="IList{T}"/>.
        /// </summary>
        /// <param name="list"><see cref="IList{T}"/> to search item for.</param>
        /// <param name="item">Item to search for.</param>
        /// <returns>The index of the item if found is returned; otherwise -1.</returns>
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
            // check if the item at index i is that which we are looking for
            if (i < list.Count && Compare.AreEqual(list[i], item, comparer))
            {
                return i;
            }
            else
            {
                return -1; // not found
            }
        }

        /// <summary>
        /// Probability search for an item in an <see cref="IList{T}"/>.  
        /// </summary>
        /// <param name="list"><see cref="IList{T}"/> to search.</param>
        /// <param name="item">The item to search the <see cref="IList{T}"/> for.</param>
        /// <returns>True if the item was found; false otherwise.</returns>
        /// <remarks>If the item is found in the <see cref="IList{T}"/> then it's priority is increased by swapping it with it's predecessor 
        /// in the <see cref="IList{T}"/>.</remarks>
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
