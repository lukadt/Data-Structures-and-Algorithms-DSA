using System;
using Dsa.DataStructures;
using Dsa.Properties;
using Dsa.Utility;

namespace Dsa.Algorithms
{
    /// <summary>
    /// <see cref="Set{T}"/> algorithms.
    /// </summary>
    public static class Sets
    {
        /// <summary>
        /// Determines the number of permutations a set of <em>n</em> items can have with different permutations of
        /// <em>k</em> items.
        /// </summary>
        /// <remarks>
        /// <em>Permutations(n, k) = n!/(n-k)!</em>. 
        /// </remarks>
        /// <typeparam name="T">Type of <see cref="Set{T}"/>.</typeparam>
        /// <param name="set">Set to count permutations of.</param>
        /// <param name="k">Permutations of k items.</param>
        /// <returns>The number of set permutations of <em>k</em> items.</returns>
        public static int Permutations<T>(this Set<T> set, int k)
        {
            Guard.ArgumentNull(set, "set");
            if (k < 1)
            {
                throw new ArgumentOutOfRangeException(Resources.PermutationsKGreaterThanZero);
            }

            return (set.Count - k) < 0 ? 0 : set.Count.Factorial() / (set.Count - k).Factorial();
        }
    }
}
