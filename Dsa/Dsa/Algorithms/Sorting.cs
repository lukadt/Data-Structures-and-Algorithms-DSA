using System;

namespace Dsa.Algorithms
{

    /// <summary>
    /// Sorting algorithms.
    /// </summary>
    public static class Sorting
    {

        /// <summary>
        /// Sorts an array of integers in ascending order.
        /// </summary>
        /// <param name="array">The array to sort.</param>
        /// <returns>The sorted array.</returns>
        public static int[] BubbleSort(this int[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException("array");
            }
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length; j++)
                {
                    int temp = array[j];
                    if (array[i] < array[j])
                    {
                        array[j] = array[i];
                        array[i] = temp;
                    }
                }
            }
            return array;
        }

    }

}
