using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dsa.DataStructures;
using System;
using System.Collections;

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
            actual[2] = 25;

            Assert.AreEqual<int>(25, actual[2]);
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

    }

}
