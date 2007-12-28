using System;
using Dsa.DataStructures;
using Dsa.Test.Utility;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Dsa.Test.DataStructures
{

    /// <summary>
    /// Tests for Set.
    /// </summary>
    [TestClass]
    public class SetTest
    {

        /// <summary>
        /// Check to see that items are added correctly and duplicate values are ignored.
        /// </summary>
        [TestMethod]
        public void AddTest()
        {
            Set<int> actual = new Set<int>()
            {
                43, 
                17, 
                34, 
                78,
                17,
                56,
                78
            };

            Assert.AreEqual(5, actual.Count);
        }

        /// <summary>
        /// Check to see that calling Clear returns the Set to its initial state.
        /// </summary>
        [TestMethod]
        public void ClearTest()
        {
            Set<int> actual = new Set<int>()
            {
                15, 
                16,
                89
            };

            actual.Clear();

            Assert.AreEqual(0, actual.Count);
        }

        /// <summary>
        /// Check to see that that Contains returns the correct value.
        /// </summary>
        [TestMethod]
        public void ContainsTest()
        {
            Set<int> actual = new Set<int>()
            {
                12,
                19,
                1,
                23
            };

            Assert.IsTrue(actual.Contains(19));
            Assert.IsFalse(actual.Contains(99));
        }

        /// <summary>
        /// Check to see that an item is removed correctly from the Set.
        /// </summary>
        [TestMethod]
        public void RemoveTest()
        {
            Set<int> actual = new Set<int>()
            {
                10,
                8,
                9,
                23,
                9
            };

            Assert.IsTrue(actual.Remove(9));
            Assert.IsFalse(actual.Remove(9));
        }

        /// <summary>
        /// Check to see that an item with the correct value and indexes is returned.
        /// </summary>
        [TestMethod]
        public void ToArrayTest()
        {
            Set<int> set = new Set<int>()
            {
                10,
                8,
                23,
                1,
                23,
                56
            };

            int[] actual = set.ToArray();
            int[] expected = { 1, 8, 10, 23, 56 };

            CollectionAssert.AreEqual(actual, expected);
        }

        /// <summary>
        /// Check to see that the correct exception is thrown when calling ToArray on a Set with no items.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ToArraySetEmptyTest()
        {
            Set<int> actual = new Set<int>();

            actual.ToArray();
        }

        /// <summary>
        /// Check to see that a non-null enumerator is returned.
        /// </summary>
        [TestMethod]
        public void GetEnumeratorTest()
        {
            Set<int> set = new Set<int>()
            {
                10,
                23,
                1,
                89,
                34
            };

            List<int> expected = new List<int>();
            foreach (int item in set)
            {
                expected.Add(item);
            }

            Assert.IsNotNull(set.GetEnumerator());
            CollectionAssert.AreEqual(set, expected);
        }

        /// <summary>
        /// Check to see that the comparer is not null.
        /// </summary>
        [TestMethod]
        public void ComparerTest()
        {
            IComparer<Coordinate> comaparer = new CoordinateComparer();
            IComparerProvider<Coordinate> actual = new Set<Coordinate>(comaparer);

            Assert.IsNotNull(actual.Comparer);
        }

        /// <summary>
        /// Check to see that calling Set.Union results in the correct set.
        /// </summary>
        [TestMethod]
        public void SetUnionTest()
        {
            Set<int> set1 = new Set<int>()
            {
                10, 
                4,
                6
            };
            Set<int> set2 = new Set<int>()
            {
                1,
                5,
                90
            };

            Set<int> actual = Set<int>.Union(set1, set2);
            Set<int> expected = new Set<int>()
            {
                10,
                4,
                6,
                1,
                5,
                90
            };

            CollectionAssert.AreEqual(actual, expected);
        }

        /// <summary>
        /// Check to see that when the first set is null the correct exception is raised.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SetUnionSet1NullTest()
        {
            Set<int>.Union(null, null);
        }

        /// <summary>
        /// Check to see that when the second set is null the correct exception is raised.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SetUnionSet2NullTest()
        {
            Set<int> actual = new Set<int>();

            Set<int>.Union(actual, null);
        }

        /// <summary>
        /// Check to see that when two empty sets are unioned that null is returned to denote 
        /// an empty set.
        /// </summary>
        [TestMethod]
        public void SetUnionEmptySetTest()
        {
            Set<int> set1 = new Set<int>();
            Set<int> set2 = new Set<int>();

            Assert.IsNull(Set<int>.Union(set1, set2));
        }

        /// <summary>
        /// Check to see that a set intersection returns the correct set.
        /// </summary>
        [TestMethod]
        public void SetIntersectionTest()
        {
            Set<int> set1 = new Set<int>()
            {
                5,
                8,
                12,
                15
            };
            Set<int> set2 = new Set<int>()
            {
                20, 
                1,
                12,
                15
            };

            Set<int> expected = new Set<int>()
            {
                12,
                15
            };

            CollectionAssert.AreEqual(expected, Set<int>.Intersection(set1, set2));
        }

        /// <summary>
        /// Check to see that if the intersection of two sets contains 0 items then null
        /// is returned to indicate an empty set.
        /// </summary>
        [TestMethod]
        public void SetIntersectionNoCommonItemsTest()
        {
            Set<int> set1 = new Set<int>()
            {
                12,
                4
            };
            Set<int> set2 = new Set<int>()
            {
                1
            };

            Assert.IsNull(Set<int>.Intersection(set1, set2));
        }

        /// <summary>
        /// Check to see that the correct exception is raised when the first set is null.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SetIntersectionSet1IsNullTest()
        {
            Set<int>.Intersection(null, null);
        }

        /// <summary>
        /// Check to see that the correct exception is raised when the second set is null.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SetIntersectionSet2IsNullTest()
        {
            Set<int> set1 = new Set<int>();

            Set<int>.Intersection(set1, null);
        }

    }

}
