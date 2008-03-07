using System;
using Dsa.Algorithms;
using Dsa.DataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dsa.Test.Algorithms
{
    /// <summary>
    /// Tests for Set algorithms
    /// </summary>
    [TestClass]
    public class SetsTest
    {

        /// <summary>
        /// Check to see that calling Set.Union results in the correct set.
        /// </summary>
        [TestMethod]
        public void SetUnionTest()
        {
            OrderedSet<int> set1 = new OrderedSet<int>()
            {
                10, 
                4,
                6
            };
            OrderedSet<int> set2 = new OrderedSet<int>()
            {
                1,
                5,
                90
            };

            OrderedSet<int> actual = set1.Union(set2) as OrderedSet<int>;
            OrderedSet<int> expected = new OrderedSet<int>()
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
            UnorderedSet<int> actual = null;

            actual.Union(new UnorderedSet<int>());
        }

        /// <summary>
        /// Check to see that when the second set is null the correct exception is raised.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SetUnionSet2NullTest()
        {
            OrderedSet<int> actual = new OrderedSet<int>();

            actual.Union(null);
        }

        /// <summary>
        /// Check to see that when two empty sets are unioned that null is returned to denote 
        /// an empty set.
        /// </summary>
        [TestMethod]
        public void SetUnionEmptySetTest()
        {
            OrderedSet<int> set1 = new OrderedSet<int>();
            OrderedSet<int> set2 = new OrderedSet<int>();

            Assert.IsNull(set1.Union(set2));
        }

        /// <summary>
        /// Check to see that a set intersection returns the correct set.
        /// </summary>
        [TestMethod]
        public void SetIntersectionTest()
        {
            OrderedSet<int> set1 = new OrderedSet<int>()
            {
                5,
                8,
                12,
                15
            };
            OrderedSet<int> set2 = new OrderedSet<int>()
            {
                20, 
                1,
                12,
                15
            };

            OrderedSet<int> expected = new OrderedSet<int>()
            {
                12,
                15
            };

            CollectionAssert.AreEqual(expected, set1.Intersection(set2));
        }

        /// <summary>
        /// Check to see that if the intersection of two sets contains 0 items then null
        /// is returned to indicate an empty set.
        /// </summary>
        [TestMethod]
        public void SetIntersectionNoCommonItemsTest()
        {
            OrderedSet<int> set1 = new OrderedSet<int>()
            {
                12,
                4
            };
            OrderedSet<int> set2 = new OrderedSet<int>()
            {
                1
            };

            Assert.IsNull(set1.Intersection(set2));
        }

        /// <summary>
        /// Check to see that the correct exception is raised when the first set is null.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SetIntersectionSet1IsNullTest()
        {
            OrderedSet<int> actual = null;

            actual.Intersection(new OrderedSet<int>());
        }

        /// <summary>
        /// Check to see that the correct exception is raised when the second set is null.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SetIntersectionSet2IsNullTest()
        {
            OrderedSet<int> set1 = new OrderedSet<int>();

            set1.Intersection(null);
        }

        /// <summary>
        /// Check to see that when unioning two types of set the expected set is returned.
        /// </summary>
        [TestMethod]
        public void UnionOfTwoDifferentSetsTest()
        {
            OrderedSet<int> s1 = new OrderedSet<int>()
            {
                1,
                78,
                9
            };
            UnorderedSet<int> s2 = new UnorderedSet<int>()
            {
                8,
                9,
                12
            };

            UnorderedSet<int> expected = new UnorderedSet<int>()
            {
                1,
                8,
                9,
                12,
                78
            };

            CollectionAssert.AreEqual(expected, s1.Union(s2));
        }

        /// <summary>
        /// Check to see that when intersectioning two different types of set the expected set is returned.
        /// </summary>
        [TestMethod]
        public void IntersectionTwoDifferentSetsTest()
        {
            UnorderedSet<char> s1 = new UnorderedSet<char>()
            {
                'a',
                'r',
                'f'
            };
            OrderedSet<char> s2 = new OrderedSet<char>()
            {
                't',
                'r',
                'f',
                'b'
            };

            UnorderedSet<char> expected = new UnorderedSet<char>()
            {
                'f',
                'r'
            };

            CollectionAssert.AreEqual(expected, s1.Intersection(s2));
        }

        /// <summary>
        /// Check to see that the correct value is returned representing the number of permutations.
        /// </summary>
        [TestMethod]
        public void PermutationTest()
        {
            UnorderedSet<int> actual = new UnorderedSet<int>()
            {
                10,
                12,
                45,
                1
            };

            Assert.AreEqual(12, actual.Permutations(2));
        }

        /// <summary>
        /// Check to see that the correct exception is raised when the set is null.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PermutationSetNullTest()
        {
            UnorderedSet<int> actual = null;

            actual.Permutations(2);
        }

        /// <summary>
        /// Check to see that the correct value is returned when tryin to attain permutations for an empty set.
        /// </summary>
        [TestMethod]
        public void PermutationsEmptySetTest()
        {
            UnorderedSet<int> actual = new UnorderedSet<int>();

            Assert.AreEqual(0, actual.Permutations(2));
        }

        /// <summary>
        /// Check to see that the correct exception is raised when the number of item permutations is
        /// 0.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void PerumtationsEmptySetZeroItems()
        {
            UnorderedSet<int> actual = new UnorderedSet<int>();

            actual.Permutations(0);
        }

    }
}
