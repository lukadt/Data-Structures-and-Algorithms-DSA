using System;
using System.Globalization;
using System.Text;

namespace Dsa.Algorithms {
    
    /// <summary>
    /// String algorithms.
    /// </summary>
    public static class Strings {

        /// <summary>
        /// Reverses the characters of a string.
        /// </summary>
        /// <param name="s">String to reverse characters of.</param>
        /// <returns>A reversed string of the parameter.</returns>
        public static string Reverse(this string word) {
            if (word == null) {
                throw new ArgumentNullException("word");
            }
            if (word.Length < 2) return word;
            char[] resultingString = new char[word.Length];
            for (int i = word.Length - 1, j = 0; i >= 0; i--, j++) {
                resultingString[j] = word[i];
            }
            return new string(resultingString);
        }

        /// <summary>
        /// Returns the index of the first character in the match string that matches any 
        /// character in the word string.  Case sensitive, whitespace is ignored.
        /// </summary>
        /// <param name="word">Word to run the any match against.</param>
        /// <param name="match">The string of characters to match against the word.</param>
        /// <returns>A non-negative Int32 index that represents the location of the first character in the match string that was also in the word string; 
        /// otherwise -1 if no characters in the match string matched any of the characters in the word string.</returns>
        public static int Any(this string word, string match) {
            if (word == null) {
                throw new ArgumentNullException("word");
            }
            else if (match == null) {
                throw new ArgumentNullException("match");
            }
            for (int i = 0; i < word.Length; i++) {
                while (char.IsWhiteSpace(word[i])) i++;
                for (int j = 0; j < match.Length; j++) {
                    while (char.IsWhiteSpace(match[j])) j++;
                    if (match[j] == word[i]) return j;
                }
            }
            return -1;
        }

        /// <summary>
        /// Detects whether or not the input string is a palindrome.
        /// </summary>
        /// <param name="word">String that you want to test is a palindrome or not.</param>
        /// <returns>True if the string is a palindrome; otherwise false.</returns>
        public static bool IsPalindrome(this string word) {
            if (word == null) {
                throw new ArgumentNullException("word");
            }
            word = word.Strip().ToLower(CultureInfo.InvariantCulture); // palindromes are case insensitive
            int begin = 0;
            int end = word.Length - 1;
            while (word[begin] == word[end] && begin < end) {
                begin++;
                end--;
            }
            return word[begin] == word[end];
        }

        /// <summary>
        /// Takes a string and strips it of whitespace, punctuation and symbols returning the resulting stripped string.
        /// </summary>
        /// <param name="str">String to strip.</param>
        /// <returns>The stripped version of the string.</returns>
        public static string Strip(this string str) {
            if (str == null) {
                throw new ArgumentNullException("str");
            }
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < str.Length; i++) {
                if (!char.IsWhiteSpace(str[i]) && !char.IsPunctuation(str[i]) && !char.IsSymbol(str[i])) {
                    sb.Append(str[i]);
                }
            }
            return sb.ToString();
        }

    }

}
