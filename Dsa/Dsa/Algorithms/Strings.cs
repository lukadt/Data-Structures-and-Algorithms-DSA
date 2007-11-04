using System;
using System.Globalization;
using System.Text;

namespace Dsa.Algorithms
{

    /// <summary>
    /// String algorithms.
    /// </summary>
    public static class Strings
    {

        /// <summary>
        /// Reverses the characters of a <see cref="string"/>.
        /// </summary>
        /// <param name="value">The <see cref="string"/> to reverse the characters of.</param>
        /// <returns>A reversed <see cref="string"/> of the parameter.</returns>
        /// <exception cref="ArgumentNullException"><strong>value</strong> is <strong>null</strong>.</exception>
        public static string Reverse(this string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }
            if (value.Length < 2) return value; // array only has a size of 1 so just return the original array
            char[] resultingString = new char[value.Length]; // create a buffer array to store reversed chars in
            for (int i = value.Length - 1, j = 0; i >= 0; i--, j++)
            {
                resultingString[j] = value[i]; // populate buffer array
            }
            return new string(resultingString);
        }

        /// <summary>
        /// Returns the index of the first character in the match <see cref="string"/> that matches any 
        /// character in the word <see cref="string"/>.
        /// </summary>
        /// <remarks>Case sensitive, whitespace is ignored.</remarks>
        /// <param name="word">Word to run the any match against.</param>
        /// <param name="match">The <see cref="string"/> of characters to match against the word.</param>
        /// <returns>A non-negative <see cref="Int32"/> index that represents the location of the first character in the match <see cref="string"/> that was 
        /// also in the word <see cref="string"/>; otherwise -1 if no characters in the match <see cref="string"/> matched any of the characters in the 
        /// word <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">
        /// <strong>word</strong> is <strong>null</strong>.<br />
        /// -or-<br/>
        /// <strong>match</strong> is <strong>null</strong>.
        /// </exception>
        public static int Any(this string word, string match)
        {
            if (word == null)
            {
                throw new ArgumentNullException("word");
            }
            else if (match == null)
            {
                throw new ArgumentNullException("match");
            }
            for (int i = 0; i < word.Length; i++)
            {
                while (char.IsWhiteSpace(word[i])) i++; // skip the whitespace in the word string
                for (int j = 0; j < match.Length; j++)
                {
                    while (char.IsWhiteSpace(match[j])) j++; // skip whitespace in teh match string
                    if (match[j] == word[i]) return j; // we have a match, return the index of the match string
                }
            }
            return -1;
        }

        /// <summary>
        /// Detects whether or not the input string is a palindrome.
        /// </summary>
        /// <remarks>
        /// Case, whitespace, punctuation and symbols are ignored.
        /// </remarks>
        /// <param name="word"><see cref="string"/> that you want to test is a palindrome or not.</param>
        /// <returns>True if the string is a palindrome; otherwise false.</returns>
        /// <exception cref="ArgumentNullException"><strong>word</strong> is <strong>null</strong>.</exception>
        public static bool IsPalindrome(this string word)
        {
            if (word == null)
            {
                throw new ArgumentNullException("word");
            }
            word = word.Strip().ToUpper(CultureInfo.InvariantCulture); // palindromes are case insensitive
            int begin = 0;
            int end = word.Length - 1;
            // march in from either end of the string checking for equality and making sure that the begin pointer has a value less than the end pointer
            while (word[begin] == word[end] && begin < end) 
            {
                begin++;
                end--;
            }
            return word[begin] == word[end];
        }

        /// <summary>
        /// Takes a <see cref="string"/> and strips it of whitespace, punctuation and symbols returning the resulting stripped <see cref="string"/>.
        /// </summary>
        /// <param name="value"><see cref="string"/> to strip.</param>
        /// <returns>The stripped version of the <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException"><strong>value</strong> is <strong>null</strong>.</exception>
        public static string Strip(this string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < value.Length; i++)
            {
                if (!char.IsWhiteSpace(value[i]) && !char.IsPunctuation(value[i]) && !char.IsSymbol(value[i]))
                {
                    sb.Append(value[i]);
                }
            }
            return sb.ToString();
        }

        /// <summary>
        /// Counts the number of words in a <see cref="string"/>.
        /// </summary>
        /// <param name="value">The <see cref="string"/> to count the words of.</param>
        /// <returns>An <see cref="Int32"/> indicating the number of words in the <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException"><strong>value</strong> is <strong>null</strong>.</exception>
        public static int WordCount(this string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }
            bool inWord = true; // flag used to monitor whether we are currently in a word
            int count = 0; // keeps track of the number of words in the string
            int index = 0;
            while (char.IsWhiteSpace(value[index]) && index < value.Length - 1) index++; // skip all of the initial whitespace in the string
            if (index == value.Length - 1 && char.IsWhiteSpace(value[index])) return 0; // the string was pure whitepace
            for (; index < value.Length; index++)
            {
                if (char.IsWhiteSpace(value[index]))
                {
                    while (char.IsWhiteSpace(value[index]) && index < value.Length - 1) index++; // skip all consecutive whitespace
                    inWord = false; // as we are hitting whitespace we are not in a word
                    count++; // I assume that words are delimitd by whitespace, thus count should be incremented.
                }
                else
                {
                    inWord = true;
                }
            }
            if (inWord) count++; // the last word may of not been followed by whitespace, in that case increment count.
            return count;
        }

    }

}
