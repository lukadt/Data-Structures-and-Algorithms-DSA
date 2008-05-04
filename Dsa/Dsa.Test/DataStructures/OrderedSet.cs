using System.Collections.Generic;
using Dsa.DataStructures;
using Dsa.Test.Utility;
using NUnit.Framework;

namespace Dsa.Test.DataStructures
{
    /// <summary>
    /// Tests for OrderedSet.
    /// </summary>
    [TestFixture]
    public class SetTest
    {
        /// <summary>
        /// Check to see that items are added correctly and duplicate values are ignored.
        /// </summary>
        [Test]
        public void AddTest()
        {
            OrderedSet<int> actual = new OrderedSet<int> {43, 17, 34, 78, 17, 56, 78};

            Assert.AreEqual(5, actual.Count);
        }

        /// <summary>
        /// Check to see that calling Clear returns the Set to its initial state.
        /// </summary>
        [Test]
        public void ClearTest()
        {
            OrderedSet<int> actual = new OrderedSet<int> {15, 16, 89};

            actual.Clear();

            Assert.AreEqual(0, actual.Count);
        }

        /// <summary>
        /// Check to see that that Contains returns the correct value.
        /// </summary>
        [Test]
        public void ContainsTest()
        {
            OrderedSet<int> actual = new OrderedSet<int> {12, 19, 1, 23};

            Assert.IsTrue(actual.Contains(19));
            Assert.IsFalse(actual.Contains(99));
        }

        /// <summary>
        /// Check to see that an item is removed correctly from the Set.
        /// </summary>
        [Test]
        public void RemoveTest()
        {
            OrderedSet<int> actual = new OrderedSet<int> {10, 8, 9, 23, 9};

            Assert.IsTrue(actual.Remove(9));
            Assert.IsFalse(actual.Remove(9));
        }

        /// <summary>
        /// Check to see that an item with the correct value and indexes is returned.
        /// </summary>
        [Test]
        public void ToArrayTest()
        {
            OrderedSet<int> set = new OrderedSet<int> {10, 8, 23, 1, 23, 56};
            int[] expected = { 1, 8, 10, 23, 56 };

            int[] actual = set.ToArray();

            CollectionAssert.AreEqual(actual, expected);
        }

        /// <summary>
        /// Check to see that a non-null enumerator is returned.
        /// </summary>
        [Test]
        public void GetEnumeratorTest()
        {
            OrderedSet<int> set = new OrderedSet<int> {10, 23, 1, 89, 34};
            List<int> expected = new List<int>();

            foreach (int item in set) expected.Add(item);

            Assert.IsNotNull(set.GetEnumerator());
            CollectionAssert.AreEqual(set, expected);
        }

        /// <summary>
        /// Check to see that the comparer is not null.
        /// </summary>
        [Test]
        public void ComparerTest()
        {
            IComparer<Coordinate> comaparer = new CoordinateComparer();
            IComparerProvider<Coordinate> actual = new OrderedSet<Coordinate>(comaparer);

            Assert.IsNotNull(actual.Comparer);
        }
    }
}