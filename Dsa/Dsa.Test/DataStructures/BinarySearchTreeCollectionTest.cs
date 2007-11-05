using System.Diagnostics;
using Dsa.DataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Collections;
using System;

namespace Dsa.Test
{

    /// <summary>
    /// BinarySearhTree(Of T) tests.
    /// </summary>
    [TestClass]
    public class BinarySearchTreeCollectionTest
    {

        /// <summary>
        /// Test to see that the fields are intialized correctly.
        /// </summary>
        [TestMethod]
        public void ConstructorTest()
        {
            BinarySearchTreeCollection<int> bst = new BinarySearchTreeCollection<int>();

            Assert.IsNull(bst.Root);
        }

        /// <summary>
        /// Test to see that the insert asserts the correct state changes.
        /// </summary>
        [TestMethod]
        public void InsertRootNullTest()
        {
            BinarySearchTreeCollection<int> bst = new BinarySearchTreeCollection<int>();

            bst.Add(10);

            Assert.AreEqual(10, bst.Root.Value);
        }

        /// <summary>
        /// Test to see that the state of the BinarySearchTree is updated correctly when inserting
        /// more than one node into the tree.
        /// </summary>
        [TestMethod]
        public void InsertTest()
        {
            BinarySearchTreeCollection<int> bst = new BinarySearchTreeCollection<int>();

            bst.Add(10);
            bst.Add(20);
            bst.Add(30);
            bst.Add(5);
            bst.Add(7);
            bst.Add(3);

            Assert.AreEqual(20, bst.Root.Right.Value);
            Assert.AreEqual(30, bst.Root.Right.Right.Value);
            Assert.AreEqual(5, bst.Root.Left.Value);
            Assert.AreEqual(7, bst.Root.Left.Right.Value);
            Assert.AreEqual(3, bst.Root.Left.Left.Value);
        }

        /// <summary>
        /// Test to make sure that a non-null IEnumerator object is returned when calling GetEnumerator on a bst object.
        /// </summary>
        [TestMethod]
        public void GetEnumeratorGenericTest()
        {
            BinarySearchTreeCollection<int> bst = new BinarySearchTreeCollection<int>();
            
            bst.Add(10);
            bst.Add(5);
            bst.Add(3);
            bst.Add(8);
            bst.Add(12);
            bst.Add(11);

            foreach (int i in bst) Debug.Write(i);

            Assert.IsNotNull(bst.GetEnumerator());
        }

        /// <summary>
        /// Test to make sure that a non-null IEnumerator object is returned when calling the GetPostorderEnumerator on a bst object.
        /// </summary>
        [TestMethod]
        public void GetPostorderEnumeratorTest()
        {
            BinarySearchTreeCollection<int> bst = new BinarySearchTreeCollection<int>();

            bst.Add(10);
            bst.Add(5);
            bst.Add(3);
            bst.Add(20);
            bst.Add(17);
            bst.Add(30);

            foreach(int i in bst.GetPostorderEnumerator()) Debug.Write(i);

            Assert.IsNotNull(bst.GetPostorderEnumerator());
        }

        /// <summary>
        /// Test to see that a non-null IEnumerator object is returned when calling the GetInorderEnumerator on a bst object.
        /// </summary>
        [TestMethod]
        public void GetInorderEnumeratorTest()
        {
            BinarySearchTreeCollection<int> bst = new BinarySearchTreeCollection<int>();

            bst.Add(10);
            bst.Add(5);
            bst.Add(3);
            bst.Add(20);
            bst.Add(17);
            bst.Add(30);

            foreach (int i in bst.GetInorderEnumerator()) Debug.WriteLine(i);

            Assert.IsNotNull(bst.GetInorderEnumerator());
        }

        /// <summary>
        /// Test to see that count returns the correct value.
        /// </summary>
        [TestMethod]
        public void CountTest()
        {
            BinarySearchTreeCollection<int> bst = new BinarySearchTreeCollection<int>();

            bst.Add(10);
            bst.Add(4);
            bst.Add(67);

            Assert.AreEqual(3, bst.Count);
        }

        /// <summary>
        /// Test to see that IsReadOnly property returns the correct value.
        /// </summary>
        [TestMethod]
        public void ReadOnlyTest()
        {
            BinarySearchTreeCollection<int> bst = new BinarySearchTreeCollection<int>();
            ICollection<int> actual = bst;

            Assert.IsFalse(actual.IsReadOnly);
        }

        /// <summary>
        /// Test to see that IsSynchronized property returns the correct value.
        /// </summary>
        [TestMethod]
        public void IsSynchronizedTest()
        {
            BinarySearchTreeCollection<int> bst = new BinarySearchTreeCollection<int>();
            ICollection actual = bst;

            Assert.IsFalse(actual.IsSynchronized);
        }

        /// <summary>
        /// Test to see that a non null enumerator object is returned.
        /// </summary>
        [TestMethod]
        public void ICollectionGetEnumeratorTest()
        {
            BinarySearchTreeCollection<int> bst = new BinarySearchTreeCollection<int>();
            ICollection actual = bst;

            Assert.IsNotNull(actual.GetEnumerator());
        }

        /// <summary>
        /// Test to see that SyncRoot returns a non null object.
        /// </summary>
        [TestMethod]
        public void SyncRootTest()
        {
            BinarySearchTreeCollection<int> bst = new BinarySearchTreeCollection<int>();
            ICollection actual = bst;

            Assert.IsNotNull(actual.SyncRoot);
        }

        /// <summary>
        /// Test to see that calling Clear resets the collection to its default state.
        /// </summary>
        [TestMethod]
        public void ClearTest()
        {
            BinarySearchTreeCollection<int> bst = new BinarySearchTreeCollection<int>();

            bst.Add(10);
            bst.Add(5);
            bst.Add(15);
            bst.Clear();

            Assert.IsNull(bst.Root);
            Assert.AreEqual(0, bst.Count);
        }

        /// <summary>
        /// Test to see that the FindMin method returns the correct value.
        /// </summary>
        [TestMethod]
        public void FindMinTest()
        {
            BinarySearchTreeCollection<int> bst = new BinarySearchTreeCollection<int>();

            bst.Add(12);
            bst.Add(8);
            bst.Add(42);
            bst.Add(6);
            bst.Add(11);

            Assert.AreEqual(6, bst.FindMin());
        }

        /// <summary>
        /// Test to see that FindMax returns the largest value in the bst.
        /// </summary>
        [TestMethod]
        public void FindMaxTest()
        {
            BinarySearchTreeCollection<int> bst = new BinarySearchTreeCollection<int>();

            bst.Add(12);
            bst.Add(8);
            bst.Add(42);
            bst.Add(6);
            bst.Add(11);

            Assert.AreEqual(42, bst.FindMax());
        }

        /// <summary>
        /// Test to see that Contains returns the correct value.
        /// </summary>
        [TestMethod]
        public void ContainsTest()
        {
            BinarySearchTreeCollection<int> bst = new BinarySearchTreeCollection<int>();

            bst.Add(12);
            bst.Add(5);
            bst.Add(3);
            bst.Add(8);
            bst.Add(42);

            Assert.IsTrue(bst.Contains(12));
            Assert.IsTrue(bst.Contains(3));
            Assert.IsTrue(bst.Contains(42));
        }

        /// <summary>
        /// Test to see that the correct value is returned when the item is not contained within the bst.
        /// </summary>
        [TestMethod]
        public void ContainsItemNotPresentTest()
        {
            BinarySearchTreeCollection<int> bst = new BinarySearchTreeCollection<int>();

            bst.Add(12);
            bst.Add(5);
            bst.Add(3);
            bst.Add(8);
            bst.Add(42);

            Assert.IsFalse(bst.Contains(99));
            Assert.IsFalse(bst.Contains(1));
        }

        /// <summary>
        /// Test to see that calling GetBreadthFirstEnumerator returns a non null enumerator.
        /// </summary>
        [TestMethod]
        public void GetBreadthFirstEnumeratorTest()
        {
            BinarySearchTreeCollection<int> bst = new BinarySearchTreeCollection<int>();

            Assert.IsNotNull(bst.GetBreadthFirstEnumerator());
        }

        /// <summary>
        /// Test to see that calling ToArray returns the correct array.
        /// </summary>
        [TestMethod]
        public void ToArrayTest()
        {
            BinarySearchTreeCollection<int> bst = new BinarySearchTreeCollection<int>();

            bst.Add(12);
            bst.Add(8);
            bst.Add(6);
            bst.Add(11);
            bst.Add(42);

            int[] actual = bst.ToArray();
            int[] expected = {12, 8, 42, 6, 11};

            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test to see that the correct exception is raised when calling the ToArray method 
        /// on a bst object with no items in it.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ToArrayNoItemsInBstTest()
        {
            BinarySearchTreeCollection<int> bst = new BinarySearchTreeCollection<int>();

            bst.ToArray();
        }

        /// <summary>
        /// Test to see that calling CopyTo results in the target array being updated correctly.
        /// </summary>
        [TestMethod]
        public void CopyToTest()
        {
            BinarySearchTreeCollection<int> bst = new BinarySearchTreeCollection<int>() { 12, 8, 6, 11, 42 };

            int[] expected = { 12, 8, 42, 6, 11 };
            int[] actual = new int[bst.Count];
            bst.CopyTo(actual);

            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test to see that calling CopyTo starting at specified index results in the target array being updated correctly.
        /// </summary>
        [TestMethod]
        public void CopyToStartingSpecifiedIndexTest()
        {
            BinarySearchTreeCollection<int> bst = new BinarySearchTreeCollection<int>() { 12, 8, 6, 11, 42 };

            int[] expected = { 0, 0, 0, 12, 8, 42, 6, 11 };
            int[] actual = new int[bst.Count + 3];
            bst.CopyTo(actual, 3);

            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test to see that calling ICollection.CopyTo throws the correct exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(NotSupportedException))]
        public void ICollectionCopyToTest()
        {
            BinarySearchTreeCollection<int> bst = new BinarySearchTreeCollection<int>();
            ICollection actual = bst;

            int[] array = new int[5];

            actual.CopyTo(array, 0);
        }

        /// <summary>
        /// Test to see that deleting a right leaf results in the correct state of the bst.
        /// </summary>
        [TestMethod]
        public void DeleteRightLeafTest()
        {
            BinarySearchTreeCollection<int> bst = new BinarySearchTreeCollection<int>();

            bst.Add(23);
            bst.Add(18);
            bst.Add(44);

            Assert.IsTrue(bst.Remove(44));
        }

    }
}
