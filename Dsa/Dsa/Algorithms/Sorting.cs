using System;
using Dsa.Properties;

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
                throw new ArgumentNullException("items");
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

    }

}
