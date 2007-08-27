using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dsa.DataStructures;

namespace Dsa.Test {

    [TestClass]
    public class SinglyLinkedListNodeTest {

        /// <summary>
        /// Test to see that the expected Int32 value of a node is returned.
        /// </summary>
        [TestMethod]
        public void ValueIntTest() {
            SinglyLinkedListNode<int> n = new SinglyLinkedListNode<int>(10);
            Assert.AreEqual<int>(10, n.Value);
        }

        /// <summary>
        /// Test to see that the expected string reference type value of a node is returned.
        /// </summary>
        [TestMethod]
        public void ValueStringTest() {
            SinglyLinkedListNode<string> n = new SinglyLinkedListNode<string>("Granville");
            Assert.AreEqual<string>("Granville", n.Value);
        }

        /// <summary>
        /// Test to see that the next node of a node is correct.
        /// </summary>
        [TestMethod]
        public void NextTest() {
            SinglyLinkedListNode<int> n1 = new SinglyLinkedListNode<int>(10);
            SinglyLinkedListNode<int> n2 = new SinglyLinkedListNode<int>(20);
            n1.Next = n2;
            Assert.AreEqual<int>(20, n1.Next.Value);
        }

    }

}
