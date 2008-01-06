using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Dsa.Properties;
using Dsa.Utility;

namespace Dsa.Algorithms
{

    /// <summary>
    /// Sorting algorithms.
    /// </summary>
    public static class Sorting
    {

        /// <summary>
        /// Sorts any <see cref="System.Collections.Generic"/> that implements <see cref="IList{T}"/> in ascending or descending order using the bubble
        /// sort algorithm.
        /// </summary>
        /// <param name="list">The <see cref="IList{T}"/> to sort.</param>
        /// <param name="sortType">The order in which the items of the <see cref="IList{T}"/> are to be sorted.</param>
        /// <returns>The sorted <see cref="IList{T}"/>.</returns>
        /// <exception cref="ArgumentNullException"><strong>list</strong> is <strong>null</strong>.</exception>
        public static IList<T> BubbleSort<T>(this IList<T> list, SortType sortType)
        {
            if (list == null)
            {
                throw new ArgumentNullException("list");
            }
            Comparer<T> comparer = Comparer<T>.Default;
            // compare each item of the list with every other item in the list - O(n^2) runtime
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 0; j < list.Count; j++)
                {
                    // check which SortType is being used to sort the items in list
                    switch (sortType)
                    {
                        case SortType.Ascending:
                            if (Compare.IsLessThan(list[i], list[j], comparer))
                            {
                                Exchange(ref list, j, i);
                            }
                            break;
                        case SortType.Descending:
                            if (Compare.IsGreaterThan(list[i], list[j], comparer))
                            {
                                Exchange(ref list, j, i);
                            }
                            break;
                    }
                }
            }
            return list;
        }

        /// <summary>
        /// Sorts an <see cref="IList{T}"/> placing the median value of 3 keys (left, right, and mid) at index 0 (left) of the <see cref="IList{T}"/>.
        /// </summary>
        /// <param name="list">The <see cref="IList{T}"/> to find the median value of.</param>
        /// <returns>The modified <see cref="IList{T}"/> with the median key at index 0.</returns>
        /// <exception cref="ArgumentNullException"><strong>list</strong> is <strong>null</strong>.</exception>
        /// <exception cref="InvalidOperationException"><strong>list</strong> has a length less than <strong>3</strong> making it not
        /// possible to select 3 keys to assist in finding the median value of the array.</exception>
        public static IList<T> MedianLeft<T>(this IList<T> list)
        {
            if (list == null)
            {
                throw new ArgumentNullException("list");
            }
            else if (list.Count < 3)
            {
                throw new InvalidOperationException(Resources.MedianLeftArrayLengthLessThanThree);
            }

            Comparer<T> comparer = Comparer<T>.Default;
            // find the middle item of list
            int mid = list.Count / 2;
            // define left and right bounds of the list
            int left = 0;
            int right = list.Count - 1;
            // place the key in the correct index in list
            if (Compare.IsGreaterThan(list[left], list[mid], comparer))
            {
                Exchange(ref list, left, mid);
            }

            if (Compare.IsGreaterThan(list[left], list[right], comparer))
            {
                Exchange(ref list, left, right);
            }

            if (Compare.IsGreaterThan(list[mid], list[right], comparer))
            {
                Exchange(ref list, mid, right);
            }
            // exchange the value of list[mid] with list[left] placing the median key at index 0 of the list
            Exchange(ref list, mid, left);

            return list;
        }

        /// <summary>
        /// Exchanges two items in an <see cref="IList{T}"/>.
        /// </summary>
        /// <param name="list"><see cref="IList{T}"/> that holds the items to be exchanged.</param>
        /// <param name="first">Index of first item.</param>
        /// <param name="second">Index of second item.</param>
        private static void Exchange<T>(ref IList<T> list, int first, int second)
        {
            T temp = list[first];
            list[first] = list[second];
            list[second] = temp;
        }

        /// <summary>
        /// Merges two ordered <see cref="IList{T}"/> collections into a single ordered <see cref="IList{T}"/>.
        /// </summary>
        /// <typeparam name="T">Type of the two array's to merge.</typeparam>
        /// <param name="first">First <see cref="IList{T}"/>.</param>
        /// <param name="second">Second <see cref="IList{T}"/>.</param>
        /// <returns>The merged <see cref="IList{T}"/> of first and second.</returns>
        /// <exception cref="ArgumentNullException"><strong>first</strong> or <strong>second</strong> are null.</exception>
        public static IList<T> MergeOrdered<T>(IList<T> first, IList<T> second)
        {
            if (first == null)
            {
                throw new ArgumentNullException("first");
            }
            else if (second == null)
            {
                throw new ArgumentNullException("second");
            }

            T[] merged = new T[first.Count + second.Count];
            // merge the items in both arrays
            for (int i = 0, j = 0, m = 0; m < merged.Length; m++)
            {
                if (i == first.Count)
                {
                    // all items in a1 have been exhausted so copy the remaining items (if any) from a2 starting at index j to merged
                    Array.Copy(second.ToArray(), j, merged, m, merged.Length - m);
                    break;
                }
                else if (j == second.Count)
                {
                    // all items in a2 have been exhausted
                    Array.Copy(first.ToArray(), i, merged, m, merged.Length - m);
                    break;
                }
                else
                {
                    // add the smallest item of the two arrays at indexes i and j respectively to merged
                    merged[m] = Compare.IsLessThan(first[i], second[j], Comparer<T>.Default) ? first[i++] : second[j++];
                }
            }

            return merged;
        }

        /// <summary>
        /// Sorts the items of an <see cref="IList{T}"/> using the merge sort algorithm.
        /// </summary>
        /// <param name="list">List to be sorted.</param>
        /// <returns>Sorted List.</returns>
        /// <exception cref="ArgumentNullException"><strong>list</strong> is <strong>null</strong>.</exception>
        public static IList<T> MergeSort<T>(this IList<T> list)
        {
            if (list == null)
            {
                throw new ArgumentNullException("list");
            }
            else
            {
                return MergeSortInternal(list);
            }
        }

        /// <summary>
        /// Sorts the items of an <see cref="IList{T}"/> using the merge sort algorithm.
        /// </summary>
        /// <remarks>
        /// This is the internal recursive merge sort algorithm used by <see cref="Sorting.MergeSort{T}"/>.
        /// </remarks>
        /// <param name="list">List to be sorted.</param>
        /// <returns>Sorted List.</returns>
        public static IList<T> MergeSortInternal<T>(IList<T> list)
        {
            if (list.Count <= 1)
            {
                return list; // base case the array is of size one hence it is already sorted
            }
            else
            {
                int m = list.Count / 2; // find middle or thereabouts of the array
                // create two arrays to store the left and right items of array split
                T[] left = new T[m];
                T[] right = new T[list.Count - m];
                // populate left and right arrays with the appropriate items from list
                for (int i = 0; i < left.Length; i++)
                {
                    left[i] = list[i];
                }
                for (int i = 0; i < right.Length; i++, m++)
                {
                    right[i] = list[m];
                }
                // merge the sorted array branches into their respective sides
                left = MergeSortInternal(left) as T[];
                right = MergeSortInternal(right) as T[];
                // merge and return the ordered left and right arrays
                return MergeOrdered(left, right);
            }
        }

    }

}
