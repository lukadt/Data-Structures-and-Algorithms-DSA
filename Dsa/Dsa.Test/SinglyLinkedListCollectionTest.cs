﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dsa.DataStructures;

namespace Dsa.Test {

    /// <summary>
    /// Tests for Dsa.DataStructures.SinglyLinkedListCollection.
    /// </summary>
    [TestClass]
    public class SinglyLinkedListCollectionCollectionTest {

        /// <summary>
        /// Test to see that the SinglyLinkedListCollectionCollection reports as empty when it is.
        /// </summary>
        [TestMethod]
        public void IsEmptyTest() {
            SinglyLinkedListCollection<int> sll = new SinglyLinkedListCollection<int>();

            Assert.IsTrue(sll.IsEmpty());
        }

        /// <summary>
        /// Test to see that nodes are added correctly to the tail of the linked list.
        /// </summary>
        [TestMethod]
        public void AddLastTest() {
            SinglyLinkedListCollection<int> sll = new SinglyLinkedListCollection<int>();

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
            SinglyLinkedListCollection<int> sll = new SinglyLinkedListCollection<int>();

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
            SinglyLinkedListCollection<string> sll = new SinglyLinkedListCollection<string>();

            sll.AddLast("Granville");

            Assert.AreEqual<string>("Granville", sll.Head.Value);
        }

        /// <summary>
        /// Test to see that the value of the Tail node is as expected.
        /// </summary>
        [TestMethod]
        public void TailTest() {
            SinglyLinkedListCollection<int> sll = new SinglyLinkedListCollection<int>();

            sll.AddLast(10);

            Assert.AreEqual<int>(10, sll.Tail.Value);
        }

        /// <summary>
        /// Test to see that the Count property returns the correct nummber.
        /// </summary>
        [TestMethod]
        public void CountTest() {
            SinglyLinkedListCollection<string> sll = new SinglyLinkedListCollection<string>();

            sll.AddLast("Granville");
            sll.AddLast("Barnett");

            Assert.AreEqual<int>(2, sll.Count);
        }

        /// <summary>
        /// Test to see that SinglyLinkedListCollection returns the correct items from the collection. TEMP TEST.
        /// </summary>
        [TestMethod]
        public void ForeachTest() {
            SinglyLinkedListCollection<int> sll = new SinglyLinkedListCollection<int>();
            sll.AddLast(10);
            sll.AddLast(30);
            sll.AddLast(40);
            foreach (int i in sll) {
                Console.WriteLine(i);
            }
        }

        /// <summary>
        /// Test to see that the expected array is returned from a singly linked list that contains nodes.
        /// </summary>
        [TestMethod]
        public void ToArrayOfValidSinglyLinkedListCollectionTest() {
            SinglyLinkedListCollection<int> sll = new SinglyLinkedListCollection<int>();

            sll.AddLast(10);
            sll.AddLast(20);
            sll.AddLast(30);

            int[] expected = { 10, 20, 30 };

            CollectionAssert.AreEqual(expected, sll.ToArray());
        }

        /// <summary>
        /// Test to see that the expected exception is raised when ToArray is called on a singly linked list
        /// that has no nodes.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ToArrayOfInvalidSinglyLinkedListCollectionTest() {
            SinglyLinkedListCollection<int> sll = new SinglyLinkedListCollection<int>();
            sll.ToArray();
        }

        /// <summary>
        /// Test to make sure that removing the first node results in the expected behaviour.
        /// </summary>
        [TestMethod]
        public void RemoveLastValidSinglyLinkedListCollectionWithOnlyOneNodeTest() {
            SinglyLinkedListCollection<int> sll = new SinglyLinkedListCollection<int>();

            sll.AddLast(10);
            sll.RemoveLast();

            Assert.AreEqual<int>(0, sll.Count);
            Assert.IsTrue(sll.IsEmpty());
            Assert.IsNull(sll.Head);
            Assert.IsNull(sll.Tail);
        }

        /// <summary>
        /// Test to make sure that removing the last node results in the expected behaviour.
        /// </summary>
        [TestMethod]
        public void RemoveLastValidSinglyLinkedListCollectionWithMultipleNodesTest() {
            SinglyLinkedListCollection<int> sll = new SinglyLinkedListCollection<int>();

            sll.AddLast(10);
            sll.AddLast(20);
            sll.AddLast(30);
            sll.RemoveLast();

            Assert.AreEqual<int>(20, sll.Tail.Value);
            Assert.AreEqual<int>(2, sll.Count);
            Assert.IsNull(sll.Tail.Next);
        }

        /// <summary>
        /// Test to make sure that removing the last node results in the expected behaviour.
        /// </summary>
        [TestMethod]
        public void RemoveLastValidSinglyLinkedListCollectionWithMultipleNodesTest2() {
            SinglyLinkedListCollection<int> sll = new SinglyLinkedListCollection<int>();

            sll.AddLast(10);
            sll.AddLast(20);
            sll.AddLast(30);
            sll.RemoveLast();
            sll.RemoveLast();

            Assert.AreEqual<int>(10, sll.Tail.Value);
            Assert.AreEqual<int>(10, sll.Head.Value);
            Assert.AreEqual<int>(1, sll.Count);
            Assert.IsNull(sll.Tail.Next);
            Assert.IsNull(sll.Head.Next);
        }

        /// <summary>
        /// Test to make sure that removing all the nodes in a singly linked list using the RemoveLast method, then
        /// reassigning the head and tail returns the expected results.
        /// </summary>
        [TestMethod]
        public void RemoveLastValidSinglyLinkedListCollectionWithMultipleNodesAndReassingHeadAndTailTest() {
            SinglyLinkedListCollection<int> sll = new SinglyLinkedListCollection<int>();

            sll.AddLast(10);
            sll.AddLast(20);
            sll.AddLast(30);
            sll.AddFirst(5);
            sll.RemoveLast();
            sll.RemoveLast();
            sll.RemoveLast();
            sll.RemoveLast();
            sll.AddLast(1);

            Assert.AreEqual<int>(1, sll.Count);
            Assert.AreEqual<int>(1, sll.Head.Value);
            Assert.AreEqual<int>(1, sll.Tail.Value);
            Assert.IsNull(sll.Head.Next);
            Assert.IsNull(sll.Tail.Next);
        }

        /// <summary>
        /// Test to see that the appropriate exception is raised when calling RemoveLast on a singly linked list
        /// object containing no nodes.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void RemoveLastInvalidSinglyLinkedListCollectionTest() {
            SinglyLinkedListCollection<int> sll = new SinglyLinkedListCollection<int>();

            sll.AddLast(10);
            sll.RemoveLast();
            sll.RemoveLast();
        }

        /// <summary>
        /// Test to see that calling RemoveFirst on singly linked list with only 1 node results in the expected behaviour.
        /// </summary>
        [TestMethod]
        public void RemoveFirstValidSinglyLinkedListCollectionWithOnlyOneNodeTest() {
            SinglyLinkedListCollection<int> sll = new SinglyLinkedListCollection<int>();

            sll.AddLast(10);
            sll.RemoveFirst();

            Assert.AreEqual<int>(0, sll.Count);
            Assert.IsNull(sll.Head);
            Assert.IsNull(sll.Tail);
        }

        /// <summary>
        /// Test to see that when calling the RemoveFirst method on a singly linked list with more than one node
        /// results in the expected object state.
        /// </summary>
        [TestMethod]
        public void RemoveFirstValidSinglyLinkedListCollectionWithMultipleNodesTest() {
            SinglyLinkedListCollection<int> sll = new SinglyLinkedListCollection<int>();

            sll.AddLast(10);
            sll.AddLast(20);
            sll.AddFirst(30);
            sll.RemoveFirst();
            sll.RemoveFirst();

            Assert.AreEqual<int>(1, sll.Count);
            Assert.AreEqual<int>(20, sll.Head.Value);
            Assert.AreEqual<int>(20, sll.Tail.Value);
            Assert.IsNull(sll.Head.Next);
            Assert.IsNull(sll.Tail.Next);
        }

        /// <summary>
        /// Test to see that when calling the RemoveFirst method on a singly linked list with more than one node
        /// results in the expected object state.
        /// </summary>
        [TestMethod]
        public void RemoveFirstValidSinglyLinkedListCollectionWithMultipleNodesTest2() {
            SinglyLinkedListCollection<int> sll = new SinglyLinkedListCollection<int>();

            sll.AddFirst(40);
            sll.AddFirst(30);
            sll.AddFirst(20);
            sll.AddFirst(10);
            sll.AddLast(50);
            sll.RemoveFirst();
            sll.RemoveFirst();

            Assert.AreEqual<int>(30, sll.Head.Value);
            Assert.AreEqual<int>(50, sll.Tail.Value);
            Assert.AreEqual<int>(3, sll.Count);
        }

        /// <summary>
        /// Test to make sure that removing all the nodes in a singly linked list using the RemoveFirst method, then
        /// reassigning the head and tail returns the expected results.
        /// </summary>
        [TestMethod]
        public void RemoveFirstValidSinglyLinkedListCollectionWithMultipleNodesAndReassingHeadAndTailTest() {
            SinglyLinkedListCollection<int> sll = new SinglyLinkedListCollection<int>();

            sll.AddLast(20);
            sll.AddLast(30);
            sll.AddFirst(10);
            sll.RemoveFirst();
            sll.RemoveFirst();
            sll.RemoveFirst();
            sll.AddFirst(10);

            Assert.AreEqual<int>(1, sll.Count);
            Assert.AreEqual<int>(10, sll.Head.Value);
            Assert.AreEqual<int>(10, sll.Tail.Value);
            Assert.IsNull(sll.Head.Next);
            Assert.IsNull(sll.Tail.Next);
        }

        /// <summary>
        /// Test to see that the appropriate exception is raised when calling RemoveFirst on a singly linked list
        /// object containing no nodes.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void RemoveFirstInvalidSinglyLinkedListCollectionTest() {
            SinglyLinkedListCollection<int> sll = new SinglyLinkedListCollection<int>();

            sll.RemoveFirst();
        }

        /// <summary>
        /// Test to see that the appropriate exception is raised when calling RemoveFirst on a singly linked list
        /// object containing no nodes.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void RemoveFirstInvalidSinglyLinkedListCollectionTest2() {
            SinglyLinkedListCollection<int> sll = new SinglyLinkedListCollection<int>();

            sll.AddFirst(10);
            sll.RemoveFirst();
            sll.RemoveFirst();
        }

    }

}
