using System;
using Dsa.Algorithms;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dsa.Test {

    /// <summary>
    /// Tests for the Strings algorithms.
    /// </summary>
    [TestClass]
    public class StringsTest {

        /// <summary>
        /// Test to see that the resulting string returned from Reverse is that expected.
        /// </summary>
        [TestMethod]
        public void ReverseTest() {
            string s = "Granville";
            string actual = s.Reverse();

            Assert.AreEqual<string>("ellivnarG", actual);
        }

        /// <summary>
        /// Test to see that an empty string is returned when passing in an empty string.
        /// </summary>
        [TestMethod]
        public void ReverseEmptyStringTest() {
            string s = "";

            Assert.AreEqual<string>("", s.Reverse());
        }

        /// <summary>
        /// Test to see that the correct string is returned from a call to Reverse on a string of a single char.
        /// </summary>
        [TestMethod]
        public void ReverseStringOfLength1Test() {
            string s = "t";

            Assert.AreEqual<string>("t", s.Reverse());
        }

        /// <summary>
        /// Test to see that calling Reverse on a null string results in the corrext exception being raised.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ReverseNullStringTest() {
            string s = null;
            string actual = s.Reverse();
        }

    }

}
