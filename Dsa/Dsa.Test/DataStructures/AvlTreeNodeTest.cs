using Dsa.DataStructures;
using NUnit.Framework;

namespace Dsa.Test.DataStructures
{
    /// <summary>
    /// AvlTreeNode(Of T) tests.
    /// </summary>
    [TestFixture]
    public sealed class AvlTreeNodeTest
    {
        /// <summary>
        /// Check to see that an AvlTreeNode is initialized to the correct values.
        /// </summary>
        [Test]
        public void AvlTreeNodeConstructorTest()
        {
            AvlTreeNode<int> node = new AvlTreeNode<int>(10);
            
            Assert.AreEqual(10, node.Value);
            Assert.IsNull(node.Left);
            Assert.IsNull(node.Right);
        }

        /// <summary>
        /// Check to see that child nodes are appended properly.
        /// </summary>
        [Test]
        public void AssignNodeTest()
        {
            AvlTreeNode<int> node = new AvlTreeNode<int>(5) {Left = new AvlTreeNode<int>(3)};

            Assert.AreEqual(3, node.Left.Value);
        }
    }
}