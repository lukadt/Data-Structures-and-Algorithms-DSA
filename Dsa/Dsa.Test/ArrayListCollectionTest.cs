﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dsa.DataStructures;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Dsa.Test {

    [TestClass]
    public class ArrayListCollectionTest {

        /// <summary>
        /// Test to see that Add returns the correct value.
        /// </summary>
        [TestMethod]
        public void AddTest() {
            ArrayListCollection<int> actual = new ArrayListCollection<int>();

            Assert.AreEqual<int>(0, actual.Add(10));
            Assert.AreEqual<int>(1, actual.Add(20));
            Assert.AreEqual<int>(2, actual.Add(30));
            Assert.AreEqual<int>(3, actual.Add(40));
            Assert.AreEqual<int>(4, actual.Add(50));
        }

        /// <summary>
        /// Test to see that Count returns the expected value.
        /// </summary>
        [TestMethod]
        public void CountTest() {
            ArrayListCollection<int> actual = new ArrayListCollection<int>();

            actual.Add(10);
            actual.Add(20);
            actual.Add(30);
            actual.Add(40);
            actual.Add(50);

            Assert.AreEqual<int>(5, actual.Count);
        }

        /// <summary>
        /// Test to see that Capacity returns the expected value when no resixing occurs.
        /// </summary>
        [TestMethod]
        public void CapacityNoResizeTest() {
            ArrayListCollection<int> actual = new ArrayListCollection<int>();

            Assert.AreEqual<int>(4, actual.Capacity);
        }

        /// <summary>
        /// Test to see that Capacity returns the expected value when resizing has occurred.
        /// </summary>
        [TestMethod]
        public void CapacityResizeTest() {
            ArrayListCollection<int> actual = new ArrayListCollection<int>();

            actual.Add(10);
            actual.Add(20);
            actual.Add(30);
            actual.Add(40);
            actual.Add(50);

            Assert.AreEqual<int>(8, actual.Capacity);
        }

        /// <summary>
        /// Test to see that the correct index is returned for an item in the ArrayListColleciton.
        /// </summary>
        [TestMethod]
        public void IndexOfTest() {
            ArrayListCollection<string> actual = new ArrayListCollection<string>();

            actual.Add("London");
            actual.Add("Paris");
            actual.Add("New York");

            Assert.AreEqual<int>(1, actual.IndexOf("Paris"));
            Assert.AreEqual<int>(-1, actual.IndexOf("Prague"));
        }

        /// <summary>
        /// Test top see that the correct value is returned by index.
        /// </summary>
        [TestMethod]
        public void IndexInRangeTest() {
            ArrayListCollection<int> actual = new ArrayListCollection<int>();

            actual.Add(10);
            actual.Add(20);
            actual.Add(30);

            Assert.AreEqual<int>(10, actual[0]);
            Assert.AreEqual<int>(20, actual[1]);
            Assert.AreEqual<int>(30, actual[2]);
        }

        /// <summary>
        /// Test to see that calling by index with a negative number throws the correct exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void IndexNegRangTest() {
            ArrayListCollection<int> alc = new ArrayListCollection<int>();

            int actual = alc[-1];
        }

        /// <summary>
        /// Test to see that accessing an index which is out of range, e.g. in this scenario we have the default
        /// array size of 4, so accessing index of 4 will result in accessing an index which is out of range.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void IndexOutOfRange() {
            ArrayListCollection<int> alc = new ArrayListCollection<int>();

            int actual = alc[4];
        }

        /// <summary>
        /// Test to see that setting the value at an index works as expected.
        /// </summary>
        [TestMethod]
        public void IndexSetTest() {
            ArrayListCollection<int> actual = new ArrayListCollection<int>();

            actual.Add(10);
            actual.Add(20);
            actual.Add(30);
            actual[2] = 22;
            actual[3] = 25;

            Assert.AreEqual<int>(4, actual.Count);
            Assert.AreEqual<int>(22, actual[2]);
            Assert.AreEqual<int>(25, actual[3]);
        }

        /// <summary>
        /// Test to see that the correct exception is raised when trying to set the value of an index
        /// that is out of range.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void IndexSetNegTest() {
            ArrayListCollection<int> actual = new ArrayListCollection<int>();

            actual[4] = 10;
        }

        /// <summary>
        /// Test to see that when setting an index which is out of range, e.g. in this scenario we have the default
        /// array size of 4, so setting index of 4 will result in accessing an index which is out of range.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void IndexSetOutOfRange() {
            ArrayListCollection<int> actual = new ArrayListCollection<int>();

            actual[4] = 5;
        }

        /// <summary>
        /// Test to see that IList.IsReadonly returns false.
        /// </summary>
        [TestMethod]
        public void IListIsReadonlyTest() {
            ArrayListCollection<int> acl = new ArrayListCollection<int>();
            IList actual = acl;

            Assert.IsFalse(actual.IsReadOnly);
        }

        /// <summary>
        /// Test to see that IList.IsFixedSize returns false.
        /// </summary>
        [TestMethod]
        public void IListIsFixedSizeTest() {
            ArrayListCollection<int> acl = new ArrayListCollection<int>();
            IList actual = acl;

            Assert.IsFalse(actual.IsFixedSize);
        }

        /// <summary>
        /// Test to see that calling ICollection(Of T).Add results in the expected behaviour.
        /// </summary>
        [TestMethod]
        public void ICollectionGenericAddTest() {
            ArrayListCollection<int> alc = new ArrayListCollection<int>();
            ICollection<int> actual = alc;

            actual.Add(10);
            actual.Add(20);

            Assert.AreEqual<int>(2, actual.Count);
        }

        /// <summary>
        /// Test to see that calling IList.Add on a value type collection results in the expected exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void IListAddValueTypeTest() {
            ArrayListCollection<int> alc = new ArrayListCollection<int>();
            IList actual = alc;

            Assert.AreEqual<int>(0, actual.Add(10));
            Assert.AreEqual<int>(1, actual.Add(20));
            Assert.AreEqual<int>(2, actual.Count);
        }

        /// <summary>
        /// Test to see that adding a reference type using IList.Add that is the same as T is accepted and results in the expected
        /// behaviour.
        /// </summary>
        [TestMethod]
        public void IListAddTest() {
            ArrayListCollection<string> alc = new ArrayListCollection<string>();
            IList actual = alc;

            Assert.AreEqual<int>(0, actual.Add("London"));
            Assert.AreEqual<int>(1, actual.Add("Paris"));
            Assert.AreEqual<int>(2, actual.Count);
        }

        /// <summary>
        /// Test to see that clear defaults every value in the array list (null for reference types, 0 for value types)
        /// and resets count to 0. 
        /// </summary>
        [TestMethod]
        public void ClearTest() {
            ArrayListCollection<int> alc = new ArrayListCollection<int>();

            alc.Add(10);
            alc.Add(20);
            alc.Add(30);
            alc.Add(40);
            alc.Clear();

            Assert.AreEqual<int>(0, alc.Count);
            Assert.AreEqual<int>(4, alc.Capacity);
        }

        /// <summary>
        /// Test to see calling insert specifying a index which has already been allocated results inteh expected
        /// behaviour, i.e. count is not incremented and the existing value at the index is overwritten.
        /// </summary>
        [TestMethod]
        public void InsertExisistingIndexTakenTest() {
            ArrayListCollection<int> actual = new ArrayListCollection<int>();

            actual.Add(10);
            actual.Add(20);
            actual.Add(30);
            actual.Insert(2, 40);

            Assert.AreEqual<int>(3, actual.Count);
            Assert.AreEqual<int>(40, actual[2]);
        }

        /// <summary>
        /// Test to see that Add honours a previous Insert.
        /// </summary>
        [TestMethod]
        public void AddHonoursInsertTest() {
            ArrayListCollection<int> actual = new ArrayListCollection<int>();

            actual.Insert(2, 30);
            actual.Add(10);
            actual.Add(20);
            actual.Add(40);
            actual.Add(50);

            Assert.AreEqual<int>(30, actual[2]);
            Assert.AreEqual<int>(5, actual.Count);
        }

        /// <summary>
        /// Test to see that when inserting and specifying an out of range index results in the correct exception
        /// being raised.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void InsertOutOfRangeIndexTest() {
            ArrayListCollection<int> actual = new ArrayListCollection<int>();

            actual.Insert(7, 30);
        }

        /// <summary>
        /// Test to make sure that RemoveAt leaves the array in the correct state.
        /// </summary>
        [TestMethod]
        public void RemoveAtTest() {
            ArrayListCollection<int> actual = new ArrayListCollection<int>();

            actual.Add(10);
            actual.Add(20);
            actual.Add(30);
            actual.Add(40);
            actual.RemoveAt(2);

            Assert.AreEqual<int>(10, actual[0]);
            Assert.AreEqual<int>(20, actual[1]);
            Assert.AreEqual<int>(40, actual[2]);
            Assert.AreEqual<int>(0, actual[3]);
        }

        /// <summary>
        /// Test to make sure that RemoveAt leaves the array in the correct state.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void RemoveAtOutOfRangeIndexTest() {
            ArrayListCollection<int> actual = new ArrayListCollection<int>();

            actual.Add(10);
            actual.Add(20);
            actual.Add(30);
            actual.Add(40);
            actual.RemoveAt(-2);
        }

        /// <summary>
        /// Test to make sure that Remove leaves the array in the correct state.
        /// </summary>
        [TestMethod]
        public void RemoveTest() {
            ArrayListCollection<int> actual = new ArrayListCollection<int>();

            actual.Add(10);
            actual.Add(20);
            actual.Add(30);
            actual.Add(40);
            actual.Add(50);
            actual.Add(60);

            Assert.IsFalse(actual.Remove(90));
            Assert.IsTrue(actual.Remove(30));
            Assert.AreEqual<int>(40, actual[2]);
        }

        /// <summary>
        /// Test to see that IList.Contains returns the correct value.
        /// </summary>
        [TestMethod]
        public void IListContainsTest() {
            ArrayListCollection<string> alc = new ArrayListCollection<string>();
            IList actual = alc;

            actual.Add("London");
            actual.Add("Paris");
            actual.Add("Montreal");

            Assert.IsTrue(actual.Contains("Paris"));
            Assert.IsFalse(actual.Contains("Berlin"));
        }

        /// <summary>
        /// Test to see that using a non-compatiable type results in expected exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void IListContainsNonCompatTypeTest() {
            ArrayListCollection<int> alc = new ArrayListCollection<int>();
            IList actual = alc;

            actual.Contains(10);
        }

        /// <summary>
        /// Test to see that the correct index is passed back when calling IndexOf.
        /// </summary>
        [TestMethod]
        public void IListIndexOfTest() {
            ArrayListCollection<string> alc = new ArrayListCollection<string>();
            IList actual = alc;

            actual.Add("London");
            actual.Add("Paris");
            actual.Add("Berlin");

            Assert.AreEqual<int>(2, actual.IndexOf("Berlin"));
            Assert.AreEqual<int>(-1, actual.IndexOf("Prague"));
        }

        /// <summary>
        /// Test to see that the correct exception is raied when using a non compatible type.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void IListIndexOfUnsupportedTypeTest() {
            ArrayListCollection<int> alc = new ArrayListCollection<int>();
            IList actual = alc;

            actual.IndexOf(30);
        }

        /// <summary>
        /// Test to see that calling IList.Insert results in the expected behaviour.
        /// </summary>
        [TestMethod]
        public void IListInsertTest() {
            ArrayListCollection<string> alc = new ArrayListCollection<string>();
            IList actual = alc;

            actual.Insert(2, "London");

            Assert.AreEqual<string>("London", alc[2]);
        }

        /// <summary>
        /// Test to see that IList.Insert raises the correct exception when inserting an unsupoorted type.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void IListInsertUnsupportedTypeTest() {
            ArrayListCollection<int> alc = new ArrayListCollection<int>();
            IList actual = alc;

            actual.Insert(2, 5);
        }

        /// <summary>
        /// Test to see that IList.RemoveAt results in the expected object state.
        /// </summary>
        [TestMethod]
        public void IListRemoveAtTest() {
            ArrayListCollection<string> alc = new ArrayListCollection<string>();
            IList actual = alc;

            actual.Add("London");
            actual.Add("Paris");
            actual.RemoveAt(0);

            Assert.AreEqual<string>("Paris", alc[0]);
            Assert.AreEqual<int>(1, actual.Count);
        }

        /// <summary>
        /// Test to see that calling IList.Remove results in the expected behaviour.
        /// </summary>
        [TestMethod]
        public void IListRemoveTest() {
            ArrayListCollection<string> alc = new ArrayListCollection<string>();
            IList actual = alc;

            actual.Add("Paris");
            actual.Add("Berlin");
            actual.Add("London");
            actual.Remove("Berlin");

            Assert.AreEqual<string>("London", alc[1]);
            Assert.AreEqual<int>(2, actual.Count);
        }

        /// <summary>
        /// Test to see that the correct exception is raised when remove is called with an unsupported type.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void IListRemoveNotSupportedTypeTest() {
            ArrayListCollection<int> alc = new ArrayListCollection<int>();
            IList actual = alc;

            actual.Remove(20);
        }

        /// <summary>
        /// Test to see that setting by index results in the correct behaviour.
        /// </summary>
        [TestMethod]
        public void IListByIndexTest() {
            ArrayListCollection<string> alc = new ArrayListCollection<string>();
            IList actual = alc;

            actual.Add("London");
            actual.Add("Paris");
            actual.Add("Berlin");
            actual[3] = "Venice";
            actual[2] = "Prague";

            Assert.AreEqual<int>(4, actual.Count);
            Assert.AreEqual<string>("Prague", actual[2] as string);
            Assert.AreEqual<string>("Venice", actual[3] as string);
        }

        /// <summary>
        /// Test to see that setting by index when the value is a type that is not supported results in the
        /// expected exception being raised.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void IListByIndexNotSupportedTypeTest() {
            ArrayListCollection<string> alc = new ArrayListCollection<string>();
            IList actual = alc;

            actual[0] = new Hashtable();
        }

        /// <summary>
        /// Test to see that IsSynchronized returns false.
        /// </summary>
        [TestMethod]
        public void IsSynchronizedTest() {
            ArrayListCollection<int> alc = new ArrayListCollection<int>();
            ICollection actual = alc;

            Assert.IsFalse(actual.IsSynchronized);
        }

        /// <summary>
        /// Test to see that SyncRoot returns a non null object.
        /// </summary>
        [TestMethod]
        public void SyncRootTest() {
            ArrayListCollection<int> alc = new ArrayListCollection<int>();
            ICollection actual = alc;

            Assert.IsNotNull(actual.SyncRoot);
        }

    }

}
