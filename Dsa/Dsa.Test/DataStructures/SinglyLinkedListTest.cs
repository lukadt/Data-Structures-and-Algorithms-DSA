using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dsa.DataStructures;
using System.Collections;

namespace Dsa.Test
{

    /// <summary>
    /// Tests for SinglyLinkedList.
    /// </summary>
    [TestClass]
    public class SinglyLinkedListCollectionCollectionTest
    {

        /// <summary>
        /// Check to see the comparer is not null.
        /// </summary>
        [TestMethod]
        public void ConstructorTest()
        {
            IComparerProvider<int> actual = new SinglyLinkedList<int>();

            Assert.IsNotNull(actual.Comparer);
        }

        /// <summary>
        /// Check to see that the provided comparer is not null.
        /// </summary>
        [TestMethod]
        public void OverloadedConstructorTest()
        {
            IComparer<Coordinate> comparer = new CoordinateComparer();
            IComparerProvider<Coordinate> actual = new SinglyLinkedList<Coordinate>(comparer);

            Assert.IsNotNull(actual.Comparer);
        }

        /// <summary>
        /// Check to see that the correct exception is raised when the comparer is null.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void OverloadedConstructorComparerNullTest()
        {
            IComparer<Coordinate> comparer = null;
            SinglyLinkedList<Coordinate> actual = new SinglyLinkedList<Coordinate>(comparer);
        }

        /// <summary>
        /// Check to see that the SinglyLinkedListCollectionCollection reports as empty when it is.
        /// </summary>
        [TestMethod]
        public void IsEmptyTest()
        {
            SinglyLinkedList<int> sll = new SinglyLinkedList<int>();

            Assert.IsTrue(sll.IsEmpty());
        }

        /// <summary>
        /// Check to see that nodes are added correctly to the tail of the SinglyLinkedListCollection.
        /// </summary>
        [TestMethod]
        public void AddLastTest()
        {
            SinglyLinkedList<int> sll = new SinglyLinkedList<int>();

            sll.AddLast(5);
            sll.AddLast(10);
            sll.AddLast(15);

            Assert.IsFalse(sll.IsEmpty());
            Assert.AreEqual(5, sll.Head.Value);
            Assert.AreEqual(10, sll.Head.Next.Value);
            Assert.AreEqual(15, sll.Tail.Value);
        }

        /// <summary>
        /// Check to see that nodes are added correctly to the head of the SinglyLinkedListCollection.
        /// </summary>
        [TestMethod]
        public void AddFirstTest()
        {
            SinglyLinkedList<int> sll = new SinglyLinkedList<int>();

            sll.AddFirst(10);
            sll.AddFirst(20);
            sll.AddFirst(30);

            Assert.AreEqual(30, sll.Head.Value);
            Assert.AreEqual(20, sll.Head.Next.Value);
            Assert.AreEqual(10, sll.Tail.Value);
        }

        /// <summary>
        /// Check to see that the value of the Head node of the SinglyLinkedListCollection is as expected.
        /// </summary>
        [TestMethod]
        public void HeadTest()
        {
            SinglyLinkedList<string> sll = new SinglyLinkedList<string>();

            sll.AddLast("Granville");

            Assert.AreEqual("Granville", sll.Head.Value);
        }

        /// <summary>
        /// Check to see that the value of the Tail node of the SinglyLinkedListCollection is as expected.
        /// </summary>
        [TestMethod]
        public void TailTest()
        {
            SinglyLinkedList<int> sll = new SinglyLinkedList<int>();

            sll.AddLast(10);

            Assert.AreEqual(10, sll.Tail.Value);
        }

        /// <summary>
        /// Check to see that the Count property of the SinglyLinkedListCollection returns the correct nummber.
        /// </summary>
        [TestMethod]
        public void CountTest()
        {
            SinglyLinkedList<string> sll = new SinglyLinkedList<string>();

            sll.AddLast("Granville");
            sll.AddLast("Barnett");

            Assert.AreEqual(2, sll.Count);
        }

        /// <summary>
        /// Check to see that SinglyLinkedListCollection returns the correct items from the collection.
        /// </summary>
        [TestMethod]
        public void ForeachTest()
        {
            SinglyLinkedList<int> sll = new SinglyLinkedList<int>();
            SinglyLinkedList<int> expected = new SinglyLinkedList<int>();

            sll.AddLast(10);
            sll.AddLast(30);
            sll.AddLast(40);
            expected.AddLast(10);
            expected.AddLast(30);
            expected.AddLast(40);

            CollectionAssert.AreEqual(expected, sll);

        }

        /// <summary>
        /// Check to see that the expected array is returned from a SinglyLinkedListCollection that contains nodes.
        /// </summary>
        [TestMethod]
        public void ToArrayOfValidSinglyLinkedListCollectionTest()
        {
            SinglyLinkedList<int> sll = new SinglyLinkedList<int>();

            sll.AddLast(10);
            sll.AddLast(20);
            sll.AddLast(30);

            int[] expected = { 10, 20, 30 };

            CollectionAssert.AreEqual(expected, sll.ToArray());
        }

        /// <summary>
        /// Check to see that the expected exception is raised when ToArray is called on a SinglyLinkedListCollection
        /// that has no nodes.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ToArrayOfInvalidSinglyLinkedListCollectionTest()
        {
            SinglyLinkedList<int> sll = new SinglyLinkedList<int>();

            sll.ToArray();
        }

        /// <summary>
        /// Check to make sure that removing the only node from the SinglyLinkedListCollection results in the expected behaviour.
        /// </summary>
        [TestMethod]
        public void RemoveLastValidSinglyLinkedListCollectionWithOnlyOneNodeTest()
        {
            SinglyLinkedList<int> sll = new SinglyLinkedList<int>();

            sll.AddLast(10);
            sll.RemoveLast();

            Assert.AreEqual(0, sll.Count);
            Assert.IsTrue(sll.IsEmpty());
            Assert.IsNull(sll.Head);
            Assert.IsNull(sll.Tail);
        }

        /// <summary>
        /// Check to make sure that removing the last node from the SinglyLinkedListCollection results in the expected behaviour.
        /// </summary>
        [TestMethod]
        public void RemoveLastValidSinglyLinkedListCollectionWithMultipleNodesTest()
        {
            SinglyLinkedList<int> sll = new SinglyLinkedList<int>();

            sll.AddLast(10);
            sll.AddLast(20);
            sll.AddLast(30);
            sll.RemoveLast();

            Assert.AreEqual(20, sll.Tail.Value);
            Assert.AreEqual(2, sll.Count);
            Assert.IsNull(sll.Tail.Next);
        }

        /// <summary>
        /// Check to make sure that removing the last node from SinglyLinkedListCollection results in the expected behaviour.
        /// </summary>
        [TestMethod]
        public void RemoveLastValidSinglyLinkedListCollectionWithMultipleNodesTest2()
        {
            SinglyLinkedList<int> sll = new SinglyLinkedList<int>();

            sll.AddLast(10);
            sll.AddLast(20);
            sll.AddLast(30);
            sll.RemoveLast();
            sll.RemoveLast();

            Assert.AreEqual(10, sll.Tail.Value);
            Assert.AreEqual(10, sll.Head.Value);
            Assert.AreEqual(1, sll.Count);
            Assert.IsNull(sll.Tail.Next);
            Assert.IsNull(sll.Head.Next);
        }

        /// <summary>
        /// Check remove when there is only one node in the SinglyLinkedList.
        /// </summary>
        [TestMethod]
        public void RemoveOnlyOneNodeInListTest()
        {
            SinglyLinkedList<int> sll = new SinglyLinkedList<int>();

            sll.AddLast(10);
            sll.Remove(10);

            Assert.IsNull(sll.Head);
            Assert.IsNull(sll.Tail);
        }

        /// <summary>
        /// Check to make sure that removing all the nodes from a SinglyLinkedListCollection using the RemoveLast method works, then
        /// reassigning the head and tail returns the expected results.
        /// </summary>
        [TestMethod]
        public void RemoveLastValidSinglyLinkedListCollectionWithMultipleNodesAndReassingHeadAndTailTest()
        {
            SinglyLinkedList<int> sll = new SinglyLinkedList<int>();

            sll.AddLast(10);
            sll.AddLast(20);
            sll.AddLast(30);
            sll.AddFirst(5);
            sll.RemoveLast();
            sll.RemoveLast();
            sll.RemoveLast();
            sll.RemoveLast();
            sll.AddLast(1);

            Assert.AreEqual(1, sll.Count);
            Assert.AreEqual(1, sll.Head.Value);
            Assert.AreEqual(1, sll.Tail.Value);
            Assert.IsNull(sll.Head.Next);
            Assert.IsNull(sll.Tail.Next);
        }

        /// <summary>
        /// Check to see that the appropriate exception is raised when calling RemoveLast on a SinglyLinkedListCollection
        /// object containing no nodes.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void RemoveLastInvalidSinglyLinkedListCollectionTest()
        {
            SinglyLinkedList<int> sll = new SinglyLinkedList<int>();

            sll.AddLast(10);
            sll.RemoveLast();
            sll.RemoveLast();
        }

        /// <summary>
        /// Check to see that calling RemoveFirst on SinglyLinkedListCollection with only 1 node results in the expected behaviour.
        /// </summary>
        [TestMethod]
        public void RemoveFirstValidSinglyLinkedListCollectionWithOnlyOneNodeTest()
        {
            SinglyLinkedList<int> sll = new SinglyLinkedList<int>();

            sll.AddLast(10);
            sll.RemoveFirst();

            Assert.AreEqual(0, sll.Count);
            Assert.IsNull(sll.Head);
            Assert.IsNull(sll.Tail);
        }

        /// <summary>
        /// Check to see that when calling the RemoveFirst method on a SinglyLinkedListCollection with more than one node
        /// results in the expected object state.
        /// </summary>
        [TestMethod]
        public void RemoveFirstValidSinglyLinkedListCollectionWithMultipleNodesTest()
        {
            SinglyLinkedList<int> sll = new SinglyLinkedList<int>();

            sll.AddLast(10);
            sll.AddLast(20);
            sll.AddFirst(30);
            sll.RemoveFirst();
            sll.RemoveFirst();

            Assert.AreEqual(1, sll.Count);
            Assert.AreEqual(20, sll.Head.Value);
            Assert.AreEqual(20, sll.Tail.Value);
            Assert.IsNull(sll.Head.Next);
            Assert.IsNull(sll.Tail.Next);
        }

        /// <summary>
        /// Check to see that when calling the RemoveFirst method on a SinglyLinkedListCollection with more than one node
        /// results in the expected object state.
        /// </summary>
        [TestMethod]
        public void RemoveFirstValidSinglyLinkedListCollectionWithMultipleNodesTest2()
        {
            SinglyLinkedList<int> sll = new SinglyLinkedList<int>();

            sll.AddFirst(40);
            sll.AddFirst(30);
            sll.AddFirst(20);
            sll.AddFirst(10);
            sll.AddLast(50);
            sll.RemoveFirst();
            sll.RemoveFirst();

            Assert.AreEqual(30, sll.Head.Value);
            Assert.AreEqual(50, sll.Tail.Value);
            Assert.AreEqual(3, sll.Count);
        }

        /// <summary>
        /// Check to make sure that removing all the nodes in a SinglyLinkedListCollection using the RemoveFirst method, then
        /// reassigning the head and tail returns the expected results.
        /// </summary>
        [TestMethod]
        public void RemoveFirstValidSinglyLinkedListCollectionWithMultipleNodesAndReassingHeadAndTailTest()
        {
            SinglyLinkedList<int> sll = new SinglyLinkedList<int>();

            sll.AddLast(20);
            sll.AddLast(30);
            sll.AddFirst(10);
            sll.RemoveFirst();
            sll.RemoveFirst();
            sll.RemoveFirst();
            sll.AddFirst(10);

            Assert.AreEqual(1, sll.Count);
            Assert.AreEqual(10, sll.Head.Value);
            Assert.AreEqual(10, sll.Tail.Value);
            Assert.IsNull(sll.Head.Next);
            Assert.IsNull(sll.Tail.Next);
        }

        /// <summary>
        /// Check to see that the appropriate exception is raised when calling RemoveFirst on a SinglyLinkedListCollection
        /// object containing no nodes.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void RemoveFirstInvalidSinglyLinkedListCollectionTest()
        {
            SinglyLinkedList<int> sll = new SinglyLinkedList<int>();

            sll.RemoveFirst();
        }

        /// <summary>
        /// Check to see that the appropriate exception is raised when calling RemoveFirst on a SinglyLinkedListCollection
        /// object containing no nodes.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void RemoveFirstInvalidSinglyLinkedListCollectionTest2()
        {
            SinglyLinkedList<int> sll = new SinglyLinkedList<int>();

            sll.AddFirst(10);
            sll.RemoveFirst();
            sll.RemoveFirst();
        }

        /// <summary>
        /// Check to see that the Add method is leaving the SinglyLinkedListCollection object in the correct state.
        /// </summary>
        [TestMethod]
        public void ICollectionAddTest()
        {
            SinglyLinkedList<int> sll = new SinglyLinkedList<int>();
            ICollection<int> collectionSll = sll;

            collectionSll.Add(10);
            collectionSll.Add(20);

            Assert.AreEqual(10, sll.Head.Value);
            Assert.AreEqual(20, sll.Tail.Value);
            Assert.AreEqual(2, sll.Count);
        }

        /// <summary>
        /// Check to see that calling the Clear method resets the SinglyLinkedListCollection object's internal state.
        /// </summary>
        [TestMethod]
        public void ClearTest()
        {
            SinglyLinkedList<int> sll = new SinglyLinkedList<int>();

            sll.AddLast(10);
            sll.AddLast(20);
            sll.AddLast(30);
            sll.Clear();

            Assert.AreEqual(0, sll.Count);
            Assert.IsNull(sll.Head);
            Assert.IsNull(sll.Tail);
        }

        /// <summary>
        /// Check to see that the contains method returns the correct bool depending on whether the item is in the 
        /// SinglyLinkedListCollection or not.
        /// </summary>
        [TestMethod]
        public void ContainsTest()
        {
            SinglyLinkedList<int> sll = new SinglyLinkedList<int>();

            sll.AddLast(10);
            sll.AddLast(20);
            sll.AddLast(30);

            Assert.IsTrue(sll.Contains(20));
            Assert.IsFalse(sll.Contains(40));
        }

        /// <summary>
        /// Check to see that the correct exception is raised when using a negative index for the arrayIndex parameter
        /// for CopyTo.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CopyToInvalidIndexTest()
        {
            SinglyLinkedList<int> sll = new SinglyLinkedList<int>();

            sll.AddLast(10);
            sll.AddLast(20);
            sll.AddLast(30);
            int[] myArray = new int[sll.Count];
            sll.CopyTo(myArray, -1);
        }

        /// <summary>
        /// Check to see that passing in an index that is equal to or greater than the array size throws
        /// the correct exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CopyToIndexGteThanArrayTest()
        {
            SinglyLinkedList<int> sll = new SinglyLinkedList<int>();

            sll.AddLast(10);
            sll.AddLast(20);
            sll.AddLast(30);
            int[] myArray = new int[sll.Count];
            sll.CopyTo(myArray, 2);
        }

        /// <summary>
        /// Check to see that CopyTo copies all items of SinglyLinkedListCollection to an array beginning at a specified index.
        /// </summary>
        [TestMethod]
        public void ArrayCopyWithDefinedStartIndexTest()
        {
            SinglyLinkedList<int> sll = new SinglyLinkedList<int>();

            sll.AddLast(10);
            sll.AddLast(20);
            sll.AddLast(30);
            int[] actual = new int[10];
            sll.CopyTo(actual, 6);

            Assert.AreEqual(10, actual[6]);
            Assert.AreEqual(20, actual[7]);
            Assert.AreEqual(30, actual[8]);
        }

        /// <summary>
        /// Check to see that the correct exception is raised when attempting to remove an item from an empty
        /// SinglyLinkedListCollection.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void RemoveItemFromEmptySinglyLinkedListCollection()
        {
            SinglyLinkedList<int> sll = new SinglyLinkedList<int>();

            sll.Remove(10);
        }

        /// <summary>
        /// Check to see that Remove leaves the SinglyLinkedListCollection in the correct state where the value of Remove
        /// is equal to that of the head node.
        /// </summary>
        [TestMethod]
        public void RemoveHeadItemTest()
        {
            SinglyLinkedList<int> sll = new SinglyLinkedList<int>();

            sll.AddLast(10);
            sll.AddLast(20);
            sll.AddLast(30);
            bool actual = sll.Remove(10);

            Assert.AreEqual(20, sll.Head.Value);
            Assert.AreEqual(30, sll.Tail.Value);
            Assert.AreEqual(30, sll.Head.Next.Value);
            Assert.AreEqual(2, sll.Count);
            Assert.IsTrue(actual);
        }

        /// <summary>
        /// Check to see that Remove leaves the SinglyLinkedListCollection in the correct state, when remove is any node but head or tail.
        /// </summary>
        [TestMethod]
        public void RemoveMiddleItemTest()
        {
            SinglyLinkedList<int> sll = new SinglyLinkedList<int>();

            sll.AddLast(10);
            sll.AddLast(20);
            sll.AddLast(30);
            bool actual = sll.Remove(20);

            Assert.AreEqual(30, sll.Head.Next.Value);
            Assert.AreEqual(10, sll.Head.Value);
            Assert.AreEqual(30, sll.Tail.Value);
            Assert.AreEqual(2, sll.Count);
            Assert.IsTrue(actual);
        }

        /// <summary>
        /// Check to see that Remove leaves the SinglyLinkedListCollection in the correct state where the value of Remove
        /// is equal to that of the tail node.
        /// </summary>
        [TestMethod]
        public void RemoveTailItemTest()
        {
            SinglyLinkedList<int> sll = new SinglyLinkedList<int>();

            sll.AddLast(10);
            sll.AddLast(20);
            sll.AddLast(30);
            bool actual = sll.Remove(30);

            Assert.AreEqual(10, sll.Head.Value);
            Assert.AreEqual(20, sll.Head.Next.Value);
            Assert.AreEqual(20, sll.Tail.Value);
            Assert.AreEqual(2, sll.Count);
            Assert.IsNull(sll.Tail.Next);
            Assert.IsTrue(actual);
        }

        /// <summary>
        /// Check to see that when calling the Remove method passing in a value that is not contained in the SinglyLinkedListCollection
        /// returns false.
        /// </summary>
        [TestMethod]
        public void RemoveWithNoMatchTest()
        {
            SinglyLinkedList<int> sll = new SinglyLinkedList<int>();

            sll.AddLast(20);
            sll.AddLast(30);
            sll.AddLast(50);

            Assert.AreEqual(3, sll.Count);
            Assert.IsFalse(sll.Remove(110));
        }

        /// <summary>
        /// Check to see that the head and tail nodes are correct after adding a node after the only node in the SinglyLinkedListCollection.
        /// </summary>
        [TestMethod]
        public void AddAfterOnlyOneNodeInSinglyLinkedListCollectionTest()
        {
            SinglyLinkedList<int> sll = new SinglyLinkedList<int>();

            sll.AddLast(10);
            sll.AddAfter(sll.Head, 20);

            Assert.AreEqual(20, sll.Tail.Value);
            Assert.AreEqual(10, sll.Head.Value);
            Assert.AreEqual(20, sll.Head.Next.Value);
            Assert.AreEqual(2, sll.Count);
        }

        /// <summary>
        /// Check to see that the tail node is updated after adding a node after the tail in the SinglyLinkedListCollection.
        /// </summary>
        [TestMethod]
        public void AddAfterTailTest()
        {
            SinglyLinkedList<int> sll = new SinglyLinkedList<int>();

            sll.AddLast(10);
            sll.AddLast(20);
            sll.AddAfter(sll.Tail, 30);

            Assert.AreEqual(30, sll.Tail.Value);
            Assert.AreEqual(30, sll.Head.Next.Next.Value);
            Assert.AreEqual(3, sll.Count);
        }

        /// <summary>
        /// Check to see that adding a node somewhere in the middle of the SinglyLinkedListCollection leaves the SinglyLinkedListCollection
        /// in the correct state.
        /// </summary>
        [TestMethod]
        public void AddAfterMiddleNodeTest()
        {
            SinglyLinkedList<int> sll = new SinglyLinkedList<int>();

            sll.AddLast(10);
            sll.AddLast(20);
            sll.AddLast(30);
            sll.AddAfter(sll.Head.Next, 25);

            Assert.AreEqual(25, sll.Head.Next.Next.Value);
            Assert.AreEqual(30, sll.Head.Next.Next.Next.Value);
            Assert.AreEqual(4, sll.Count);
        }

        /// <summary>
        /// Check to see that the correct exception is raised when AddAfter is invoked on a SinglyLinkedListCollection with no nodes.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void AddAfterEmptySinglyLinkedListCollectionTest()
        {
            SinglyLinkedList<int> sll = new SinglyLinkedList<int>();

            sll.AddAfter(sll.Head, 10);
        }

        /// <summary>
        /// Check to see that AddAfter raises the correct exception when trying to add a new node after a null node in the SinglyLinkedListCollection.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddAfterNullNodeSinglyLinkedListCollectionTest()
        {
            SinglyLinkedList<int> sll = new SinglyLinkedList<int>();

            sll.AddLast(10);
            sll.AddAfter(sll.Head.Next, 20);
        }

        /// <summary>
        /// Check to see that AddBefore when passing in the head node of the SinglyLinkedListCollection results in the expected state.
        /// </summary>
        [TestMethod]
        public void AddBeforeHeadTest()
        {
            SinglyLinkedList<int> sll = new SinglyLinkedList<int>();

            sll.AddLast(10);
            sll.AddLast(20);
            sll.AddLast(30);
            sll.AddBefore(sll.Head, 5);

            Assert.AreEqual(5, sll.Head.Value);
            Assert.AreEqual(10, sll.Head.Next.Value);
            Assert.AreEqual(4, sll.Count);
        }

        /// <summary>
        /// Check to make sure that adding before tail results in the expected object state.
        /// </summary>
        [TestMethod]
        public void AddBeforeTailTest()
        {
            SinglyLinkedList<int> sll = new SinglyLinkedList<int>();

            sll.AddLast(10);
            sll.AddLast(20);
            sll.AddLast(30);
            sll.AddLast(40);
            sll.AddBefore(sll.Head.Next.Next.Next, 35);

            Assert.AreEqual(35, sll.Head.Next.Next.Next.Value);
        }

        /// <summary>
        /// Check to see that AddBefore a middle node results in the expected state of the SinglyLinkedListCollection.
        /// </summary>
        [TestMethod]
        public void AddBeforeMiddleNodeTest()
        {
            SinglyLinkedList<int> sll = new SinglyLinkedList<int>();

            sll.AddLast(10);
            sll.AddLast(20);
            sll.AddLast(30);
            sll.AddBefore(sll.Head.Next, 15);

            Assert.AreEqual(15, sll.Head.Next.Value);
            Assert.AreEqual(20, sll.Head.Next.Next.Value);
            Assert.AreEqual(4, sll.Count);
        }

        /// <summary>
        /// Check to see that the correct exception is raised when calling AddBefore on a SinglyLinkedListCollection with no nodes.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void AddBeforeEmptySinglyLinkedListCollectionTEst()
        {
            SinglyLinkedList<int> sll = new SinglyLinkedList<int>();

            sll.AddBefore(sll.Head, 10);
        }

        /// <summary>
        /// Check to see that the correct exception is raised when calling AddBefore on a SinglyLinkedListCollection when 
        /// passing in a null node.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddBeforeNullNodeSinglyLinkedListCollectionTest()
        {
            SinglyLinkedList<int> sll = new SinglyLinkedList<int>();

            sll.AddLast(10);
            sll.AddLast(20);
            sll.AddLast(30);
            sll.AddBefore(sll.Tail.Next, 40);
        }

        /// <summary>
        /// Check to make sure that the IEnumerator returned by the GetEnumerator is not null.
        /// </summary>
        [TestMethod]
        public void GetEnumeratorGenericTest()
        {
            SinglyLinkedList<int> sll = new SinglyLinkedList<int>();

            sll.AddLast(10);

            Assert.IsNotNull(sll.GetEnumerator());
        }

        /// <summary>
        /// Check to make sure that IEnumerable.GetEnumerator returns an IEnumerator that is not null.
        /// </summary>
        [TestMethod]
        public void GetEnumeratorTest()
        {
            SinglyLinkedList<int> sll = new SinglyLinkedList<int>();
            IEnumerable enumerSll = sll;

            sll.AddLast(10);

            Assert.IsNotNull(enumerSll.GetEnumerator());
        }

        /// <summary>
        /// Check to make sure that GetReverseEnumerator returns a non-null IEnumerator(Of T) object.
        /// </summary>
        [TestMethod]
        public void GetReverseEnumeratorTest()
        {
            SinglyLinkedList<int> sll = new SinglyLinkedList<int>();

            sll.AddLast(10);
            sll.AddLast(20);
            sll.AddLast(30);

            Assert.IsNotNull(sll.GetReverseEnumerator());
        }

        /// <summary>
        /// Check to see that the correct array is returned from a call to ToReverseArray.
        /// </summary>
        [TestMethod]
        public void ToReverseArrayTest()
        {
            SinglyLinkedList<int> sll = new SinglyLinkedList<int>();

            sll.AddLast(10);
            sll.AddLast(20);
            sll.AddLast(30);
            int[] expected = { 30, 20, 10 };

            CollectionAssert.AreEqual(expected, sll.ToReverseArray());
        }

        /// <summary>
        /// Check to see that calling ToReverseArray on a SinglyLinkedListCollection with no items raises the correct
        /// exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ToReverseArrayNoItemsTest()
        {
            SinglyLinkedList<int> sll = new SinglyLinkedList<int>();

            sll.ToReverseArray();
        }

    }

}
