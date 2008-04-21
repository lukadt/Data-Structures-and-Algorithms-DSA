using Dsa.DataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dsa.Test.DataStructures
{
    /// <summary>
    /// BinaryTreeNode(Of T) tests.
    /// </summary>
    [TestClass]
    public class BinaryTreeNodeTest
    {
        /// <summary>
        /// Check to see that a BinaryTreeNode is initialized to the correct values.
        /// </summary>
        [TestMethod]
        public void BinaryTreeNodeConstructorTest()
        {
            BinaryTreeNode<int> node = new BinaryTreeNode<int>(10);
            
            Assert.AreEqual(10, node.Value);
            Assert.IsNull(node.Left);
            Assert.IsNull(node.Right);
        }

        /// <summary>
        /// Check to see that child nodes are appended properly.
        /// </summary>
        [TestMethod]
        public void AssignNodeTest()
        {
            BinaryTreeNode<int> node = new BinaryTreeNode<int>(5) {Right = new BinaryTreeNode<int>(10)};

            Assert.AreEqual(10, node.Right.Value);
        }
    }
}