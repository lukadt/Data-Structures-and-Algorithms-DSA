using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dsa.DataStructures;
using System.Collections;

namespace Dsa.Test {

    /// <summary>
    /// Tests for Queue(Of T).
    /// </summary>
    [TestClass]
    public class QueueCollectionTest {

        /// <summary>
        /// Test to see that Enqueue adds an item to the back of the queue, or front of the queue
        /// if the queue is empty.
        /// </summary>
        [TestMethod]
        public void EnqueueTest() {
            QueueCollection<int> myQueue = new QueueCollection<int>();

            myQueue.Enqueue(10);
            myQueue.Enqueue(20);
            myQueue.Enqueue(30);

            Assert.AreEqual<int>(10, myQueue.Peek());
        }

        /// <summary>
        /// Test to see that peek returns the item at the front of the queue.
        /// </summary>
        [TestMethod]
        public void PeekTest() {
            QueueCollection<int> myQueue = new QueueCollection<int>();

            myQueue.Enqueue(10);
            myQueue.Enqueue(20);

            Assert.AreEqual<int>(10, myQueue.Peek());
        }

        /// <summary>
        /// Test to see that popping an item from the queue returns the correct item, and promotes the next item
        /// inline to the front of the queue.
        /// </summary>
        [TestMethod]
        public void DequeueTest() {
            QueueCollection<int> myQueue = new QueueCollection<int>();

            myQueue.Enqueue(10);
            myQueue.Enqueue(20);
            myQueue.Enqueue(30);
            
            Assert.AreEqual<int>(10, myQueue.Dequeue());
            Assert.AreEqual<int>(20, myQueue.Peek());
        }

        /// <summary>
        /// Test to see that the Count property returns the correct number of items.
        /// </summary>
        [TestMethod]
        public void CountTest() {
            QueueCollection<int> myQueue = new QueueCollection<int>();

            myQueue.Enqueue(10);
            myQueue.Enqueue(20);

            Assert.AreEqual<int>(2, myQueue.Count);
        }

        /// <summary>
        /// Test to see that the CopyTo method works as expected.
        /// </summary>
        [TestMethod]
        public void CopyToTest() {
            QueueCollection<int> myQueue = new QueueCollection<int>();

            myQueue.Enqueue(10);
            myQueue.Enqueue(20);
            myQueue.Enqueue(30);
            int[] actual = new int[myQueue.Count];
            myQueue.CopyTo(actual, 0);
            int[] expected = { 10, 20, 30 };

            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test to make sure that QueueCollection is not readonly.
        /// </summary>
        [TestMethod]
        public void IsReadonlyTest() {
            QueueCollection<int> myQueue = new QueueCollection<int>();
            ICollection<int> collectionQueue = myQueue;

            Assert.IsFalse(collectionQueue.IsReadOnly);
        }

        /// <summary>
        /// Test to see that Contains returns the expected result.
        /// </summary>
        [TestMethod]
        public void ContainsTest() {
            QueueCollection<int> myQueue = new QueueCollection<int>();

            myQueue.Enqueue(10);
            myQueue.Enqueue(20);

            Assert.IsTrue(myQueue.Contains(10));
            Assert.IsFalse(myQueue.Contains(30));
        }

        /// <summary>
        /// Test to make sure that Clear returns the QueueCollection to its default state.
        /// </summary>
        [TestMethod]
        public void ClearTest() {
            QueueCollection<int> myQueue = new QueueCollection<int>();

            myQueue.Enqueue(10);
            myQueue.Enqueue(20);
            myQueue.Enqueue(30);
            myQueue.Clear();

            Assert.AreEqual<int>(0, myQueue.Count);
        }

        /// <summary>
        /// Test to make sure that Add works as expected.
        /// </summary>
        [TestMethod]
        public void AddTest() {
            QueueCollection<int> myQueue = new QueueCollection<int>();
            ICollection<int> collectionQueue = myQueue;

            collectionQueue.Add(10);
            collectionQueue.Add(20);
            collectionQueue.Add(30);

            Assert.AreEqual<int>(10, myQueue.Peek());
            Assert.AreEqual<int>(3, myQueue.Count);
        }

        /// <summary>
        /// Test to see that the IEnumerable(Of T).GetEnumerator returns an Enumerator that is not null.
        /// </summary>
        [TestMethod]
        public void GetEnumeratorGenericTest() {
            QueueCollection<int> myQueue = new QueueCollection<int>();

            myQueue.Enqueue(10);

            Assert.IsNotNull(myQueue.GetEnumerator());
        }

        /// <summary>
        /// Test to see that the IEnumerable.GetEnumerator returns an Enumerator that is not null.
        /// </summary>
        [TestMethod]
        public void GetEnumeratorTest() {
            QueueCollection<int> myQueue = new QueueCollection<int>();
            IEnumerable enumeratorQueue = myQueue;

            myQueue.Enqueue(10);

            Assert.IsNotNull(enumeratorQueue.GetEnumerator());
        }

        /// <summary>
        /// Test to see that ICollection(Of T).Remove method leaves teh QueueCollction in the correct state.
        /// </summary>
        [TestMethod]
        public void RemoveTest() {
            QueueCollection<int> myQueue = new QueueCollection<int>();
            ICollection<int> collQueue = myQueue;

            myQueue.Enqueue(10);
            myQueue.Enqueue(20);
            collQueue.Remove(10);

            Assert.AreEqual<int>(20, myQueue.Peek());
        }

    }

}
