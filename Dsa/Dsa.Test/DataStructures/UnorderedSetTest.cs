using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dsa.DataStructures;
using System;

namespace Dsa.Test.DataStructures
{
    /// <summary>
    /// Tests for UnorderedSet(Of T).
    /// </summary>
    [TestClass]
    public class UnorderedSetTest
    {

        /// <summary>
        /// Check to see that the item is added to the set.
        /// </summary>
        [TestMethod]
        public void AddTest()
        {
            UnorderedSet<int> actual = new UnorderedSet<int>()
            {
                5,
                12,
                15,
                5,
                12
            };
            UnorderedSet<int> expected = new UnorderedSet<int>()
            {
                5, 
                12, 
                15
            };

            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Check to see that the items in the set are cleared.
        /// </summary>
        [TestMethod]
        public void ClearTest()
        {
            UnorderedSet<int> actual = new UnorderedSet<int>()
            {
                3,
                4,
                5
            };

            actual.Clear();

            Assert.AreEqual(0, actual.Count);
        }

        /// <summary>
        /// Check to see that contains returns the correct value.
        /// </summary>
        [TestMethod]
        public void ContainsTest()
        {
            UnorderedSet<char> actual = new UnorderedSet<char>()
            {
                'a',
                'b',
                'c'
            };

            Assert.IsTrue(actual.Contains('b'));
            Assert.IsFalse(actual.Contains('d'));
        }

        /// <summary>
        /// Check to see that calling Remove leaves the set in the correct state.
        /// </summary>
        [TestMethod]
        public void RemoveTest()
        {
            UnorderedSet<int> actual = new UnorderedSet<int>()
            {
                4, 
                1, 
                89,
                90
            };

            Assert.IsTrue(actual.Remove(4));
            Assert.IsFalse(actual.Remove(899));

            UnorderedSet<int> expected = new UnorderedSet<int>()
            {
                1,
                89,
                90
            };

            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Check to see that the array items are returned in the correct order.
        /// </summary>
        [TestMethod]
        public void ToArrayTest()
        {
            UnorderedSet<char> set = new UnorderedSet<char>()
            {
                'a',
                'r',
                'd',
                'f'
            };
            char[] actual = set.ToArray();
            char[] expected = { 'a', 'r', 'd', 'f' };

            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Check to see that the correct exception is thrown when calling ToArray on a set with 0 items.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ToArrayNoItemsInUnorderedSetTest()
        {
            UnorderedSet<int> actual = new UnorderedSet<int>();

            actual.ToArray();
        }

    }
}
