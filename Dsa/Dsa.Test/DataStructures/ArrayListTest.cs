using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dsa.DataStructures;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Dsa.Test
{

    /// <summary>
    /// Tests for ArrayList.
    /// </summary>
    [TestClass]
    public class ArrayListCollectionTest
    {

        /// <summary>
        /// Check to see that Add returns the correct value.
        /// </summary>
        [TestMethod]
        public void AddTest()
        {
            ArrayList<int> actual = new ArrayList<int>();

            Assert.AreEqual(0, actual.Add(10));
            Assert.AreEqual(1, actual.Add(20));
            Assert.AreEqual(2, actual.Add(30));
            Assert.AreEqual(3, actual.Add(40));
            Assert.AreEqual(4, actual.Add(50));
        }

        /// <summary>
        /// Check to see that the specified comparer is not null.
        /// </summary>
        [TestMethod]
        public void OverloadedConstructorTest()
        {
            IComparer<Coordinate> comparer = new CoordinateComparer();
            IComparerProvider<Coordinate> actual = new ArrayList<Coordinate>(comparer);

            Assert.IsNotNull(actual.Comparer);
        }

        /// <summary>
        /// Check to check that the constructor throws the correct exception when passed a null IComparer.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void OverloadedConstructorNullComparerTest()
        {
            IComparer<Coordinate> comparer = null;
            ArrayList<Coordinate> actual = new ArrayList<Coordinate>(comparer);
        }

        /// <summary>
        /// Check to see that Count returns the expected value.
        /// </summary>
        [TestMethod]
        public void CountTest()
        {
            ArrayList<int> actual = new ArrayList<int>();

            actual.Add(10);
            actual.Add(20);
            actual.Add(30);
            actual.Add(40);
            actual.Add(50);

            Assert.AreEqual(5, actual.Count);
        }

        /// <summary>
        /// Check to see that IComcity returns the expected value when no resixing occurs.
        /// </summary>
        [TestMethod]
        public void CapacityNoResizeTest()
        {
            ArrayList<int> actual = new ArrayList<int>();

            Assert.AreEqual(4, actual.Capacity);
        }

        /// <summary>
        /// Check to see that Capacity returns the expected value when resizing has occurred.
        /// </summary>
        [TestMethod]
        public void CapacityResizeTest()
        {
            ArrayList<int> actual = new ArrayList<int>();

            actual.Add(10);
            actual.Add(20);
            actual.Add(30);
            actual.Add(40);
            actual.Add(50);

            Assert.AreEqual(8, actual.Capacity);
        }

        /// <summary>
        /// Check to see that the correct index is returned for an item in the ArrayListColleciton.
        /// </summary>
        [TestMethod]
        public void IndexOfTest()
        {
            ArrayList<string> actual = new ArrayList<string>();

            actual.Add("London");
            actual.Add("Paris");
            actual.Add("New York");

            Assert.AreEqual(1, actual.IndexOf("Paris"));
            Assert.AreEqual(-1, actual.IndexOf("Prague"));
        }

        /// <summary>
        /// Check top see that the correct value is returned by index.
        /// </summary>
        [TestMethod]
        public void IndexInRangeTest()
        {
            ArrayList<int> actual = new ArrayList<int>();

            actual.Add(10);
            actual.Add(20);
            actual.Add(30);

            Assert.AreEqual(10, actual[0]);
            Assert.AreEqual(20, actual[1]);
            Assert.AreEqual(30, actual[2]);
        }

        /// <summary>
        /// Check to see that calling by index with a negative number throws the correct exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void IndexNegRangTest()
        {
            ArrayList<int> alc = new ArrayList<int>();

            int actual = alc[-1];
        }

        /// <summary>
        /// Check to see that accessing an index which is out of range, e.g. in this scenario we have the default
        /// array size of 4, so accessing index of 4 will result in accessing an index which is out of range.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void IndexOutOfRange()
        {
            ArrayList<int> alc = new ArrayList<int>();

            int actual = alc[4];
        }

        /// <summary>
        /// Check to see that setting the value at an index works as expected.
        /// </summary>
        [TestMethod]
        public void IndexSetTest()
        {
            ArrayList<int> actual = new ArrayList<int>();

            actual.Add(10);
            actual.Add(20);
            actual.Add(30);
            actual[2] = 22;
            actual[3] = 25;

            Assert.AreEqual(4, actual.Count);
            Assert.AreEqual(22, actual[2]);
            Assert.AreEqual(25, actual[3]);
        }

        /// <summary>
        /// Check to see that the correct exception is raised when trying to set the value of an index
        /// that is out of range.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void IndexSetNegTest()
        {
            ArrayList<int> actual = new ArrayList<int>();

            actual[4] = 10;
        }

        /// <summary>
        /// Check to see that when setting an index which is out of range, e.g. in this scenario we have the default
        /// array size of 4, so setting index of 4 will result in accessing an index which is out of range.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void IndexSetOutOfRange()
        {
            ArrayList<int> actual = new ArrayList<int>();

            actual[4] = 5;
        }

        /// <summary>
        /// Check to see that IsReadonly returns false.
        /// </summary>
        [TestMethod]
        public void IListIsReadonlyTest()
        {
            ArrayList<int> actual = new ArrayList<int>();
            IList iL = actual;

            Assert.IsFalse(iL.IsReadOnly);
        }

        /// <summary>
        /// Check to see that IList.IsFixedSize returns false.
        /// </summary>
        [TestMethod]
        public void IListIsFixedSizeTest()
        {
            ArrayList<int> acl = new ArrayList<int>();
            IList actual = acl;

            Assert.IsFalse(actual.IsFixedSize);
        }

        /// <summary>
        /// Check to see that the correct value is returned by ICollection{T}.IsReadOnly property.
        /// </summary>
        [TestMethod]
        public void ICollectionIsReadOnlyTest()
        {
            ArrayList<int> alc = new ArrayList<int>();
            ICollection<int> actual = alc;

            Assert.IsFalse(actual.IsReadOnly);
        }

        /// <summary>
        /// Check to see that calling ICollection(Of T).Add results in the expected behaviour.
        /// </summary>
        [TestMethod]
        public void ICollectionGenericAddTest()
        {
            ArrayList<int> alc = new ArrayList<int>();
            ICollection<int> actual = alc;

            actual.Add(10);
            actual.Add(20);

            Assert.AreEqual(2, actual.Count);
        }

        /// <summary>
        /// Check to see that calling IList.Add on a value type collection results in the expected exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void IListAddValueTypeTest()
        {
            ArrayList<int> alc = new ArrayList<int>();
            IList actual = alc;

            Assert.AreEqual(0, actual.Add(10));
            Assert.AreEqual(1, actual.Add(20));
            Assert.AreEqual(2, actual.Count);
        }

        /// <summary>
        /// Check to see that adding a reference type using IList.Add that is the same as T is accepted and results in the expected
        /// behaviour.
        /// </summary>
        [TestMethod]
        public void IListAddTest()
        {
            ArrayList<string> alc = new ArrayList<string>();
            IList actual = alc;

            Assert.AreEqual(0, actual.Add("London"));
            Assert.AreEqual(1, actual.Add("Paris"));
            Assert.AreEqual(2, actual.Count);
        }

        /// <summary>
        /// Check to see that clear defaults every value in the array list (null for reference types, 0 for value types)
        /// and resets count to 0. 
        /// </summary>
        [TestMethod]
        public void ClearTest()
        {
            ArrayList<int> alc = new ArrayList<int>();

            alc.Add(10);
            alc.Add(20);
            alc.Add(30);
            alc.Add(40);
            alc.Add(50);
            alc.Clear();

            Assert.AreEqual(0, alc.Count);
            Assert.AreEqual(4, alc.Capacity);
        }

        /// <summary>
        /// Check to see calling insert specifying a index which has already been allocated results inteh expected
        /// behaviour, i.e. count is not incremented and the existing value at the index is overwritten.
        /// </summary>
        [TestMethod]
        public void InsertExisistingIndexTakenTest()
        {
            ArrayList<int> actual = new ArrayList<int>();

            actual.Add(10);
            actual.Add(20);
            actual.Add(30);
            actual.Insert(2, 40);

            Assert.AreEqual(3, actual.Count);
            Assert.AreEqual(40, actual[2]);
        }

        /// <summary>
        /// Check to see that Add honours a previous Insert.
        /// </summary>
        [TestMethod]
        public void AddHonoursInsertTest()
        {
            ArrayList<int> actual = new ArrayList<int>();

            actual.Insert(2, 30);
            actual.Add(10);
            actual.Add(20);
            actual.Add(40);
            actual.Add(50);

            Assert.AreEqual(30, actual[2]);
            Assert.AreEqual(5, actual.Count);
        }

        /// <summary>
        /// Check to see that when inserting and specifying an out of range index results in the correct exception
        /// being raised.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void InsertOutOfRangeIndexTest()
        {
            ArrayList<int> actual = new ArrayList<int>();

            actual.Insert(7, 30);
        }

        /// <summary>
        /// Check to make sure that RemoveAt leaves the array in the correct state.
        /// </summary>
        [TestMethod]
        public void RemoveAtTest()
        {
            ArrayList<int> actual = new ArrayList<int>();

            actual.Add(10);
            actual.Add(20);
            actual.Add(30);
            actual.Add(40);
            actual.RemoveAt(2);

            Assert.AreEqual(10, actual[0]);
            Assert.AreEqual(20, actual[1]);
            Assert.AreEqual(40, actual[2]);
            Assert.AreEqual(0, actual[3]);
        }

        /// <summary>
        /// Check to make sure that RemoveAt leaves the array in the correct state.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void RemoveAtOutOfRangeIndexTest()
        {
            ArrayList<int> actual = new ArrayList<int>();

            actual.Add(10);
            actual.Add(20);
            actual.Add(30);
            actual.Add(40);
            actual.RemoveAt(-2);
        }

        /// <summary>
        /// Check to make sure that Remove leaves the array in the correct state.
        /// </summary>
        [TestMethod]
        public void RemoveTest()
        {
            ArrayList<int> actual = new ArrayList<int>();

            actual.Add(10);
            actual.Add(20);
            actual.Add(30);
            actual.Add(40);
            actual.Add(50);
            actual.Add(60);

            Assert.IsFalse(actual.Remove(90));
            Assert.IsTrue(actual.Remove(30));
            Assert.AreEqual(40, actual[2]);
        }

        /// <summary>
        /// Check to see that IList.Contains returns the correct value.
        /// </summary>
        [TestMethod]
        public void IListContainsTest()
        {
            ArrayList<string> alc = new ArrayList<string>();
            IList actual = alc;

            actual.Add("London");
            actual.Add("Paris");
            actual.Add("Montreal");

            Assert.IsTrue(actual.Contains("Paris"));
            Assert.IsFalse(actual.Contains("Berlin"));
        }

        /// <summary>
        /// Check to see that using a non-compatiable type results in expected exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void IListContainsNonCompatTypeTest()
        {
            ArrayList<int> alc = new ArrayList<int>();
            IList actual = alc;

            actual.Contains(10);
        }

        /// <summary>
        /// Check to see that the correct index is passed back when calling IndexOf.
        /// </summary>
        [TestMethod]
        public void IListIndexOfTest()
        {
            ArrayList<string> alc = new ArrayList<string>();
            IList actual = alc;

            actual.Add("London");
            actual.Add("Paris");
            actual.Add("Berlin");

            Assert.AreEqual(2, actual.IndexOf("Berlin"));
            Assert.AreEqual(-1, actual.IndexOf("Prague"));
        }

        /// <summary>
        /// Check to see that the correct exception is raied when using a non compatible type.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void IListIndexOfUnsupportedTypeTest()
        {
            ArrayList<int> alc = new ArrayList<int>();
            IList actual = alc;

            actual.IndexOf(30);
        }

        /// <summary>
        /// Check to see that calling IList.Insert results in the expected behaviour.
        /// </summary>
        [TestMethod]
        public void IListInsertTest()
        {
            ArrayList<string> alc = new ArrayList<string>();
            IList actual = alc;

            actual.Insert(2, "London");

            Assert.AreEqual("London", alc[2]);
        }

        /// <summary>
        /// Check to see that IList.Insert raises the correct exception when inserting an unsupoorted type.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void IListInsertUnsupportedTypeTest()
        {
            ArrayList<int> alc = new ArrayList<int>();
            IList actual = alc;

            actual.Insert(2, 5);
        }

        /// <summary>
        /// Check to see that IList.RemoveAt results in the expected object state.
        /// </summary>
        [TestMethod]
        public void IListRemoveAtTest()
        {
            ArrayList<string> alc = new ArrayList<string>();
            IList actual = alc;

            actual.Add("London");
            actual.Add("Paris");
            actual.RemoveAt(0);

            Assert.AreEqual("Paris", alc[0]);
            Assert.AreEqual(1, actual.Count);
        }

        /// <summary>
        /// Check to see that calling IList.Remove results in the expected behaviour.
        /// </summary>
        [TestMethod]
        public void IListRemoveTest()
        {
            ArrayList<string> alc = new ArrayList<string>();
            IList actual = alc;

            actual.Add("Paris");
            actual.Add("Berlin");
            actual.Add("London");
            actual.Remove("Berlin");

            Assert.AreEqual("London", alc[1]);
            Assert.AreEqual(2, actual.Count);
        }

        /// <summary>
        /// Check to see that the correct exception is raised when remove is called with an unsupported type.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void IListRemoveNotSupportedTypeTest()
        {
            ArrayList<int> alc = new ArrayList<int>();
            IList actual = alc;

            actual.Remove(20);
        }

        /// <summary>
        /// Check to see that setting by index results in the correct behaviour.
        /// </summary>
        [TestMethod]
        public void IListByIndexTest()
        {
            ArrayList<string> alc = new ArrayList<string>();
            IList actual = alc;

            actual.Add("London");
            actual.Add("Paris");
            actual.Add("Berlin");
            actual[3] = "Venice";
            actual[2] = "Prague";

            Assert.AreEqual(4, actual.Count);
            Assert.AreEqual("Prague", actual[2] as string);
            Assert.AreEqual("Venice", actual[3] as string);
        }

        /// <summary>
        /// Check to see that setting by index when the value is a type that is not supported results in the
        /// expected exception being raised.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void IListByIndexNotSupportedTypeTest()
        {
            ArrayList<string> alc = new ArrayList<string>();
            IList actual = alc;

            actual[0] = new Hashtable();
        }

        /// <summary>
        /// Check to see that IsSynchronized returns false.
        /// </summary>
        [TestMethod]
        public void IsSynchronizedTest()
        {
            ArrayList<int> alc = new ArrayList<int>();
            ICollection actual = alc;

            Assert.IsFalse(actual.IsSynchronized);
        }

        /// <summary>
        /// Check to see that SyncRoot returns a non null object.
        /// </summary>
        [TestMethod]
        public void SyncRootTest()
        {
            ArrayList<int> alc = new ArrayList<int>();
            ICollection actual = alc;

            Assert.IsNotNull(actual.SyncRoot);
        }

        /// <summary>
        /// Check to see that Contains returns the expected value.
        /// </summary>
        [TestMethod]
        public void ContainsTest()
        {
            ArrayList<int> actual = new ArrayList<int>();

            actual.Add(10);
            actual.Add(20);
            actual.Add(30);
            actual.Add(40);
            actual.Add(50);

            Assert.IsTrue(actual.Contains(30));
            Assert.IsFalse(actual.Contains(60));
        }

        /// <summary>
        /// Check to see that CopyTo results in the expected array.
        /// </summary>
        [TestMethod]
        public void CopyToTest()
        {
            ArrayList<int> acl = new ArrayList<int>();

            acl.Add(10);
            acl.Add(20);
            acl.Add(30);
            int[] actual = new int[acl.Capacity];
            acl.CopyTo(actual, 0);
            int[] expected = { 10, 20, 30, 0 };

            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Check to see that the correct exception is raised when using the non-generic CopyTo method.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(NotSupportedException))]
        public void ICollectionCopyToTest()
        {
            ArrayList<int> alc = new ArrayList<int>();
            ICollection actual = alc;

            int[] expected = new int[alc.Capacity];
            actual.CopyTo(expected, 0);
        }

        /// <summary>
        /// Check to see that two ArrayListCollections with the same value items are equal.
        /// </summary>
        [TestMethod]
        public void ItemsAreSameTest()
        {
            ArrayList<int> actual = new ArrayList<int>();
            ArrayList<int> expected = new ArrayList<int>();

            actual.Add(10);
            actual.Add(20);
            actual.Add(30);
            expected.Add(10);
            expected.Add(20);
            expected.Add(30);

            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Check to see that the IEnumerator(Of T) returned from GetEnumerator is not null.
        /// </summary>
        [TestMethod]
        public void GetEnumeratorTest()
        {
            ArrayList<int> actual = new ArrayList<int>();

            actual.Add(10);
            actual.Insert(2, 30);
            foreach (int i in actual) Console.WriteLine(i);

            Assert.IsNotNull(actual.GetEnumerator());
        }

        /// <summary>
        /// Check to see that ICollection.GetEnumerator returns a non-null IEnumerator.
        /// </summary>
        [TestMethod]
        public void ICollectionGetEnumeratorTest()
        {
            ArrayList<int> alc = new ArrayList<int>();
            ICollection actual = alc;

            Assert.IsNotNull(actual.GetEnumerator());
        }

    }

}
