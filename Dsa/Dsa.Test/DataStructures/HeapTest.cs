using System.Collections.Generic;
using Dsa.DataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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

        /// <summary>
        /// Check to see that removing the last item in the heap results in the state
        /// of the heap being affected correctly.
        /// </summary>
        [TestMethod]
        public void RemoveLastItemTest()
        {
            Heap<int> actual = new Heap<int>()
            {
                56,
                23,
                34,
                1,
                3
            };
            Heap<int> expected = new Heap<int>()
            {
                56,
                34,
                1,
                3
            };

            Assert.IsTrue(actual.Remove(23));
            Assert.AreEqual(4, actual.Count);
            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Check to see that the correct value is returned when the value
        /// being removed is not contained within the heap.
        /// </summary>
        [TestMethod]
        public void RemoveItemNotPresentTest()
        {
            Heap<int> actual = new Heap<int>()
            {
                2,
                78,
                1,
                0,
                56
            };

            Assert.IsFalse(actual.Remove(99));
        }

        /// <summary>
        /// Check to see that the heap is left in the correct state when the root is removed.
        /// </summary>
        [TestMethod]
        public void RemoveRootTest()
        {
            Heap<int> actual = new Heap<int>()
            {
                33,
                12,
                41,
                15,
                60
            };
            Heap<int> expected = new Heap<int>()
            {
                15,
                33,
                41,
                60
            };

            Assert.IsTrue(actual.Remove(12));
            Assert.AreEqual(4, actual.Count);
            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Check to see that the heap is left in the correct state when removing from a 
        /// max heap.
        /// </summary>
        [TestMethod]
        public void RemoveMaxHeapTest()
        {
            Heap<int> actual = new Heap<int>(HeapType.Max)
            {
                12,
                2,
                67,
                90,
                10
            };
            Heap<int> expected = new Heap<int>(HeapType.Max)
            {
                12,
                2,
                67,
                10
            };

            Assert.IsTrue(actual.Remove(90));
            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Check to see that at some stage the right child is less than the left when
        /// when moving the hole down the tree.
        /// </summary>
        [TestMethod]
        public void RemoveRightChildLessThanLeftTest()
        {
            Heap<int> actual = new Heap<int>()
            {
                5,
                3,
                8,
                10,
                6,
                11,
                12,
                13
            };
            Heap<int> expected = new Heap<int>()
            {
                3,
                6,
                8,
                10,
                13,
                11,
                12
            };

            Assert.IsTrue(actual.Remove(5));
            Assert.AreEqual(7, actual.Count);
            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Check to see that at some stage the right child is greater than the left when
        /// when moving the hole down the tree.
        /// </summary>
        [TestMethod]
        public void RemoveMaxRightChildGreaterTest()
        {
            Heap<int> actual = new Heap<int>(HeapType.Max)
            {
                46,
                23,
                44,
                66,
                51,
                32,
                17,
                8
            };
            Heap<int> expected = new Heap<int>(HeapType.Max)
            {
                66,
                46,
                44,
                23,
                8,
                32,
                17
            };

            Assert.IsTrue(actual.Remove(51));
            Assert.AreEqual(7, actual.Count);
            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Check to see that the correct array is returned.
        /// </summary>
        [TestMethod]
        public void ToArrayTest()
        {
            Heap<int> actual = new Heap<int>()
            {
                78,
                9,
                12,
                56,
                12,
                1,
            };
            int[] expected = { 1, 12, 9, 78, 56, 12 };

            CollectionAssert.AreEqual(expected, actual.ToArray());
        }

        /// <summary>
        /// Check to see that the correct value is returned when seeing if an item
        /// exists in the heap.
        /// </summary>
        [TestMethod]
        public void ContainsTest()
        {
            Heap<char> actual = new Heap<char>()
            {
                'g',
                'r',
                'a',
                'n',
                'v'
            };

            Assert.IsTrue(actual.Contains('a'));
            Assert.IsFalse(actual.Contains('l'));
        }

        /// <summary>
        /// Check to see that the Heap is restored to its default state.
        /// </summary>
        [TestMethod]
        public void ClearTest()
        {
            Heap<int> actual = new Heap<int>()
            {
                12,
                3,
                21,
                0
            };

            actual.Clear();

            Assert.AreEqual(0, actual.Count);
        }

    }
}
