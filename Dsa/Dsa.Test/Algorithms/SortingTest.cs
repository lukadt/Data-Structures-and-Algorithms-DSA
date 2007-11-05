using System;
using Dsa.Algorithms;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dsa.Test
{

    [TestClass]
    public class SortingTest
    {

        /// <summary>
        /// Test to see that the bubblesort algorithm sorts the items
        /// in ascending order.
        /// </summary>
        [TestMethod]
        public void BubbleSortAscTest()
        {
            int[] myInts = { 23, 1, 44, 62, 1, 6, 90, 34 };
            int[] actual = new int[myInts.Length];
            int[] expected = { 1, 1, 6, 23, 34, 44, 62, 90 };

            actual = myInts.BubbleSort();

            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test to see that passing in a null array to BubbleSort results in the expected
        /// exception being thrown.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void BubbleSortNullArrayTest()
        {
            int[] actual = null;

            actual.BubbleSort();
        }

    }

}
