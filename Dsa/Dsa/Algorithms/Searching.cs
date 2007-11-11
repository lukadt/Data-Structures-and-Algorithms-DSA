namespace Dsa.Algorithms
{

    /// <summary>
    /// Searching algorithms.
    /// </summary>
    public static class Searching
    {

        /// <summary>
        /// A sequential search for an item within an <see cref="System.Array"/>.
        /// </summary>
        /// <param name="array"><see cref="System.Array"/> to search item for.</param>
        /// <param name="item">Item to search for.</param>
        /// <returns>The index of the item if found is returned, otherwise -1 denotes the item is not in the array.</returns>
        public static int SequentialSearch(this int[] array, int item)
        {
            int i = 0;
            // skip the item if it is not what we are looking for
            while (i < array.Length && array[i] != item)
            {
                i++;
            }
            /* if the item at index i is the item we are looking for then return i (the index at which it was found), else 
            return -1 we didn't find it in the array. */
            if (i < array.Length && array[i] == item)
            {
                return i;
            }
            else
            {
                return -1; 
            }
        }

        /// <summary>
        /// Searches the array for a specifited item.  If the item is in the <see cref="System.Array"/> then the item has its priority
        /// increased by swapping the item with the one before it.
        /// </summary>
        /// <param name="array">The <see cref="System.Array"/> to search.</param>
        /// <param name="item">The item to search the <see cref="System.Array"/> for.</param>
        /// <returns>True if the item was found; false otherwise.</returns>
        public static bool ProbabilitySearch(this int[] array, int item)
        {
            int i = 0;
            // skip the current item if it is not what we are looking for
            while (i < array.Length && array[i] != item)
            {
                i++;
            }
            // check to see if the item at index i is the one we are looking for
            if (i < array.Length && array[i] == item)
            {
                // we can increase the items priority as the item is not the first element in the array
                if (i > 0)
                {
                    int temp = array[i - 1];
                    array[i - 1] = array[i]; // increase the items priority
                    array[i] = temp;
                }
                return true;
            }
            else
            {
                return false; // item not found
            }
        }

    }

}
