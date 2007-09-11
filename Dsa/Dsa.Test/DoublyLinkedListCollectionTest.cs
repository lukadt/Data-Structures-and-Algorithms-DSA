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
        /// Test to see that calling AddBefore results in the node being placed in the correct position in the DoublyLinkedList when
        /// adding before the head node.
        /// </summary>
        [TestMethod]
        public void AddBeforeHeadTest() {
            DoublyLinkedListCollection<int> dll = new DoublyLinkedListCollection<int>();

            dll.AddLast(10);
            dll.AddBefore(dll.Head, 5);

            Assert.AreEqual<int>(5, dll.Head.Value);
            Assert.AreEqual<int>(10, dll.Head.Next.Value);
            Assert.AreEqual<int>(5, dll.Head.Next.Prev.Value);
        }

        /// <summary>
        /// Test to see that when calling AddBefore the node is placed in the correct position within the linked list.
        /// </summary>
        [TestMethod]
        public void AddBeforeTest() {
            DoublyLinkedListCollection<int> dll = new DoublyLinkedListCollection<int>();

            dll.AddLast(10);
            dll.AddLast(30);
            dll.AddBefore(dll.Head.Next, 20);

            Assert.AreEqual<int>(20, dll.Head.Next.Value);
            Assert.AreEqual<int>(10, dll.Head.Next.Prev.Value);
            Assert.AreEqual<int>(30, dll.Head.Next.Next.Value);
            Assert.AreEqual<int>(20, dll.Tail.Prev.Value);
        }

        /// <summary>
        /// Test to see that calling AddBefore when the list is empty results in the correct exception being raised.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void AddBeforeEmptyListTest() {
            DoublyLinkedListCollection<int> dll = new DoublyLinkedListCollection<int>();

            dll.AddBefore(dll.Head, 10);
        }

        /// <summary>
        /// Test to see that a call to AddBefore when passing in a null node raises the correct exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddBeforeNullNode() {
            DoublyLinkedListCollection<int> dll = new DoublyLinkedListCollection<int>();

            dll.AddLast(10);
            dll.AddBefore(dll.Head.Next, 20);
        }

        /// <summary>
        /// Test to see that the IsEmpty method returns the correct value.
        /// </summary>
        [TestMethod]
        public void IEmptyTest() {
            DoublyLinkedListCollection<int> dll = new DoublyLinkedListCollection<int>();

            Assert.IsTrue(dll.IsEmpty());
        }

        /// <summary>
        /// Test to see that a call to RemoveLast on a non empty list results in the expected behaviour.
        /// </summary>
        [TestMethod]
        public void RemoveLastTest() {
            DoublyLinkedListCollection<int> dll = new DoublyLinkedListCollection<int>();

            dll.AddLast(10);
            dll.RemoveLast();

            Assert.IsTrue(dll.IsEmpty());
            Assert.IsNull(dll.Tail);
        }

        /// <summary>
        /// Test to see that a call to RemoveLast when there are two nodes in the linked list reassigns the tail node.
        /// </summary>
        [TestMethod]
        public void RemoveLastTwoNodesTest() {
            DoublyLinkedListCollection<int> dll = new DoublyLinkedListCollection<int>();

            dll.AddLast(10);
            dll.AddLast(20);
            dll.RemoveLast();

            Assert.AreEqual<int>(10, dll.Head.Value);
            Assert.AreEqual<int>(10, dll.Tail.Value);
            Assert.IsNull(dll.Tail.Next);
            Assert.IsNull(dll.Head.Next);
        }

        /// <summary>
        /// Test to see that calling RemoveLast when there are more than two nodes results in the expected behaviour.
        /// </summary>
        [TestMethod]
        public void RemoveTestMultipleNodesTest() {
            DoublyLinkedListCollection<int> dll = new DoublyLinkedListCollection<int>();

            dll.AddLast(10);
            dll.AddLast(20);
            dll.AddLast(30);
            dll.RemoveLast();

            Assert.AreEqual<int>(20, dll.Tail.Value);
            Assert.IsNull(dll.Tail.Next);
        }

        /// <summary>
        /// Test to see that calling RemoveLast on an empty list throws the correct exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void RemoveLastEmptyListTest() {
            DoublyLinkedListCollection<int> dll = new DoublyLinkedListCollection<int>();

            dll.RemoveLast();
        }

    }

}
