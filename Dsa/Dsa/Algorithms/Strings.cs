﻿using System;

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
            if (word.Length < 2) { 
                return word;
            }
            char[] resultingString = new char[word.Length];
            for (int i = word.Length - 1, j = 0; i >= 0; i--, j++) {
                resultingString[j] = word[i];
            }
            return new string(resultingString);
        }

    }

}
