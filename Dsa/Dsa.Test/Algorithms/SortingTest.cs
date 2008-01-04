using System;
using System.Linq;
using Dsa.Algorithms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

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
            List<int> myInts = new List<int>() { 23, 1, 44, 62, 1, 6, 90, 34 };
            IList<int> actual = new List<int>();
            List<int> expected = new List<int>() { 1, 1, 6, 23, 34, 44, 62, 90 };

            actual = myInts.BubbleSort(SortType.Ascending);

            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        /// <summary>
        /// Check to see that the bubblesort algorithm sorts the items
        /// in descending order.
        /// </summary>
        [TestMethod]
        public void BubbleSortDescTest()
        {
            List<int> myInts = new List<int>() { 23, 1, 44, 62, 1, 6, 90, 34 };
            IList<int> actual = new List<int>();
            List<int> expected = new List<int>() { 90, 62, 44, 34, 23, 6, 1, 1 };

            actual = myInts.BubbleSort(SortType.Descending);

            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        /// <summary>
        /// Check to see that passing in a null array to BubbleSort results in the expected
        /// exception being thrown.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void BubbleSortNullArrayTest()
        {
            IList<int> actual = null;

            actual.BubbleSort(SortType.Ascending);
        }

        /// <summary>
        /// Check to see that the median value of the array is in the correct location of the array.
        /// </summary>
        [TestMethod]
        public void MedianLeftTest()
        {
            List<int> actual = new List<int>() { 2, 5, 23, 17, 1 };
            List<int> expected = new List<int>() { 2, 5, 1, 17, 23 };

            actual.MedianLeft();
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        /// <summary>
        /// Check to see that the median value of the array is in the correct location of the array.
        /// </summary>
        [TestMethod]
        public void MedianLeftLeftIsGreaterThanMidTest()
        {
            List<int> actual = new List<int>() { 23, 1, 4, 8, 10 };
            List<int> expected = new List<int>() { 10, 1, 4, 8, 23 };

            actual.MedianLeft();
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
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

        /// <summary>
        /// Check to see that median left raise the correct exception when the array is null.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MedianLeftArrayNullTest()
        {
            int[] actual = null;

            actual.MedianLeft();
        }

        /// <summary>
        /// Check to see that an array with the correct ordering of its items is returned.
        /// </summary>
        [TestMethod]
        public void MergeOrderedTest()
        {
            int[] a1 = { 1, 5, 9 };
            int[] a2 = { 1, 3, 6 };

            int[] expected = { 1, 1, 3, 5, 6, 9 };
            IList<int> actual = Sorting.MergeOrdered(a1, a2);

            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        /// <summary>
        /// Check to see that the correct array is returned when the first array is smaller than the second.
        /// </summary>
        [TestMethod]
        public void MergeOrderedFirstArraySmallerTest()
        {
            int[] a1 = { 1, 4, 12 };
            int[] a2 = { 5, 9, 10, 14 };

            int[] expected = { 1, 4, 5, 9, 10, 12, 14 };
            IList<int> actual = Sorting.MergeOrdered(a1, a2);

            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        /// <summary>
        /// Check to see that the correct array is returned when the second array is smaller than the first.
        /// </summary>
        [TestMethod]
        public void MergeOrderedSecondArraySmallerTest()
        {
            int[] a1 = { 5, 9, 10, 14 };
            int[] a2 = { 1, 4, 12 };

            int[] expected = { 1, 4, 5, 9, 10, 12, 14 };
            IList<int> actual = Sorting.MergeOrdered(a1, a2);

            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        /// <summary>
        /// Check to see the correct expection is raised when the first array is null.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MergeOrderedArrayOneNullTest()
        {
            int[] a1 = null;
            int[] a2 = { 1, 2 };

            Sorting.MergeOrdered(a1, a2);
        }

        /// <summary>
        /// Check to see the the correct exception is raised when the second array is null.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MergeOrderedArrayTwoNullTest()
        {
            int[] a1 = { 1, 2 };
            int[] a2 = null;

            Sorting.MergeOrdered(a1, a2);
        }

        /// <summary>
        /// Check to see that MergeSort orders the array correctly.
        /// </summary>
        [TestMethod]
        public void MergeSortTest()
        {
            int[] unsorted = { 12, 9, 4, 67, 3, 25 };
            int[] expected = { 3, 4, 9, 12, 25, 67 };

            IList<int> actual = unsorted.MergeSort();

            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        /// <summary>
        /// Check to see that the char data type is ordered correctly when using merge ordered.
        /// </summary>
        [TestMethod]
        public void MergeOrderedCharsTest()
        {
            char[] unsorted = { 'g', 'r', 'f', 'b', 'z', 'k' };
            char[] expected = { 'b', 'f', 'g', 'k', 'r', 'z' };

            IList<char> actual = unsorted.MergeSort();

            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        /// <summary>
        /// Check to see that the correct exception is thrown when the array passed is null.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MergeSortArrayNullTest()
        {
            int[] actual = null;

            actual.MergeSort();
        }

    }

}
