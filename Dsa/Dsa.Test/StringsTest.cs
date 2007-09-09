using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dsa.Algorithms;

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

    }

}
