using System;
using Dsa.Utility;
using Dsa.Properties;
using System.Collections;
using System.Collections.Generic;

namespace Dsa.Algorithms
{

    /// <summary>
    /// Sorting algorithms.
    /// </summary>
    public static class Sorting
    {

        /// <summary>
        /// Sorts an <see cref="System.Array"/> of <see cref="Int32"/> in ascending order.
        /// </summary>
        /// <param name="array">The <see cref="System.Array"/> to sort.</param>
        /// <param name="sortType">Specification of how the items are to be sorted.</param>
        /// <returns>The sorted <see cref="System.Array"/>.</returns>
        /// <exception cref="ArgumentNullException"><strong>array</strong> is <strong>null</strong>.</exception>
        public static int[] BubbleSort(this int[] array, SortType sortType)
        {
            if (array == null)
            {
                throw new ArgumentNullException("array");
            }
            // compare each item of the array with every other item in the array - O(n^2) runtime
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length; j++)
                {
                    // check which SortType is being used to sort the items in array
                    switch (sortType)
                    {
                        case SortType.Ascending:
                            if (array[i] < array[j])
                            {
                                Exchange(ref array, j, i);
                            }
                            break;
                        case SortType.Descending:
                            if (array[i] > array[j])
                            {
                                Exchange(ref array, j, i);
                            }
                            break;
                    }
                }
            }
            return array;
        }

        /// <summary>
        /// Sorts an array placing the median value of 3 keys (left, right, and mid) at index 0 (left) of the array.
        /// </summary>
        /// <param name="array">The array to find the median value of.</param>
        /// <returns>The modified array with the median key at index 0.</returns>
        /// <exception cref="ArgumentNullException"><strong>array</strong> is <strong>null</strong>.</exception>
        /// <exception cref="InvalidOperationException"><strong>array</strong> has a length less than <strong>3</strong> making it not
        /// possible to select 3 keys to assist in finding the median value of the array.</exception>
        public static int[] MedianLeft(this int[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException("array");
            }
            else if (array.Length < 3)
            {
                throw new InvalidOperationException(Resources.MedianLeftArrayLengthLessThanThree);
            }
            // find the middle item of array
            int mid = array.Length / 2;
            // define left and right bounds of the array
            int left = 0;
            int right = array.Length - 1;
            // place the keys at the right index in array
            if (array[left] > array[mid])
            {
                Exchange(ref array, left, mid);
            }

            if (array[left] > array[right])
            {
                Exchange(ref array, left, right);
            }

            if (array[mid] > array[right])
            {
                Exchange(ref array, mid, right);
            }
            // exchange the value of items[mid] with items[left] placing the median key at index 0 of the array
            Exchange(ref array, mid, left);

            return array;
        }

        /// <summary>
        /// Exchanges two items in an array.
        /// </summary>
        /// <param name="array">Array that holds the items to be exchanged.</param>
        /// <param name="first">Index of first item.</param>
        /// <param name="second">Index of second item.</param>
        private static void Exchange(ref int[] array, int first, int second)
        {
            int temp = array[first];
            array[first] = array[second];
            array[second] = temp;
        }

        /// <summary>
        /// Merges two ordered arrays into a single ordered array.
        /// </summary>
        /// <typeparam name="T">Type of the two array's to merge.</typeparam>
        /// <param name="first">First array.</param>
        /// <param name="second">Second array.</param>
        /// <returns>The merged array of a1 and a2.</returns>
        /// <exception cref="ArgumentNullException"><strong>a1</strong> or <strong>a2</strong> are null.</exception>
        public static T[] MergeOrdered<T>(T[] first, T[] second)
        {
            if (first == null)
            {
                throw new ArgumentNullException("first");
            }
            else if (second == null)
            {
                throw new ArgumentNullException("second");
            }

            T[] merged = new T[first.Length + second.Length];
            // merge the items in both arrays
            for (int i = 0, j = 0, m = 0; m < merged.Length; m++)
            {
                if (i == first.Length)
                {
                    // all items in a1 have been exhausted so copy the remaining items (if any) from a2 starting at index j to merged
                    Array.Copy(second, j, merged, m, merged.Length - m);
                    break;
                }
                else if (j == second.Length)
                {
                    // all items in a2 have been exhausted
                    Array.Copy(first, i, merged, m, merged.Length - m);
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
        /// Sorts the items of an array using the merge sort algorithm.
        /// </summary>
        /// <param name="value">Array to be sorted.</param>
        /// <returns>Sorted array.</returns>
        /// <exception cref="ArgumentNullException"><strong>value</strong> is <strong>null</strong>.</exception>
        public static T[] MergeSort<T>(this T[] value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            if (value.Length <= 1)
            {
                return value; // base case the array is of size one hence it is already sorted
            }
            else
            {
                int m = value.Length / 2; // find middle or thereabouts of the array
                // create two arrays to store the left and right items of array split
                T[] left = new T[m];
                T[] right = new T[value.Length - m];
                // populate left and right arrays with the appropriate items from value
                for (int i = 0; i < left.Length; i++)
                {
                    left[i] = value[i];
                }
                for (int i = 0; i < right.Length; i++, m++)
                {
                    right[i] = value[m];
                }
                // merge the sorted array branches into their respective sides
                left = MergeSort(left);
                right = MergeSort(right);
                // merge and return the ordered left and right arrays
                return MergeOrdered(left, right);
            }
        }

    }

}
