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
        public static string Reverse(this string s) {
            if (s.Length < 2) { 
                return s;
            }
            char[] resultingString = new char[s.Length];
            for (int i = s.Length - 1, j = 0; i >= 0; i--, j++) {
                resultingString[j] = s[i];
            }
            return new string(resultingString);
        }

    }

}
