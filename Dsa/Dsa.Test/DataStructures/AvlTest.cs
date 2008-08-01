﻿using NUnit.Framework;
using Dsa.DataStructures;

namespace Dsa.Test.DataStructures
{
    /// <summary>
    /// Tests for Avl tree.
    /// </summary>
    [TestFixture]
    public class AvlTest
    {
        /// <summary>
        /// Check to see that the tree structure is correct after inserting nodes which will cause a rebalancing.
        /// </summary>
        [Test]
        public void AddTestSingleRotationInvolved()
        {
            Avl<int> actual = new Avl<int> { 10, 20, 30 };

            Assert.AreEqual(20, actual.Root.Value);
            Assert.AreEqual(10, actual.Root.Left.Value);
            Assert.AreEqual(30, actual.Root.Right.Value);
        }

        /// <summary>
        /// Check to make sure tree is in the correct state after a double rotation.
        /// </summary>
        [Test]
        public void DoubleRotationTest()
        {
            Avl<int> actual = new Avl<int> { 10, 20, 15 };

            Assert.AreEqual(15, actual.Root.Value);
            Assert.AreEqual(10, actual.Root.Left.Value);
            Assert.AreEqual(20, actual.Root.Right.Value);
        }

        /// <summary>
        /// Check that count is correct after inserting some values.
        /// </summary>
        [Test]
        public void CountTest()
        {
            Avl<int> acutal = new Avl<int> { 12, 3, 4 };

            Assert.AreEqual(3, acutal.Count);
        }
    }
}
