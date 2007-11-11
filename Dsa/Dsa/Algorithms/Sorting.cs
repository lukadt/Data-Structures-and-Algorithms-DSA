using System;

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
                    int temp = array[j]; 
                    // check which SortType is being used to sort the items in array
                    switch (sortType)
                    {
                        case SortType.Ascending:
                            if (array[i] < array[j])
                            {
                                array[j] = array[i];
                                array[i] = temp;
                            }
                            break;
                        case SortType.Descending:
                            if (array[i] > array[j])
                            {
                                array[j] = array[i];
                                array[i] = temp;
                            }
                            break;
                    }
                }
            }
            return array;
        }

    }

}
