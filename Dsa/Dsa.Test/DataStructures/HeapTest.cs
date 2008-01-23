using Dsa.DataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Dsa.Test.DataStructures
{

    /// <summary>
    /// Tests for Heap.
    /// </summary>
    [TestClass]
    public class HeapTest
    {

        /// <summary>
        /// Check to see that adding an item to the Heap results in the correct behaviour.
        /// </summary>
        [TestMethod]
        public void AddTest()
        {
            Heap<int> actual = new Heap<int>()
            {
                10,
                20,
                66,
                21,
                73
            };

            Assert.AreEqual(5, actual.Count);
        }

        /// <summary>
        /// Check to see that when using Max heap that the items are in the correct order.
        /// </summary>
        [TestMethod]
        public void MaxHeapTest()
        {
            Heap<int> actual = new Heap<int>(HeapType.Max)
            {
                10,
                23,
                7,
                9,
                12,
                18
            };
            int[] expected = { 23, 12, 18, 9, 10, 7 };

            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Check to see that when using Min heap that the items are in the correct order.
        /// </summary>
        [TestMethod]
        public void MinHeapTest()
        {
            Heap<int> actual = new Heap<int>()
            {
                3, 
                66, 
                89,
                1,
                90,
                5,
                0
            };
            int[] expected = { 0, 3, 1, 66, 90, 89, 5 };

            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Check to see that you can use the Heap with a custom comparer.
        /// </summary>
        [TestMethod]
        public void CustomComparerTest()
        {
            IComparer<Coordinate> comparer = new CoordinateComparer();
            IComparerProvider<Coordinate> actual = new Heap<Coordinate>(HeapType.Min, comparer);

            Assert.IsNotNull(actual.Comparer);
        }

    }
}
