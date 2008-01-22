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
        /// Check to see that MaxHeap affects the state of the Heap appropriatley.
        /// </summary>
        [TestMethod]
        public void GetEnumeratorTest()
        {
            Heap<int> actual = new Heap<int>()
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

    }
}
