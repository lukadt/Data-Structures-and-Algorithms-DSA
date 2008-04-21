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
        /// Check to see that the correct value is returned representing the number of permutations.
        /// </summary>
        [TestMethod]
        public void PermutationTest()
        {
            UnorderedSet<int> actual = new UnorderedSet<int> {10, 12, 45, 1};

            Assert.AreEqual(12, actual.Permutations(2));
        }

        /// <summary>
        /// Check to see that the correct exception is raised when the set is null.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PermutationSetNullTest()
        {
            const UnorderedSet<int> actual = null;

            actual.Permutations(2);
        }

        /// <summary>
        /// Check to see that the correct value is returned when trying to attain permutations for an empty set.
        /// </summary>
        [TestMethod]
        public void PermutationsEmptySetTest()
        {
            UnorderedSet<int> actual = new UnorderedSet<int>();

            Assert.AreEqual(0, actual.Permutations(2));
        }

        /// <summary>
        /// Check to see that the correct exception is raised when the number of item permutations is 0.
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
