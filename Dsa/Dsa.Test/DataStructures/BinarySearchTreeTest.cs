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
        /// Check to see that the fields are intialized correctly.
        /// </summary>
        [TestMethod]
        public void ConstructorTest()
        {
            BinarySearchTreeCollection<int> bst = new BinarySearchTreeCollection<int>();

            Assert.IsNull(bst.Root);
        }

        /// <summary>
        /// Check to see that a bst can have a user provided comparer to use.
        /// </summary>
        [TestMethod]
        public void OverloadedConstructorTest()
        {
            IComparer<Coordinate> comparer = new CoordinateComparer();
            BinarySearchTreeCollection<Coordinate> bst = new BinarySearchTreeCollection<Coordinate>(comparer);

            Assert.IsNotNull(bst.Comparer);
        }

        /// <summary>
        /// Check to see that the correct exception is raised when the comparer is null.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void OverloadedConstructorComparerNullTest()
        {
            IComparer<Coordinate> comparer = null;
            BinarySearchTreeCollection<Coordinate> actual = new BinarySearchTreeCollection<Coordinate>(comparer);
        }

        /// <summary>
        /// Check to see that the insert asserts the correct state changes.
        /// </summary>
        [TestMethod]
        public void InsertRootNullTest()
        {
            BinarySearchTreeCollection<int> bst = new BinarySearchTreeCollection<int>();

            bst.Add(10);

            Assert.AreEqual(10, bst.Root.Value);
        }

        /// <summary>
        /// Check to see that the state of the BinarySearchTree is updated correctly when inserting
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
        /// Check to make sure that a non-null IEnumerator object is returned when calling GetEnumerator on a bst object.
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
        /// Check to make sure that a non-null IEnumerator object is returned when calling the GetPostorderEnumerator on a bst object.
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
        /// Check to see that a non-null IEnumerator object is returned when calling the GetInorderEnumerator on a bst object.
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
        /// Check to see that count returns the correct value.
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
        /// Check to see that IsReadOnly property returns the correct value.
        /// </summary>
        [TestMethod]
        public void ReadOnlyTest()
        {
            BinarySearchTreeCollection<int> bst = new BinarySearchTreeCollection<int>();
            ICollection<int> actual = bst;

            Assert.IsFalse(actual.IsReadOnly);
        }

        /// <summary>
        /// Check to see that IsSynchronized property returns the correct value.
        /// </summary>
        [TestMethod]
        public void IsSynchronizedTest()
        {
            BinarySearchTreeCollection<int> bst = new BinarySearchTreeCollection<int>();
            ICollection actual = bst;

            Assert.IsFalse(actual.IsSynchronized);
        }

        /// <summary>
        /// Check to see that a non null enumerator object is returned.
        /// </summary>
        [TestMethod]
        public void ICollectionGetEnumeratorTest()
        {
            BinarySearchTreeCollection<int> bst = new BinarySearchTreeCollection<int>();
            ICollection actual = bst;

            Assert.IsNotNull(actual.GetEnumerator());
        }

        /// <summary>
        /// Check to see that SyncRoot returns a non null object.
        /// </summary>
        [TestMethod]
        public void SyncRootTest()
        {
            BinarySearchTreeCollection<int> bst = new BinarySearchTreeCollection<int>();
            ICollection actual = bst;

            Assert.IsNotNull(actual.SyncRoot);
        }

        /// <summary>
        /// Check to see that calling Clear resets the collection to its default state.
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
        /// Check to see that the FindMin method returns the correct value.
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
        /// Check to see that FindMax returns the largest value in the bst.
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
        /// Check to see that Contains returns the correct value.
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
        /// Check to see that the correct value is returned when the item is not contained within the bst.
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
        /// Check to see that calling GetBreadthFirstEnumerator returns a non null enumerator.
        /// </summary>
        [TestMethod]
        public void GetBreadthFirstEnumeratorTest()
        {
            BinarySearchTreeCollection<int> bst = new BinarySearchTreeCollection<int>();

            Assert.IsNotNull(bst.GetBreadthFirstEnumerator());
        }

        /// <summary>
        /// Check to see that calling ToArray returns the correct array.
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
        /// Check to see that the correct exception is raised when calling the ToArray method 
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
        /// Check to see that calling CopyTo results in the target array being updated correctly.
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
        /// Check to see that calling CopyTo starting at specified index results in the target array being updated correctly.
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
        /// Check to see that calling ICollection.CopyTo throws the correct exception.
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
        /// Check to see if a non-null reference is returned for a node that is in the 
        /// bst with the specified value that is located in the left subtree.
        /// </summary>
        [TestMethod]
        public void FindNodeValidLeftChildTest()
        {
            BinarySearchTreeCollection<int> bst = new BinarySearchTreeCollection<int>();

            bst.Add(10);
            bst.Add(5);
            bst.Add(14);

            Assert.IsNotNull(bst.FindNode(5));
            Assert.AreEqual(5, bst.FindNode(5).Value);
        }

        /// <summary>
        /// Check to see if a non-null reference is returned for a node that is in the 
        /// bst with the specified value that is located in the right subtree.
        /// </summary>
        [TestMethod]
        public void FindNodeValidRightChildTest()
        {
            BinarySearchTreeCollection<int> bst = new BinarySearchTreeCollection<int>();

            bst.Add(10);
            bst.Add(5);
            bst.Add(14);

            Assert.IsNotNull(bst.FindNode(14));
            Assert.AreEqual(14, bst.FindNode(14).Value);
        }

        /// <summary>
        /// Check to see that FindNode returns null when a value that isn't in the bst is specified.
        /// </summary>
        [TestMethod]
        public void FindNodeNotInBstTest()
        {
            BinarySearchTreeCollection<int> bst = new BinarySearchTreeCollection<int>();

            bst.Add(10);
            bst.Add(5);
            bst.Add(15);

            Assert.IsNull(bst.FindNode(34));
        }

        /// <summary>
        /// Check to see that the correct node is returned when finding the parent of a node with
        /// the specified value located in the left subtree.
        /// </summary>
        [TestMethod]
        public void FindParentLeftSubTreeTest()
        {
            BinarySearchTreeCollection<int> bst = new BinarySearchTreeCollection<int>() 
            {
                10,
                9,
                23,
                17,
                4
            };

            Assert.AreEqual(10, bst.FindParent(9).Value);
            Assert.AreEqual(9, bst.FindParent(4).Value);
        }

        /// <summary>
        /// Check to see that the correct node is returned when finding the parent of a node with
        /// the specified value located in the right subtree.
        /// </summary>
        [TestMethod]
        public void FindParentRightSubTreeTest()
        {
            BinarySearchTreeCollection<int> bst = new BinarySearchTreeCollection<int>() 
            { 
                10, 
                9, 
                23, 
                17,
                4
            };

            Assert.AreEqual(10, bst.FindParent(23).Value);
            Assert.AreEqual(23, bst.FindParent(17).Value);
        }

        /// <summary>
        /// Check to see that null is returned when looking for a value that should be located in the
        /// right subtree.
        /// </summary>
        [TestMethod]
        public void FindParentRightSubTreeNodeNotPresentTest()
        {
            BinarySearchTreeCollection<int> bst = new BinarySearchTreeCollection<int>()
            {
                10,
                9,
                23,
                17
            };

            Assert.IsNull(bst.FindParent(32));
        }

        /// <summary>
        /// Check to see that null is returned when looking for a value that should be located in the
        /// left subtree.
        /// </summary>
        [TestMethod]
        public void FindParentLeftSubTreeNodeNotPresentTest()
        {
            BinarySearchTreeCollection<int> bst = new BinarySearchTreeCollection<int>()
            {
                10,
                9,
                23,
                17
            };

            Assert.IsNull(bst.FindParent(4));
        }

        /// <summary>
        /// Check to see that calling FindParent using the value of the root node returns null as the
        /// root node has no parent node.
        /// </summary>
        [TestMethod]
        public void FindParentRootNodeTest()
        {
            BinarySearchTreeCollection<int> bst = new BinarySearchTreeCollection<int>()
            {
                10,
                10,
                23,
                9
            };

            Assert.IsNull(bst.FindParent(10));
        }

        /// <summary>
        /// Check to see that the correct exception is raised if calling FindParent on a bst object
        /// that contains 0 items.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void FindParentNoItemsInBstTest()
        {
            BinarySearchTreeCollection<int> bst = new BinarySearchTreeCollection<int>();

            bst.FindParent(45);
        }

        /// <summary>
        /// Check to see that trying to remove a node that is not in the bst returns the correct value.
        /// </summary>
        [TestMethod]
        public void RemoveNodeNotFoundTest()
        {
            BinarySearchTreeCollection<int> bst = new BinarySearchTreeCollection<int>()
            {
                10,
                7,
                12
            };

            Assert.IsFalse(bst.Remove(4));
        }

        /// <summary>
        /// Check to see that removing a leaf node with a value less than its parent leaves
        /// the bst in the correct state.
        /// </summary>
        [TestMethod]
        public void RemoveLeafValueLessThanParentTest()
        {
            BinarySearchTreeCollection<int> bst = new BinarySearchTreeCollection<int>() 
            {
                10,
                7,
                12,
                11
            };

            Assert.IsTrue(bst.Remove(7));
            Assert.IsNull(bst.Root.Left);
            Assert.AreEqual(3, bst.Count);
        }

        /// <summary>
        /// Check to see taht removing a leaf node with a value greater than or equal to its parent
        /// leaves the bst in the correct state.
        /// </summary>
        [TestMethod]
        public void RemoveLeafValueGreaterThanOrEqualToParentTest()
        {
            BinarySearchTreeCollection<int> bst = new BinarySearchTreeCollection<int>()
            {
                10, 
                7,
                12
            };

            Assert.IsTrue(bst.Remove(12));
            Assert.IsNull(bst.Root.Right);
            Assert.AreEqual(2, bst.Count);
        }

        /// <summary>
        /// Check to see that removing a node that has only a right subtree leaves the bst
        /// in the correct state when the value of the nodeToRemove is greater than or equal 
        /// to the parent.
        /// </summary>
        [TestMethod]
        public void RemoveNodeWithRightSubtreeOnlyChildGreaterThanOrEqualToParentTest()
        {
            BinarySearchTreeCollection<int> bst = new BinarySearchTreeCollection<int>()
            {
                10,
                7,
                12,
                13
            };

            Assert.IsTrue(bst.Remove(12));
            Assert.AreEqual(13, bst.Root.Right.Value);
            Assert.AreEqual(3, bst.Count);
        }

        /// <summary>
        /// Check to see that removing a node that has only a right subtree leaves the bst
        /// in the correct state when the value of the nodeToRemove is less than the parent.
        /// </summary>
        [TestMethod]
        public void RemoveNodeWithRightSubtreeOnlyChildLessThanParentTest()
        {
            BinarySearchTreeCollection<int> bst = new BinarySearchTreeCollection<int>()
            {
                10,
                7,
                12, 
                13,
                8
            };

            Assert.IsTrue(bst.Remove(7));
            Assert.AreEqual(8, bst.Root.Left.Value);
            Assert.AreEqual(4, bst.Count);
        }

        /// <summary>
        /// Check to see that removing a node that has only a left subtree leaves the bst
        /// in the correct state when the value of the nodeToRemove is less than the parent. 
        /// </summary>
        [TestMethod]
        public void RemoveNodeWithLeftSubtreeOnlyChildLessThanParentTest()
        {
            BinarySearchTreeCollection<int> bst = new BinarySearchTreeCollection<int>()
            {
                35,
                21,
                43,
                17,
                26,
                59,
                13,
                15
            };

            Assert.IsTrue(bst.Remove(17));
            Assert.AreEqual(13, bst.Root.Left.Left.Value);
            Assert.AreEqual(7, bst.Count);
        }

        /// <summary>
        /// Check to see that removing a node that has only a left subtree leaves the bst
        /// in the correct state when the value of the nodeToRemove is greater than or equal to the parent. 
        /// </summary>
        [TestMethod]
        public void RemoveNodeWithLeftSubtreeOnlyChildGreaterThanOrEqualToParentTest()
        {
            BinarySearchTreeCollection<int> bst = new BinarySearchTreeCollection<int>()
            {
                35,
                21,
                43,
                17,
                26,
                59,
                13,
                15,
                65,
                61
            };

            Assert.IsTrue(bst.Remove(65));
            Assert.AreEqual(61, bst.Root.Right.Right.Right.Value);
            Assert.AreEqual(9, bst.Count);
        }

        /// <summary>
        /// Check to see that removing a node with a left and righ subtree leaves the bst in
        /// the correct state.
        /// </summary>
        [TestMethod]
        public void RemoveNodeWithBothSubtreesTest()
        {
            BinarySearchTreeCollection<int> bst = new BinarySearchTreeCollection<int>()
            {
                33,
                21,
                17,
                24,
                19,
                14,
                50,
                49
            };

            Assert.IsTrue(bst.Remove(21));
            Assert.IsNull(bst.FindNode(21));
            Assert.AreEqual(19, bst.Root.Left.Value);
            Assert.AreEqual(7, bst.Count);
        }

        /// <summary>
        /// Check to see that removing the root node when root is the only node in the
        /// bst leaves the bst in the correct state.
        /// </summary>
        [TestMethod]
        public void RemoveRootNoSubtreesTest()
        {
            BinarySearchTreeCollection<int> bst = new BinarySearchTreeCollection<int>()
            {
                33
            };

            Assert.IsTrue(bst.Remove(33));
            Assert.IsNull(bst.Root);
            Assert.AreEqual(0, bst.Count);
        }

    }
}
