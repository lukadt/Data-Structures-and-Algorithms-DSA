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
        /// Reverses the characters of a string.
        /// </summary>
        /// <param name="value">The string to reverse the characters of.</param>
        /// <returns>A reversed string of the parameter.</returns>
        public static string Reverse(this string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }
            if (value.Length < 2) return value;
            char[] resultingString = new char[value.Length];
            for (int i = value.Length - 1, j = 0; i >= 0; i--, j++)
            {
                resultingString[j] = value[i];
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
                while (char.IsWhiteSpace(word[i])) i++;
                for (int j = 0; j < match.Length; j++)
                {
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
        public static bool IsPalindrome(this string word)
        {
            if (word == null)
            {
                throw new ArgumentNullException("word");
            }
            word = word.Strip().ToUpper(CultureInfo.InvariantCulture); // palindromes are case insensitive
            int begin = 0;
            int end = word.Length - 1;
            while (word[begin] == word[end] && begin < end)
            {
                begin++;
                end--;
            }
            return word[begin] == word[end];
        }

        /// <summary>
        /// Takes a string and strips it of whitespace, punctuation and symbols returning the resulting stripped string.
        /// </summary>
        /// <param name="value">String to strip.</param>
        /// <returns>The stripped version of the string.</returns>
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
        /// Counts the number of words in a string.
        /// </summary>
        /// <param name="value">The string to count the words of.</param>
        /// <returns>An Int32 indicating the number of words in the string.</returns>
        public static int WordCount(this string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }
            bool inWord = true;
            int count = 0;
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
