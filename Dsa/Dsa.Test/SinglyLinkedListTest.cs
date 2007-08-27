using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dsa.DataStructures;

namespace Dsa.Test {

    /// <summary>
    /// Tests for Dsa.DataStructures.SinglyLinkedList.
    /// </summary>
    [TestClass]
    public class SinglyLinkedListTest {

        /// <summary>
        /// Test to see that the SinglyLinkedList reports as empty when it is.
        /// </summary>
        [TestMethod]
        public void IsEmptyTest() {
            SinglyLinkedList<int> sll = new SinglyLinkedList<int>();

            Assert.IsTrue(sll.IsEmpty());
        }

        /// <summary>
        /// Test to see that nodes are added correctly to the tail of the linked list.
        /// </summary>
        [TestMethod]
        public void AddLastTest() {
            SinglyLinkedList<int> sll = new SinglyLinkedList<int>();

            sll.AddLast(5);
            sll.AddLast(10);
            sll.AddLast(15);

            Assert.IsFalse(sll.IsEmpty());
            Assert.AreEqual<int>(5, sll.Head.Value);
            Assert.AreEqual<int>(10, sll.Head.Next.Value);
            Assert.AreEqual<int>(15, sll.Tail.Value);
        }

        /// <summary>
        /// Test to see that nodes are added correctly to the head of the linked list.
        /// </summary>
        [TestMethod]
        public void AddFirstTest() {
            SinglyLinkedList<int> sll = new SinglyLinkedList<int>();

            sll.AddFirst(10);
            sll.AddFirst(20);
            sll.AddFirst(30);

            Assert.AreEqual<int>(30, sll.Head.Value);
            Assert.AreEqual<int>(20, sll.Head.Next.Value);
            Assert.AreEqual<int>(10, sll.Tail.Value);
        }

        /// <summary>
        /// Test to see that the value of the Tail node is as expected.
        /// </summary>
        [TestMethod]
        public void HeadTest() {
            SinglyLinkedList<string> sll = new SinglyLinkedList<string>();

            sll.AddLast("Granville");

            Assert.AreEqual<string>("Granville", sll.Head.Value);
        }

        /// <summary>
        /// Test to see that the value of the Tail node is as expected.
        /// </summary>
        [TestMethod]
        public void TailTest() {
            SinglyLinkedList<int> sll = new SinglyLinkedList<int>();

            sll.AddLast(10);

            Assert.AreEqual<int>(10, sll.Tail.Value);
        }

        /// <summary>
        /// Test to see that the Count property returns the correct nummber.
        /// </summary>
        [TestMethod]
        public void CountTest() {
            SinglyLinkedList<string> sll = new SinglyLinkedList<string>();

            sll.AddLast("Granville");
            sll.AddLast("Barnett");

            Assert.AreEqual<int>(2, sll.Count);
        }

    }

}
