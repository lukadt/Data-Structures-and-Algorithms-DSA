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

        /// <summary>
        /// Test to see that the correct index is returned when calling Any.
        /// </summary>
        [TestMethod]
        public void AnyMatchingCharTest() {
            string s = "test";

            Assert.AreEqual<int>(2, s.Any("prtest"));
        }

        /// <summary>
        /// Test to see that the correct value is returned by any when the match string chars 
        /// have no match with any of that in the word.
        /// </summary>
        [TestMethod]
        public void AnyNoMatchingCharTest() {
            string s = "test";

            Assert.AreEqual<int>(-1, s.Any("bbc"));
        }

        /// <summary>
        /// Test to see that the correct exception is raised when the word is null.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AnyWordNullTest() {
            string s = null;

            s.Any("test");
        }

        /// <summary>
        /// Test to see that the correct exception is raised when the match is null.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AnyMatchNullException() {
            string s = "test";

            s.Any(null);
        }

        /// <summary>
        /// Test to see that whitespace is ignored in both the word and match strings.
        /// </summary>
        [TestMethod]
        public void AnyWhiteSpaceTest() {
            string first = "   test";
            string second = "Gra as asdf  asdf";

            Assert.AreEqual<int>(4, first.Any("   pters"));
            Assert.AreEqual<int>(13, second.Any("T kf   q w   r fg"));
        }

        /// <summary>
        /// Test to see that a single word that is a palindrome returns true.
        /// </summary>
        [TestMethod]
        public void IsPalindromeSingleWordTest() {
            string actual = "mum";

            Assert.IsTrue(actual.IsPalindrome());
        }

        /// <summary>
        /// Test to see that the IsPalindrome method ignores case when testing for a palindrome.
        /// </summary>
        [TestMethod]
        public void IsPalindromeCaseInsensitiveTest() {
            string actual = "Madam";

            Assert.IsTrue(actual.IsPalindrome());
        }

        /// <summary>
        /// Test to see that a string comprising of a single char is a palindrome.
        /// </summary>
        [TestMethod]
        public void IsPalindromeSingleCharTest() {
            string actual = "m";

            Assert.IsTrue(actual.IsPalindrome());
        }

        /// <summary>
        /// Test to see that calling IsPalindrome with a null string results in the expected exception being thrown.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IsPalindromeNullStringTest() {
            string actual = null;

            actual.IsPalindrome();
        }

    }

}
