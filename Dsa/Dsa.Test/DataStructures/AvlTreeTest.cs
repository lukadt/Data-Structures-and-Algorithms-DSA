using NUnit.Framework;
using Dsa.DataStructures;
using NUnit.Framework.SyntaxHelpers;
using System.Collections.Generic;

namespace Dsa.Test.DataStructures
{
    /// <summary>
    /// Tests for Avl tree.
    /// </summary>
    [TestFixture]
    public class AvlTreeTest
    {
        /// <summary>
        /// Check to see that the tree structure is correct after inserting nodes which will cause a right rebalancing.
        /// </summary>
        [Test]
        public void SingleRightRotationTest()
        {
            AvlTree<int> actual = new AvlTree<int> { 10, 20, 30 };

            Assert.AreEqual(20, actual.Root.Value);
            Assert.AreEqual(10, actual.Root.Left.Value);
            Assert.AreEqual(30, actual.Root.Right.Value);
        }

        /// <summary>
        /// Check to see that the tree structure is correct after inserting nodes which will cause a left rebalancing.
        /// </summary>
        [Test]
        public void SingleLeftRotationTest()
        {
            AvlTree<int> actual = new AvlTree<int> { 10, 7, 4 };

            Assert.AreEqual(7, actual.Root.Value);
            Assert.AreEqual(4, actual.Root.Left.Value);
            Assert.AreEqual(10, actual.Root.Right.Value);
        }

        /// <summary>
        /// Check to make sure tree is in the correct state after a double right rotation.
        /// </summary>
        [Test]
        public void DoubleRightRotationTest()
        {
            AvlTree<int> actual = new AvlTree<int> { 10, 20, 15 };

            Assert.AreEqual(15, actual.Root.Value);
            Assert.AreEqual(10, actual.Root.Left.Value);
            Assert.AreEqual(20, actual.Root.Right.Value);
        }

        /// <summary>
        /// Check to make sure tree is in the correct state after a double right rotation.
        /// </summary>
        [Test]
        public void DoubleLeftRotationTest()
        {
            AvlTree<int> actual = new AvlTree<int> { 10, 5, 7 };

            Assert.AreEqual(7, actual.Root.Value);
            Assert.AreEqual(5, actual.Root.Left.Value);
            Assert.AreEqual(10, actual.Root.Right.Value);
        }
        /// <summary>
        /// Check that count is correct after inserting some values.
        /// </summary>
        [Test]
        public void CountTest()
        {
            AvlTree<int> acutal = new AvlTree<int> { 12, 3, 4 };

            Assert.AreEqual(3, acutal.Count);
        }

        /// <summary>
        /// Check to see that traversal is correct.
        /// </summary>
        [Test]
        public void TraversalTest()
        {
            AvlTree<int> avlTree = new AvlTree<int> { 10, 20, 30 };
            List<int> expected = new List<int> { 10, 20, 30 };
            List<int> actual = new List<int>();

            foreach (int value in avlTree.GetInorderEnumerator())
            {
                actual.Add(value);
            }

            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }
    }
}
