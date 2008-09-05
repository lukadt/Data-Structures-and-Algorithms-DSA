using System.Collections.Generic;
using Dsa.DataStructures;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace Dsa.Test.DataStructures
{
    /// <summary>
    /// Tests for Avl tree.
    /// </summary>
    [TestFixture]
    public class AvlTreeTest
    {
        /// <summary>
        /// Check to see wheter the correct balance factor is retrieved
        /// </summary>
        [Test]
        public void BalanceFactorTest()
        {
            AvlTree<int> actual = new AvlTree<int> {10,20};            
            AvlTreeNode<int> root = actual.FindNode(10);
            AvlTreeNode<int> leaf = actual.FindNode(20);
            
            Assert.AreEqual(actual.GetBalanceFactor(root), -1);
            Assert.AreEqual(actual.GetBalanceFactor(leaf), 0);
        }
        
        /// <summary>
        /// Check to see that the tree structure is correct after inserting nodes which will cause a right rebalancing.
        /// </summary>
        [Test]
        public void SingleLeftRotationTest()
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
        public void SingleRightRotationTest()
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
        public void DoubleRightLeftRotationTest()
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
        public void DoubleLeftRightRotationTest()
        {
            AvlTree<int> actual = new AvlTree<int> { 10, 5, 7 };

            Assert.AreEqual(7, actual.Root.Value);
            Assert.AreEqual(5, actual.Root.Left.Value);
            Assert.AreEqual(10, actual.Root.Right.Value);
        }


        /// <summary>
        /// Massive insertion with multiple rotations and rebalancing
        /// </summary>
        [Test]
        public void MassiveInsertionTest()
        {
            AvlTree<int> actual = new AvlTree<int>() { 10, 7, 2, 5, 11, 3, 19 };
            Assert.AreEqual(7, actual.Root.Value);
            Assert.AreEqual(3, actual.Root.Left.Value);
            Assert.AreEqual(2, actual.Root.Left.Left.Value);
            Assert.AreEqual(11, actual.Root.Right.Value);
            Assert.AreEqual(10, actual.Root.Right.Left.Value);
            Assert.AreEqual(19, actual.Root.Right.Right.Value);
            Assert.AreEqual(5, actual.Root.Left.Right.Value);
        }


        /// <summary>
        /// Massive insertion with multiple rotations and rebalancing
        /// </summary>
        [Test]
        public void TenNodesInsertionTest()
        {
            AvlTree<int> actual = new AvlTree<int>() { 1,2,10,7,3,6,9,4,8,15 };
            Assert.AreEqual(7, actual.Root.Value);
            Assert.AreEqual(3, actual.Root.Left.Value);
            Assert.AreEqual(2, actual.Root.Left.Left.Value);
            Assert.AreEqual(1, actual.Root.Left.Left.Left.Value);
            Assert.AreEqual(9, actual.Root.Right.Value);
            Assert.AreEqual(8, actual.Root.Right.Left.Value);
            Assert.AreEqual(10, actual.Root.Right.Right.Value);
            Assert.AreEqual(15, actual.Root.Right.Right.Right.Value);
        }

        /// <summary>
        /// Check that count is correct after inserting some values.
        /// </summary>
        [Test]
        public void CountTest()
        {
            AvlTree<int> actual = new AvlTree<int> { 12, 3, 4 };

            Assert.AreEqual(3, actual.Count);
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

        /// <summary>
        /// Check to see that the AVLTree is in the correct state after invoking copy constructor.
        /// </summary>
        [Test]
        public void CopyConstructorTest()
        {
            List<int> values = new List<int> { 23, 45, 1, 19, 56 };
            AvlTree<int> avlTree = new AvlTree<int>(values);
            List<int> expected = new List<int> { 23, 1, 19, 45, 56 };
            List<int> actual = new List<int>();

            foreach(int i in avlTree)
            {
                actual.Add(i);
            }

            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }
    }
}
