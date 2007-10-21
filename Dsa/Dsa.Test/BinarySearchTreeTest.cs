using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dsa.DataStructures;

namespace Dsa.Test
{

    /// <summary>
    /// BinarySearhTree(Of T) tests.
    /// </summary>
    [TestClass]
    public class BinarySearchTreeTest
    {

        /// <summary>
        /// Test to see that the fields are intialized correctly.
        /// </summary>
        [TestMethod]
        public void ConstructorTest()
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int>();

            Assert.IsNull(bst.Root);
        }

        /// <summary>
        /// Test to see that the insert asserts the correct state changes.
        /// </summary>
        [TestMethod]
        public void InsertRootNullTest()
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int>();

            bst.Insert(10);

            Assert.AreEqual(10, bst.Root.Value);
        }

        /// <summary>
        /// Test to see that the state of the BinarySearchTree is updated correctly when inserting
        /// more than one node into the tree.
        /// </summary>
        [TestMethod]
        public void InsertTest()
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int>();

            bst.Insert(10);
            bst.Insert(20);
            bst.Insert(30);
            bst.Insert(5);
            bst.Insert(7);
            bst.Insert(3);

            Assert.AreEqual(20, bst.Root.Right.Value);
            Assert.AreEqual(30, bst.Root.Right.Right.Value);
            Assert.AreEqual(5, bst.Root.Left.Value);
            Assert.AreEqual(7, bst.Root.Left.Right.Value);
            Assert.AreEqual(3, bst.Root.Left.Left.Value);
        }

    }
}
