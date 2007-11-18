using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dsa.Utility;
using System.Collections.Generic;

namespace Dsa.Test.Utility
{

    /// <summary>
    /// Tests for the compare methods.
    /// </summary>
    [TestClass]
    public class CompareTest
    {

        /// <summary>
        /// Check to see that IsLessThan method returns the correct value.
        /// </summary>
        [TestMethod]
        public void IsLessThanTest()
        {
            IComparer<int> comparer = Comparer<int>.Default;

            Assert.IsTrue(Compare.IsLessThan(3, 4, comparer));
            Assert.IsFalse(Compare.IsLessThan(4, 3, comparer));
        }

        /// <summary>
        /// Check to see that IsGreaterThan methods returns the correct value.
        /// </summary>
        [TestMethod]
        public void IsGreaterThanTest()
        {
            IComparer<int> comparer = Comparer<int>.Default;

            Assert.IsTrue(Compare.IsGreaterThan(4, 3, comparer));
            Assert.IsFalse(Compare.IsGreaterThan(3, 4, comparer));
        }

        /// <summary>
        /// Check to see that AreEqual method returns the correct value.
        /// </summary>
        [TestMethod]
        public void AreEqualTest()
        {
            IComparer<int> comparer = Comparer<int>.Default;

            Assert.IsTrue(Compare.AreEqual(3, 3, comparer));
            Assert.IsFalse(Compare.AreEqual(2, 3, comparer));
        }

    }

}
