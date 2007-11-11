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
            // if the string only has a length of 1 we can just return the original string
            if (value.Length < 2)
            {
                return value; 
            }
            // create a buffer array to store reversed chars in
            char[] resultingString = new char[value.Length]; 
            // loop through the string placing each char in its new location within the resultingString buffer
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
            // loop through each character in the word string
            for (int i = 0; i < word.Length; i++)
            {
                // skip any whitespace in the word string
                while (char.IsWhiteSpace(word[i]))
                {
                    i++;
                }
                for (int j = 0; j < match.Length; j++)
                {
                    // skip any whitespace in the match string
                    while (char.IsWhiteSpace(match[j]))
                    {
                        j++;
                    }
                    // check to see if we have a match, if we do return the index of the matching char in the match string
                    if (match[j] == word[i])
                    {
                        return j;
                    }
                }
            }
            return -1; // no match
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
            // palindromes are case insensitive so convert all chars in word to lowercase
            word = word.Strip().ToUpper(CultureInfo.InvariantCulture); 
            // set beginning and end index pointers
            int begin = 0;
            int end = word.Length - 1;
            // march in from either end of the string checking for equality and making sure that the begin pointer has a value less than the end pointer
            while (word[begin] == word[end] && begin < end) 
            {
                begin++;
                end--;
            }
            // if the two chars we are pointing two are equal we have a palindrome
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
            StringBuilder sb = new StringBuilder(); // will hold the stripped string
            for (int i = 0; i < value.Length; i++)
            {
                /* check the char at index i of value to see that it is not whitespace, punctuation or a symbol - if all 3 properties are
                satisfied then we can add the char at the current index to sb. */
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
            // flag used to monitor whether we are currently in a word
            bool inWord = true; 
            // keep track of the number of words encountered within value
            int count = 0; 
            int index = 0;
            // skip any initial whitespace in value
            while (char.IsWhiteSpace(value[index]) && index < value.Length - 1)
            {
                index++;
            }
            // check to see if value was only whitespace, if it was then there are 0 words
            if (index == value.Length - 1 && char.IsWhiteSpace(value[index]))
            {
                return 0;
            }
            for (; index < value.Length; index++)
            {
                if (char.IsWhiteSpace(value[index]))
                {
                    // skip all consecutive whitespace
                    while (char.IsWhiteSpace(value[index]) && index < value.Length - 1)
                    {
                        index++;
                    }
                    inWord = false; // as we are hitting whitespace we are not in a word
                    count++; // I assume that words are delimitd by whitespace, thus count should be incremented
                }
                else
                {
                    inWord = true; 
                }
            }
            // the last word may of not been followed by whitespace, in that case increment count
            if (inWord)
            {
                count++; 
            }
            return count;
        }

    }

}
