namespace Dsa.Algorithms {

    /// <summary>
    /// Number algorithms.
    /// </summary>
    public static class Numbers {

        /// <summary>
        /// Computes the fibonnaci number of an integer.
        /// </summary>
        /// <param name="n">Int to compute fibonnacci number for.</param>
        /// <returns>The fibonnacci number.</returns>
        public static int Fibonacci(int n) {
            if (n < 2) return 1;
            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }

        /// <summary>
        /// Computes factorial of a givne integer.
        /// </summary>
        /// <param name="n">The integer to compute the factorial of.</param>
        public static int Factorial(int n) {
            if (n == 1) return 1;
            return n * Factorial(n - 1);
        }

    }

}
