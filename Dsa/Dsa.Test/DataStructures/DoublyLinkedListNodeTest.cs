using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dsa.DataStructures;

namespace Dsa.Test
{

    /// <summary>
    /// Tests for DoublyLinkedListNode.
    /// </summary>
    [TestClass]
    public class DoublyLinkedListNodeTest
    {

        /// <summary>
        /// Check to see that a node is created and its state initialized correctly.
        /// </summary>
        [TestMethod]
        public void ConstructorTest()
        {
            DoublyLinkedListNode<int> n = new DoublyLinkedListNode<int>(10);

            Assert.AreEqual(10, n.Value);
            Assert.IsNull(n.Previous);
            Assert.IsNull(n.Next);
        }

    }

}
