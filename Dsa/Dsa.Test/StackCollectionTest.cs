using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dsa.DataStructures;
using System.Collections.Generic;
using System;
using System.Collections;

namespace Dsa.Test {

    [TestClass]
    public class StackCollectionTest {

        /// <summary>
        /// Test to see that Pushing an item onto the stack results in the intended behaviour.
        /// </summary>
        [TestMethod]
        public void PushTest() {
            StackCollection<int> actual = new StackCollection<int>();
            StackCollection<int> expected = new StackCollection<int>();

            actual.Push(10);
            actual.Push(20);
            expected.Push(10);
            expected.Push(20);

            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test to see that calling Peek returns the correct item.
        /// </summary>
        [TestMethod]
        public void PeekTest() {
            StackCollection<int> myStack = new StackCollection<int>();

            myStack.Push(10);
            myStack.Push(20);
            myStack.Push(30);

            Assert.AreEqual<int>(30, myStack.Peek());
        }

        /// <summary>
        /// Test to see that the correct item is returned and the item at the top of the stack is 
        /// updated appropriatley after calling Pop.
        /// </summary>
        [TestMethod]
        public void PopTest() {
            StackCollection<int> actual = new StackCollection<int>();

            actual.Push(10);
            actual.Push(20);
            actual.Push(30);

            Assert.AreEqual<int>(30, actual.Pop());
            Assert.AreEqual<int>(20, actual.Peek());
        }

        /// <summary>
        /// Test to see that ICollection(Of T).Add results in the expected behaviour.
        /// </summary>
        [TestMethod]
        public void AddTest() {
            StackCollection<int> actual = new StackCollection<int>();
            ICollection<int> collActual = actual;

            collActual.Add(10);
            collActual.Add(20);

            Assert.AreEqual<int>(20, actual.Peek());
        }

        /// <summary>
        /// Test to see that Count returns the number of items on the StackCollection.
        /// </summary>
        [TestMethod]
        public void CountTest() {
            StackCollection<int> actual = new StackCollection<int>();

            actual.Push(10);
            actual.Push(20);

            Assert.AreEqual<int>(2, actual.Count);
        }

        /// <summary>
        /// Test to see that CopyTo results in the correct population of an array with the items in the 
        /// StackCollection.
        /// </summary>
        [TestMethod]
        public void CopyToTest() {
            StackCollection<int> stack = new StackCollection<int>();

            stack.Push(10);
            stack.Push(20);
            stack.Push(30);
            int[] actual = new int[stack.Count];
            stack.CopyTo(actual, 0);
            int[] expected = { 10, 20, 30 };

            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test to see that calling Remove returns the correct value.
        /// </summary>
        [TestMethod]
        public void RemoveTest() {
            StackCollection<int> stack = new StackCollection<int>();
            ICollection<int> actual = stack;

            stack.Push(10);
            stack.Push(20);
            stack.Push(30);

            Assert.IsTrue(actual.Remove(20));
            Assert.IsFalse(actual.Remove(70));
        }

        /// <summary>
        /// Test to see that IsReadonly returns false.
        /// </summary>
        [TestMethod]
        public void IsReadonlyTest() {
            StackCollection<int> stack = new StackCollection<int>();
            ICollection<int> actual = stack;

            Assert.IsFalse(actual.IsReadOnly);
        }

        /// <summary>
        /// Test to make sure that the StackCollection is reset to its default state.
        /// </summary>
        [TestMethod]
        public void ClearTest() {
            StackCollection<int> actual = new StackCollection<int>();

            actual.Push(10);
            actual.Push(20);
            actual.Push(30);
            actual.Clear();

            Assert.AreEqual<int>(0, actual.Count);
        }

        /// <summary>
        /// Test to see that calling Contains returns the expected value.
        /// </summary>
        [TestMethod]
        public void ContainsTest() {
            StackCollection<int> actual = new StackCollection<int>();

            actual.Push(10);
            actual.Push(20);

            Assert.IsTrue(actual.Contains(20));
            Assert.IsFalse(actual.Contains(30));
        }

        /// <summary>
        /// Test to see that a non null IEnumerator(Of T) object is returned.
        /// </summary>
        [TestMethod]
        public void GetEnumeratorTest() {
            StackCollection<int> stack = new StackCollection<int>();
            stack.Push(10);
            stack.Push(20);

            foreach (int i in stack) { Console.WriteLine(i); }

            Assert.IsNotNull(stack.GetEnumerator());
        }

        /// <summary>
        /// Test to make sure that the correct exception is raised when calling ICollection.CopyTo.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(NotSupportedException))]
        public void ICollectionCopyToTest() {
            StackCollection<int> stack = new StackCollection<int>();
            ICollection actual = stack;

            int[] expected = new int[stack.Count];
            actual.CopyTo(expected, 0);
        }

        /// <summary>
        /// Test to make sure that IsSynchronized property returns false.
        /// </summary>
        [TestMethod]
        public void IsSynchronizedTest() {
            StackCollection<int> stack = new StackCollection<int>();
            ICollection actual = stack;

            Assert.IsFalse(actual.IsSynchronized);
        }

        /// <summary>
        /// Test to make sure that the object returned from SyncRoot is not null.
        /// </summary>
        [TestMethod]
        public void SyncRootTest() {
            StackCollection<int> stack = new StackCollection<int>();
            ICollection actual = stack;

            Assert.IsNotNull(actual.SyncRoot);
        }

        /// <summary>
        /// Test to see that the expected array is returned.
        /// </summary>
        [TestMethod]
        public void ToArrayTest() {
            StackCollection<int> stack = new StackCollection<int>();

            stack.Push(10);
            stack.Push(20);
            stack.Push(30);
            int[] expected = { 30, 20, 10 };

            CollectionAssert.AreEqual(expected, stack.ToArray());
        }

        /// <summary>
        /// Test to see that ICollection.GetEnumerator returns a non-null IEnumerator.
        /// </summary>
        [TestMethod]
        public void GetEnumeratorNonGenericTest() {
            StackCollection<int> stack = new StackCollection<int>();
            ICollection actual = stack;

            Assert.IsNotNull(actual.GetEnumerator());
        }

    }

}
