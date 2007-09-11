using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dsa.DataStructures;
using System;
using System.Collections.Generic;
using System.Collections;

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
        public void RemoveLastTestMultipleNodesTest() {
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

        /// <summary>
        /// Test to see that a call to RemoveFirst when there is only a single node in the linked list
        /// results in the expected behaviour.
        /// </summary>
        [TestMethod]
        public void RemoveFirstSingleNodeTest() {
            DoublyLinkedListCollection<int> dll = new DoublyLinkedListCollection<int>();

            dll.AddLast(10);
            dll.RemoveFirst();

            Assert.IsNull(dll.Head);
            Assert.IsNull(dll.Tail);
        }

        /// <summary>
        /// Test to see that a call to RemoveFirst when there are two node in the linked list
        /// results in the expected behaviour.
        /// </summary>
        [TestMethod]
        public void RemoveFirstTwoNodesTest() {
            DoublyLinkedListCollection<int> dll = new DoublyLinkedListCollection<int>();

            dll.AddLast(10);
            dll.AddLast(20);
            dll.RemoveFirst();

            Assert.AreEqual<int>(20, dll.Head.Value);
            Assert.IsNull(dll.Head.Prev);
        }

        /// <summary>
        /// Test to see that calling RemoveFirst when there are more than two nodes in the linked list
        /// results in the expected behaviour.
        /// </summary>
        [TestMethod]
        public void RemoveFirstMoreThanTwoNodesTest() {
            DoublyLinkedListCollection<int> dll = new DoublyLinkedListCollection<int>();

            dll.AddLast(10);
            dll.AddLast(20);
            dll.AddLast(30);
            dll.RemoveFirst();

            Assert.AreEqual<int>(20, dll.Head.Value);
            Assert.IsNull(dll.Head.Prev);
        }

        /// <summary>
        /// Test to see that calling RemoveFirst on a linked list with no nodes throws the correct
        /// exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void RemoveFirstEmptyListTest() {
            DoublyLinkedListCollection<int> dll = new DoublyLinkedListCollection<int>();

            dll.RemoveFirst();
        }

        /// <summary>
        /// Test to see that calling ICollection(Of T).Add results in the expected behaviour.
        /// </summary>
        [TestMethod]
        public void AddTest() {
            DoublyLinkedListCollection<int> dll = new DoublyLinkedListCollection<int>();
            ICollection<int> actual = dll;

            actual.Add(10);
            actual.Add(20);

            Assert.AreEqual<int>(10, dll.Head.Value);
            Assert.AreEqual<int>(20, dll.Tail.Value);
            Assert.IsNull(dll.Head.Prev);
            Assert.IsNull(dll.Tail.Next);
        }

        /// <summary>
        /// Test to see that calling Clear results in the DoublyLinkedListCollection(Of T) being reset to its
        /// default state.
        /// </summary>
        [TestMethod]
        public void ClearTest() {
            DoublyLinkedListCollection<int> dll = new DoublyLinkedListCollection<int>();

            dll.AddLast(10);
            dll.AddLast(20);
            dll.AddLast(30);
            dll.Clear();

            Assert.IsNull(dll.Head);
            Assert.IsNull(dll.Tail);
            Assert.AreEqual<int>(0, dll.Count);
        }

        /// <summary>
        /// Test to see that the Count property returns the expected value.
        /// </summary>
        [TestMethod]
        public void CountTest() {
            DoublyLinkedListCollection<int> dll = new DoublyLinkedListCollection<int>();

            dll.AddLast(10);
            dll.AddFirst(5);
            dll.RemoveFirst();
            dll.RemoveLast();
            dll.AddLast(10);
            dll.AddAfter(dll.Head, 30);
            dll.AddBefore(dll.Head.Next, 20);

            Assert.AreEqual<int>(3, dll.Count);
        }

        /// <summary>
        /// Test to see that Contains returns the correct value.
        /// </summary>
        [TestMethod]
        public void ContainsTest() {
            DoublyLinkedListCollection<int> dll = new DoublyLinkedListCollection<int>();

            dll.AddLast(10);
            dll.AddLast(20);
            dll.AddLast(30);

            Assert.IsTrue(dll.Contains(20));
            Assert.IsFalse(dll.Contains(40));
        }

        /// <summary>
        /// Test to see that a call to CopyTo results in the correct population of an array.
        /// </summary>
        [TestMethod]
        public void CopyToTest() {
            DoublyLinkedListCollection<int> dll = new DoublyLinkedListCollection<int>();

            dll.AddLast(10);
            dll.AddLast(20);
            dll.AddLast(30);
            int[] actual = new int[dll.Count];
            dll.CopyTo(actual, 0);
            int[] expected = { 10, 20, 30 };

            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test to see that calling ToArray on the linked list results in the expected array.
        /// </summary>
        [TestMethod]
        public void ToArrayTest() {
            DoublyLinkedListCollection<string> dll = new DoublyLinkedListCollection<string>();

            dll.AddLast("London");
            dll.AddLast("Paris");
            dll.AddLast("Berlin");
            string[] expected = { "London", "Paris", "Berlin" };

            CollectionAssert.AreEqual(expected, dll.ToArray());
        }

        /// <summary>
        /// Test to see that calling ToArray on a DoublyLinkedListCollection(Of T) that contains no nodes throws the 
        /// correct exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ToArrayEmptyListTest() {
            DoublyLinkedListCollection<int> dll = new DoublyLinkedListCollection<int>();

            dll.ToArray();
        }

        /// <summary>
        /// Test to see that the IsReadonly property returns false.
        /// </summary>
        [TestMethod]
        public void IsReadonlyTest() {
            DoublyLinkedListCollection<int> dll = new DoublyLinkedListCollection<int>();
            ICollection<int> actual = dll;

            Assert.IsFalse(actual.IsReadOnly);
        }

        /// <summary>
        /// Test to see that calling Remove on a DoublyLinkedListCollection(Of T) that contains no nodes results in the
        /// correct raised exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void RemoveEmptyListTest() {
            DoublyLinkedListCollection<int> dll = new DoublyLinkedListCollection<int>();

            dll.Remove(10);
        }

        /// <summary>
        /// Test to see that removing a single node from the DoublyLinkedListCollection(Of T) results in the list being
        /// declared as empty.
        /// </summary>
        [TestMethod]
        public void RemoveSingleNodeTest() {
            DoublyLinkedListCollection<int> dll = new DoublyLinkedListCollection<int>();

            dll.AddLast(10);
            dll.Remove(10);

            Assert.IsTrue(dll.IsEmpty());
            Assert.IsNull(dll.Head);
            Assert.IsNull(dll.Tail);
            Assert.AreEqual<int>(0, dll.Count);
        }

        /// <summary>
        /// Test to see that the DoublyLinkedListCollection(Of T) is left in the correct state after removing head value from 
        /// a list with two nodes.
        /// </summary>
        [TestMethod]
        public void RemoveHeadTwoNodes() {
            DoublyLinkedListCollection<string> dll = new DoublyLinkedListCollection<string>();

            dll.AddLast("London");
            dll.AddLast("Paris");
            dll.Remove("London");

            Assert.AreEqual<string>("Paris", dll.Head.Value);
            Assert.AreEqual<string>("Paris", dll.Tail.Value);
            Assert.AreEqual<int>(1, dll.Count);
        }

        /// <summary>
        /// Test to see that the DoublyLinkedListCollection(Of T) is left in the correct state after removing tail value from 
        /// a list with two nodes.
        /// </summary>
        [TestMethod]
        public void RemoveTailTwoNodes() {
            DoublyLinkedListCollection<string> dll = new DoublyLinkedListCollection<string>();

            dll.AddLast("London");
            dll.AddLast("Paris");
            dll.Remove("Paris");

            Assert.AreEqual<string>("London", dll.Head.Value);
            Assert.AreEqual<string>("London", dll.Tail.Value);
            Assert.AreEqual<int>(1, dll.Count);
        }

        /// <summary>
        /// Test to see that the DoublyLinkedListCollection(Of T) is left in the correct state when removing
        /// middle node value from a list of 3 or more nodes.
        /// </summary>
        [TestMethod]
        public void RemoveMiddleMultipleNodesTest() {
            DoublyLinkedListCollection<int> dll = new DoublyLinkedListCollection<int>();

            dll.AddLast(10);
            dll.AddLast(20);
            dll.AddLast(30);
            dll.Remove(20);

            Assert.AreEqual<int>(30, dll.Head.Next.Value);
            Assert.AreEqual<int>(10, dll.Tail.Prev.Value);
            Assert.AreEqual<int>(2, dll.Count);
        }

        /// <summary>
        /// Test to see that the DoublyLinkedListCollection(Of T) is left in the correct state when removing
        /// head node value from a list of 3 or more nodes.
        /// </summary>
        [TestMethod]
        public void RemoveHeadMultipleNodesTest() {
            DoublyLinkedListCollection<int> dll = new DoublyLinkedListCollection<int>();

            dll.AddLast(10);
            dll.AddLast(20);
            dll.AddLast(30);
            dll.Remove(10);

            Assert.AreEqual<int>(20, dll.Head.Value);
            Assert.IsNull(dll.Head.Prev);
            Assert.AreEqual<int>(2, dll.Count);
        }

        /// <summary>
        /// Test to see that the DoublyLinkedListCollection(Of T) is left in the correct state when removing
        /// middle node value from a list of 3 or more nodes.
        /// </summary>
        [TestMethod]
        public void RemoveTailMultipleNodesTest() {
            DoublyLinkedListCollection<int> dll = new DoublyLinkedListCollection<int>();

            dll.AddLast(10);
            dll.AddLast(20);
            dll.AddLast(30);
            dll.Remove(30);

            Assert.AreEqual<int>(20, dll.Tail.Value);
            Assert.IsNull(dll.Tail.Next);
            Assert.AreEqual<int>(2, dll.Count);
        }

        /// <summary>
        /// Test to see that the correct value is returned when the value to be removed is not in the
        /// DoublyLinkedListCollection(Of T).
        /// </summary>
        [TestMethod]
        public void RemoveNoMatchTest() {
            DoublyLinkedListCollection<int> dll = new DoublyLinkedListCollection<int>();

            dll.AddLast(10);

            Assert.IsFalse(dll.Remove(20));
        }

        /// <summary>
        /// Test to see that an non null IEnumerator object is returned.
        /// </summary>
        [TestMethod]
        public void GetEnumeratorTest() {
            DoublyLinkedListCollection<int> dll = new DoublyLinkedListCollection<int>();

            dll.AddLast(10);
            dll.AddLast(20);
            dll.AddLast(30);

            foreach (int i in dll) {
                Console.WriteLine(i);
            }

            Assert.IsNotNull(dll.GetEnumerator());
        }

        /// <summary>
        /// Test to see that an non null IEnumerator object is returned.
        /// </summary>
        [TestMethod]
        public void GetEnumeratorNonGenericTest() {
            DoublyLinkedListCollection<string> dll = new DoublyLinkedListCollection<string>();
            IEnumerable actual = dll;

            Assert.IsNotNull(actual.GetEnumerator());
        }

    }

}
