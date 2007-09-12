using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dsa.DataStructures;

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

    }

}
