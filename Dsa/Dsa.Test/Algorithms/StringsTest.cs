using System;
using Dsa.Algorithms;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dsa.Test 
{

    /// <summary>
    /// Tests for the Strings algorithms.
    /// </summary>
    [TestClass]
    public class StringsTest 
    {

        /// <summary>
        /// Check to see that the resulting string returned from Reverse is that expected.
        /// </summary>
        [TestMethod]
        public void ReverseTest() 
        {
            string s = "Granville";
            string actual = s.Reverse();

            Assert.AreEqual("ellivnarG", actual);
        }

        /// <summary>
        /// Check to see that an empty string is returned when passing in an empty string.
        /// </summary>
        [TestMethod]
        public void ReverseEmptyStringTest() 
        {
            string s = "";

            Assert.AreEqual("", s.Reverse());
        }

        /// <summary>
        /// Check to see that the correct string is returned from a call to Reverse on a string of a single char.
        /// </summary>
        [TestMethod]
        public void ReverseStringOfLength1Test() 
        {
            string s = "t";

            Assert.AreEqual("t", s.Reverse());
        }

        /// <summary>
        /// Check to see that calling Reverse on a null string results in the corrext exception being raised.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ReverseNullStringTest() 
        {
            string s = null;
            string actual = s.Reverse();
        }

        /// <summary>
        /// Check to see that the correct index is returned when calling Any.
        /// </summary>
        [TestMethod]
        public void AnyMatchingCharTest() 
        {
            string s = "test";

            Assert.AreEqual(2, s.Any("prtest"));
        }

        /// <summary>
        /// Check to see that the correct value is returned by any when the match string chars 
        /// have no match with any of that in the word.
        /// </summary>
        [TestMethod]
        public void AnyNoMatchingCharTest() 
        {
            string s = "test";

            Assert.AreEqual(-1, s.Any("bbc"));
        }

        /// <summary>
        /// Check to see that the correct exception is raised when the word is null.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AnyWordNullTest() 
        {
            string s = null;

            s.Any("test");
        }

        /// <summary>
        /// Check to see that the correct exception is raised when the match is null.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AnyMatchNullException() 
        {
            string s = "test";

            s.Any(null);
        }

        /// <summary>
        /// Test to see that whitespace is ignored in both the word and match strings.
        /// </summary>
        [TestMethod]
        public void AnyWhiteSpaceTest() 
        {
            string first = "   test";
            string second = "Gra as asdf  asdf";

            Assert.AreEqual(4, first.Any("   pters"));
            Assert.AreEqual(13, second.Any("T kf   q w   r fg"));
        }

        /// <summary>
        /// Check to see that a single word that is a palindrome returns true.
        /// </summary>
        [TestMethod]
        public void IsPalindromeSingleWordTest() 
        {
            string actual = "mum";

            Assert.IsTrue(actual.IsPalindrome());
        }

        /// <summary>
        /// Check to see that the IsPalindrome method ignores case when testing for a palindrome.
        /// </summary>
        [TestMethod]
        public void IsPalindromeCaseInsensitiveTest() 
        {
            string actual = "Madam";

            Assert.IsTrue(actual.IsPalindrome());
        }

        /// <summary>
        /// Check to see that a string comprising of a single char is a palindrome.
        /// </summary>
        [TestMethod]
        public void IsPalindromeSingleCharTest() 
        {
            string actual = "m";

            Assert.IsTrue(actual.IsPalindrome());
        }

        /// <summary>
        /// Check to see that calling IsPalindrome with a null string results in the expected exception being thrown.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IsPalindromeNullStringTest() 
        {
            string actual = null;

            actual.IsPalindrome();
        }

        /// <summary>
        /// Check to see that a string that has whitespace and punctuation is ignored.
        /// </summary>
        [TestMethod]
        public void IsPalindromePuncAndWhitespaceIgnoredTest() 
        {
            string actual = "Are we not drawn onward, we few, drawn onward to new era?";

            Assert.IsTrue(actual.IsPalindrome());
        }

        /// <summary>
        /// Check to see that calling strip results in the expected string.
        /// </summary>
        [TestMethod]
        public void StripTest() 
        {
            string actual = "asdf!!?*    p $$£";

            Assert.AreEqual("asdfp", actual.Strip());
        }

        /// <summary>
        /// Check to see that calling strip with a null string results in the expected exception being thrown.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StripNullStringTest() 
        {
            string actual = null;

            actual.Strip();
        }

        /// <summary>
        /// Check to see that WordCount returns the correct value.
        /// </summary>
        [TestMethod]
        public void WordCountTest() 
        {
            string actual = "The boat is in";

            Assert.AreEqual(4, actual.WordCount());
        }

        /// <summary>
        /// Check to see that whitespace is ignored when counting words.
        /// </summary>
        [TestMethod]
        public void WordCountWhitespaceTest() 
        {
            string actual = "   I ate pie    ";

            Assert.AreEqual(3, actual.WordCount());
        }

        /// <summary>
        /// Check to make sure that a string with nothing but whitespace returns the correct value.
        /// </summary>
        [TestMethod]
        public void WordCountPureWhiteSpace() 
        {
            string actual = "      ";

            Assert.AreEqual(0, actual.WordCount());
        }

        /// <summary>
        /// Check to see that a null string raises the correct exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WordCountNullArgTest() 
        {
            string actual = null;

            actual.WordCount();
        }

        /// <summary>
        /// Check to see that the words of the string are reversed correctly.
        /// </summary>
        [TestMethod]
        public void ReverseWordsTest()
        {
            Assert.AreEqual("day dad my", "my dad day".ReverseWords());
            Assert.AreEqual("belly beer a home went then and pop ate I", "I ate pop and then went home a beer belly".ReverseWords());
        }

        /// <summary>
        /// Check to see that any amount of whitespace doesn't affect the reverse words algorithm.  The whitespace is ignored.
        /// </summary>
        [TestMethod]
        public void ReverseWordsWhiteSpaceTest()
        {
            Assert.AreEqual("belly beer a home went then and pop ate I", "    I ate         pop and then  went home a   beer belly    ".ReverseWords());
        }

        /// <summary>
        /// Check to see that the correct exception is thrown when calling reverse words on a null string.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ReverseWordsStringNullTest()
        {
            string s = null;

            s.ReverseWords();
        }

    }

}
