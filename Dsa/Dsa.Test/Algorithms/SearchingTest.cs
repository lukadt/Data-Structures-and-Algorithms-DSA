using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dsa.Algorithms;
using System;

namespace Dsa.Test
{

    /// <summary>
    /// Tests for Searching.
    /// </summary>
    [TestClass]
    public class SearchingTest
    {
        
        /// <summary>
        /// Check to see that SequentialSearch returns the correct index for an item that is in the array.
        /// </summary>
        [TestMethod]
        public void SequentialSearchItemPresentTest()
        {
            int[] actual = {1, 6, 7, 1, 90, 12, 99};

            Assert.AreEqual(4, actual.SequentialSearch(90));
        }

        /// <summary>
        /// Check to see that SequentialSearch returns -1 when the item is not found within the array.
        /// </summary>
        [TestMethod]
        public void SequentialSearchItemNotPresentTest()
        {
            int[] actual = {1, 4, 5, 6, 9};
            
            Assert.AreEqual(-1, actual.SequentialSearch(99));
        }

        /// <summary>
        /// Check to see that when the list is null the correct exception is thrown.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SequentialSearchListNullTest()
        {
            char[] actual = null;

            actual.SequentialSearch('b');
        }

        /// <summary>
        /// Check to see that the correct value is returned when performing a probability search when the item is
        /// in the array and that the array state is correct.
        /// </summary>
        [TestMethod]
        public void ProbabilitySearchTest()
        {
            int[] actual = { 12, 9, 8, 5, 1, 4 };
            int[] expected = { 12, 9, 5, 8, 1, 4 };

            Assert.IsTrue(actual.ProbabilitySearch(5));
            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Check to see that the correct value is returned when the item being searched for is not in the array and that
        /// the array's state is left alone.
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public void ProbabilitySearchItemNotFoundTest()
        {
            int[] actual = { 12, 9, 8, 5, 1, 4 };
            int[] expected = { 12, 9, 8, 5, 1, 4 };

            Assert.IsFalse(actual.ProbabilitySearch(23));
            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Check to see that when the item is found at the first element of the array then 
        /// a swap does not occur.
        /// </summary>
        [TestMethod]
        public void ProbabilitySearchItemAtFrontOfArrayTest()
        {
            int[] actual = { 12, 9, 8, 5, 1, 4 };
            int[] expected = { 12, 9, 8, 5, 1, 4 };

            Assert.IsTrue(actual.ProbabilitySearch(12));
            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Check to see that the correct exception is thrown when the list is null.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ProbabilitySearchListNullTest()
        {
            char[] actual = null;

            actual.ProbabilitySearch('r');
        }

    }

}