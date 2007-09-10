using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dsa.DataStructures;
using System;

namespace Dsa.Test {

    /// <summary>
    /// Tests for DoublyLinkedListCollection.
    /// </summary>
    [TestClass]
    public class DoublyLinkedListCollectionTest {

        /// <summary>
        /// Test to see that AddLast adds a node onto the tail of the list.
        /// </summary>
        [TestMethod]
        public void AddLastTest() {
            DoublyLinkedListCollection<int> dll = new DoublyLinkedListCollection<int>();

            dll.AddLast(10);
            dll.AddLast(20);
            dll.AddLast(30);

            Assert.AreEqual<int>(10, dll.Head.Value);
            Assert.AreEqual<int>(20, dll.Head.Next.Value);
            Assert.AreEqual<int>(10, dll.Head.Next.Prev.Value);
            Assert.AreEqual<int>(30, dll.Tail.Value);
            Assert.AreEqual<int>(20, dll.Tail.Prev.Value);
        }

        /// <summary>
        /// Test to see that AddFirst adds a node to the head of the linked list.
        /// </summary>
        [TestMethod]
        public void AddFirstTest() {
            DoublyLinkedListCollection<int> dll = new DoublyLinkedListCollection<int>();

            dll.AddFirst(10);
            dll.AddFirst(20);

            Assert.AreEqual<int>(20, dll.Head.Value);
        }

        /// <summary>
        /// Test to see that a call to AddAfter raises the corrext exception when there are no nodes to add after.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void AddAfterNoNodesTest() {
            DoublyLinkedListCollection<int> dll = new DoublyLinkedListCollection<int>();

            dll.AddAfter(dll.Head, 10);
        }

        /// <summary>
        /// Test to see that the correct exception is raised when adding after a null node.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddAfterNullNodeTest() {
            DoublyLinkedListCollection<int> dll = new DoublyLinkedListCollection<int>();

            dll.AddLast(10); 
            dll.AddAfter(null, 10);
        }

        /// <summary>
        /// Test to see that calling AddAfter passing in the tail node updates the internal tail node pointer.
        /// </summary>
        [TestMethod]
        public void AddAfterTailTest() {
            DoublyLinkedListCollection<int> dll = new DoublyLinkedListCollection<int>();

            dll.AddLast(10);
            dll.AddAfter(dll.Head, 20);

            Assert.AreEqual<int>(20, dll.Tail.Value);
            Assert.AreEqual<int>(10, dll.Tail.Prev.Value);
        }

        /// <summary>
        /// Test to see that calling AddAfter passing in a node that isn't the tail results in the expected state.
        /// </summary>
        [TestMethod]
        public void AddAfterTest() {
            DoublyLinkedListCollection<int> dll = new DoublyLinkedListCollection<int>();

            dll.AddLast(10);
            dll.AddLast(20);
            dll.AddLast(30);
            dll.AddAfter(dll.Head.Next, 25);

            Assert.AreEqual<int>(25, dll.Head.Next.Next.Value);
            Assert.AreEqual<int>(20, dll.Head.Next.Next.Prev.Value);
            Assert.AreEqual<int>(30, dll.Head.Next.Next.Next.Value);
            Assert.AreEqual<int>(25, dll.Tail.Prev.Value);
        }

        /// <summary>
        /// Test to see that calling AddBefore results in the node being placed in the corret position in the DoublyLinkedList.
        /// </summary>
        [TestMethod]
        public void AddBeforeTest() {
        }

        /// <summary>
        /// Test to see that the IsEmpty method returns the correct value.
        /// </summary>
        [TestMethod]
        public void IEmptyTest() {
            DoublyLinkedListCollection<int> dll = new DoublyLinkedListCollection<int>();

            Assert.IsTrue(dll.IsEmpty());
        }

    }

}
