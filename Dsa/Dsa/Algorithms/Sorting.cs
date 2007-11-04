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
        /// <returns>The sorted <see cref="System.Array"/>.</returns>
        /// <exception cref="ArgumentNullException"><strong>array</strong> is <strong>null</strong>.</exception>
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
                        // swap items around
                        array[j] = array[i];
                        array[i] = temp;
                    }
                }
            }
            return array;
        }

    }

}
