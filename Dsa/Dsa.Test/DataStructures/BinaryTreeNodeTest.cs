using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dsa.DataStructures;

namespace Dsa.Test
{

    /// <summary>
    /// BinaryTreeNode(Of T) tests.
    /// </summary>
    [TestClass]
    public class BinaryTreeNodeTest
    {

        /// <summary>
        /// Test to see that a BinaryTreeNode is initialzed to the correct
        /// values.
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
        /// Test to see that child nodes are appended properly.
        /// </summary>
        [TestMethod]
        public void AssignNodeTest()
        {
            BinaryTreeNode<int> node = new BinaryTreeNode<int>(5);

            node.Right = new BinaryTreeNode<int>(10);

            Assert.AreEqual(10, node.Right.Value);
        }

    }
}
