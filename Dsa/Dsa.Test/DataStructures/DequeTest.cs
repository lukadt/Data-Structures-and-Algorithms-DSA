using Dsa.DataStructures;
using NUnit.Framework;
using System;
using NUnit.Framework.Extensions;

namespace Dsa.Test.DataStructures
{
    /// <summary>
    /// Tests for Deque.
    /// </summary>
    [TestFixture]
    public class DequeTest
    {
        /// <summary>
        /// Check to make sure the deque is in the correct state after adding an item to the deque.
        /// </summary>
        [Test]
        public void EnqueueFrontTest()
        {
            Deque<int> actual = new Deque<int>();

            actual.EnqueueFront(10);

            Assert.AreEqual(1, actual.Count);
        }

        /// <summary>
        /// Check to make sure that the deque is in the correct state when using implicitly the Add method
        /// of the deque.
        /// The Add method implicity uses EnqueueBack by default.
        /// </summary>
        [Test]
        public void AddTest()
        {
            Deque<int> actual = new Deque<int> { 12, 34, 23 };

            Assert.AreEqual(3, actual.Count);
        }

        /// <summary>
        /// Check to make sure that the deque is in the correct state when adding an item to the back of the
        /// deque.
        /// </summary>
        [Test]
        public void EnqueueBackTest()
        {
            Deque<int> actual = new Deque<int>();

            actual.EnqueueBack(120);

            Assert.AreEqual(1, actual.Count);
        }

        /// <summary>
        /// Check to see that the correct exception is thrown when dequeuing an item from the front on an empty
        /// deque.
        /// </summary>
        [Test]
        [ExpectedException(typeof(InvalidOperationException), 
            ExpectedMessage = "Cannot dequeue an item from an empty Deque.")]
        public void DequeueFrontEmptyDequeTest()
        {
            Deque<int> actual = new Deque<int>();

            actual.DequeueFront();
        }

        /// <summary>
        /// Check to see that the state of the deque is correct when dequeuing the item from the front of the deque.
        /// </summary>
        [Test]
        public void DequeueFrontNonEmptyDequeTest()
        {
            Deque<int> actual = new Deque<int> { 10, 12, 13 };

            Assert.AreEqual(10, actual.DequeueFront());
            Assert.AreEqual(12, actual.DequeueFront());
            Assert.AreEqual(13, actual.DequeueFront());
        }

        /// <summary>
        /// Check to make sure that the Count property is correct when mutating the state of the Deque.
        /// </summary>
        [Test]
        public void DequeueFrontCountNonEmptyDequeTest()
        {
            Deque<int> actual = new Deque<int> { 10, 12, 13 };

            actual.DequeueFront();

            Assert.AreEqual(2, actual.Count);
        }

        /// <summary>
        /// Check to make sure that the correct exception is thrown when trying to dequeue an item from the back of an
        /// empty Deque.
        /// </summary>
        [Test]
        [ExpectedException(typeof(InvalidOperationException), 
            ExpectedMessage = "Cannot dequeue an item from an empty Deque.")]
        public void DequeueBackEmptyDequeTest()
        {
            Deque<int> actual = new Deque<int>();

            actual.DequeueBack();
        }

        /// <summary>
        /// Check to see that the correct values are returned when dequeuing the item at the back of the deque.
        /// </summary>
        [Test]
        public void DequeueBackNonEmptyDequeTest()
        {
            Deque<int> actual = new Deque<int> { 10, 12, 13 };

            Assert.AreEqual(13, actual.DequeueBack());
            Assert.AreEqual(12, actual.DequeueBack());
            Assert.AreEqual(10, actual.DequeueBack());
        }

        /// <summary>
        /// Check to make sure that the Count property is correct when mutating the state of Deque.
        /// </summary>
        [Test]
        public void DequeueBackCountNonEmptyDequeTest()
        {
            Deque<int> actual = new Deque<int> { 10, 12, 13 };

            actual.DequeueBack();

            Assert.AreEqual(2, actual.Count);
        }
    }
}
