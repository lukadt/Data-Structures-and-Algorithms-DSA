namespace Dsa.Algorithms {

    /// <summary>
    /// Number algorithms.
    /// </summary>
    public static class Numbers {

        /// <summary>
        /// Computes the fibonnaci number of an integer.
        /// </summary>
        /// <param name="number">The number to compute the fibonnacci number for.</param>
        /// <returns>The fibonnacci number.</returns>
        public static int Fibonacci(int number) {
            if (number < 2) return 1;
            return Fibonacci(number - 1) + Fibonacci(number - 2);
        }

        /// <summary>
        /// Computes factorial of a givne integer.
        /// </summary>
        /// <param name="number">The number to compute the factorial of.</param>
        public static int Factorial(int number) {
            if (number == 1) return 1;
            return number * Factorial(number - 1);
        }

        /// <summary>
        /// Computes the power of an integer with a given exponent.
        /// </summary>
        /// <param name="baseNumber">The base number.</param>
        /// <param name="exponent">The exponent.</param>
        /// <returns>The value of the base raised to the exponent.</returns>
        public static int Power(int baseNumber, int exponent) {
            if (exponent == 0) return 1;
            return baseNumber * Power(baseNumber, exponent - 1);
        }

        /// <summary>
        /// Computes the greatest common denominator of two integers.
        /// This is an implementation of Euclid's algorithm.
        /// </summary>
        /// <param name="first">First integer.</param>
        /// <param name="second">Second integer.</param>
        /// <returns>The greatest common denominator of the two integers provided.</returns>
        public static int Gcd(int first, int second) {
            if (second == 0) return first;
            return Gcd(second, first % second);
        }

    }

}
