using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dsa.Algorithms;

namespace Dsa.Test
{

    /// <summary>
    /// Tests for Searching.
    /// </summary>
    [TestClass]
    public class SearchingTest
    {
        
        /// <summary>
        /// Test to see that SequentialSearch returns the correct index for an item that is in the array.
        /// </summary>
        [TestMethod]
        public void SequentialSearchItemPresentTest()
        {
            int[] actual = {1, 6, 7, 1, 90, 12, 99};

            Assert.AreEqual(4, actual.SequentialSearch(90));
        }

        /// <summary>
        /// Test to see that SequentialSearch returns -1 when the item is not found within the array.
        /// </summary>
        [TestMethod]
        public void SequentialSearchItemNotPresentTest()
        {
            int[] actual = {1, 4, 5, 6, 9};

            Assert.AreEqual(-1, actual.SequentialSearch(99));
        }

    }

}
