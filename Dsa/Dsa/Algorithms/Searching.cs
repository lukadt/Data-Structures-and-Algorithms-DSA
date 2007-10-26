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
            int i = 0;
            while (i < array.Length && array[i] != item) i++;
            if (i < array.Length && array[i] == item) return i; // item found return index
            return -1; // item not found
        }

        /// <summary>
        /// Searches the array for a given item.  If the item is in the array then the item has its priority
        /// increased when swapping the item with the one before it and returning true, otherwise false.
        /// The items near the front of the array are most probable, those near the back are least probable.
        /// </summary>
        /// <param name="array">The array to search.</param>
        /// <param name="item">The item to search the array for.</param>
        /// <returns>True if the item was found; false otherwise.</returns>
        public static bool ProbabilitySearch(this int[] array, int item)
        {
            int i = 0;
            while (i < array.Length && array[i] != item) i++;
            if (i < array.Length && array[i] == item) // we have found the item
            {
                if (i > 0) // we can increase the items priority as the item is not the first element in the array
                {
                    int temp = array[i - 1];
                    array[i - 1] = array[i];
                    array[i] = temp;
                }
                return true;
            }
            return false; // item not found
        }

    }

}
