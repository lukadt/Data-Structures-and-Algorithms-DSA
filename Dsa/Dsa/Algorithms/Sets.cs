using System;
using Dsa.DataStructures;

namespace Dsa.Algorithms
{

    /// <summary>
    /// <see cref="Set{T}"/> algorithms.
    /// </summary>
    public static class Sets
    {

        /// <summary>
        /// Performs set union of two <see cref="Set{T}"/>.
        /// </summary>
        /// <param name="set1">First set.</param>
        /// <param name="set2">Second set.</param>
        /// <returns>The set union of the two sets if there is at least 1 item in the unioned set, otherwise null denoting an empty set.</returns>
        /// <exception cref="ArgumentNullException"><strong>set1</strong> or <strong>set2</strong> is <strong>null</strong>.</exception>
        public static Set<T> Union<T>(this Set<T> set1, Set<T> set2)
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
            return union.Count < 1 ? null : union;
        }

        /// <summary>
        /// Performs set intersection of two <see cref="Set{T}"/>.
        /// </summary>
        /// <param name="set1">First set.</param>
        /// <param name="set2">Second set.</param>
        /// <returns>The set intersection of the two sets if there is at least 1 item in the intersection set, otherwise null denoting an empty set.</returns>
        /// <exception cref="ArgumentNullException"><strong>set1</strong> or <strong>set2</strong> is <strong>null</strong>.</exception>
        public static Set<T> Intersection<T>(this Set<T> set1, Set<T> set2)
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
            return intersection.Count < 1 ? null : intersection;
        }

    }
}
