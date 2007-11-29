using System;
using Dsa.Algorithms;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dsa.Test
{

    /// <summary>
    /// Sorting tests.
    /// </summary>
    [TestClass]
    public class SortingTest
    {

        /// <summary>
        /// Check to see that the bubblesort algorithm sorts the items
        /// in ascending order.
        /// </summary>
        [TestMethod]
        public void BubbleSortAscTest()
        {
            int[] myInts = { 23, 1, 44, 62, 1, 6, 90, 34 };
            int[] actual = new int[myInts.Length];
            int[] expected = { 1, 1, 6, 23, 34, 44, 62, 90 };

            actual = myInts.BubbleSort(SortType.Ascending);

            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Check to see that the bubblesort algorithm sorts the items
        /// in descending order.
        /// </summary>
        [TestMethod]
        public void BubbleSortDescTest()
        {
            int[] myInts = { 23, 1, 44, 62, 1, 6, 90, 34 };
            int[] actual = new int[myInts.Length];
            int[] expected = { 90, 62, 44, 34, 23, 6, 1, 1 };

            actual = myInts.BubbleSort(SortType.Descending);

            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Check to see that passing in a null array to BubbleSort results in the expected
        /// exception being thrown.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void BubbleSortNullArrayTest()
        {
            int[] actual = null;

            actual.BubbleSort(SortType.Ascending);
        }

        /// <summary>
        /// Check to see that the median value of the array is in the correct location of the array.
        /// </summary>
        [TestMethod]
        public void MedianLeftTest()
        {
            int[] actual = { 2, 5, 23, 17, 1 };
            int[] expected = { 2, 5, 1, 17, 23 };

            CollectionAssert.AreEqual(expected, actual.MedianLeft());
        }

        /// <summary>
        /// Check to see that the median value of the array is in the correct location of the array.
        /// </summary>
        [TestMethod]
        public void MedianLeftLeftIsGreaterThanMidTest()
        {
            int[] actual = { 23, 1, 4, 8, 10 };
            int[] expected = { 10, 1, 4, 8, 23 };

            CollectionAssert.AreEqual(expected, actual.MedianLeft());
        }

        /// <summary>
        /// Check to see that the MedianLeft method throws the correct exception when applying the method to an
        /// array that doesn't have a length or at least 3.
        /// We need at least a length of 3 to select the three keys from the array - left, right and med.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void MedianLeftArrayLengthLessThanThreeTest()
        {
            int[] actual = { 23, 1 };

            actual.MedianLeft();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MedianLeftArrayNullTest()
        {
            int[] actual = null;

            actual.MedianLeft();
        }

    }

}
