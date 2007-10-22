namespace Dsa.Algorithms
{

    /// <summary>
    /// Searching algorithms.
    /// </summary>
    public static class Searching
    {

        /// <summary>
        /// A sequential search for an item within the array.
        /// </summary>
        /// <param name="array">Array to search item for.</param>
        /// <param name="item">Item to search for.</param>
        /// <returns>The index of the item if found is returned, otherwise -1 denotes the item is not in the array.</returns>
        public static int SequentialSearch(this int[] array, int item)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == item) return i;
            }
            return -1;
        }

    }

}
