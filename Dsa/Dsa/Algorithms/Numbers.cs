namespace Dsa.Algorithms
{

    /// <summary>
    /// Number algorithms.
    /// </summary>
    public static class Numbers
    {

        /// <summary>
        /// Computes the fibonnaci number of an <see cref="System.Int32"/>.
        /// </summary>
        /// <param name="number">The <see cref="System.Int32"/> to compute the fibonnacci number for.</param>
        /// <returns>An <see cref="System.Int32"/> representing the fibonacci number.</returns>
        public static int Fibonacci(int number)
        {
            if (number < 2) return 1;
            return Fibonacci(number - 1) + Fibonacci(number - 2);
        }

        /// <summary>
        /// Computes the factorial of an <see cref="System.Int32"/>.
        /// </summary>
        /// <param name="number"><see cref="System.Int32"/> to compute the factorial of.</param>
        /// <returns>The factorial of the specified <see cref="System.Int32"/>.</returns>
        public static int Factorial(int number)
        {
            if (number == 1) return 1;
            return number * Factorial(number - 1);
        }

        /// <summary>
        /// Computes the power of an <see cref="System.Int32"/> to a given exponent.
        /// </summary>
        /// <param name="baseNumber">The base number.</param>
        /// <param name="exponent">The exponent.</param>
        /// <returns>The value of the base raised to the exponent.</returns>
        public static int Power(int baseNumber, int exponent)
        {
            if (exponent == 0) return 1;
            return baseNumber * Power(baseNumber, exponent - 1);
        }

        /// <summary>
        /// Computes the greatest common denominator of two <see cref="System.Int32"/>'s.
        /// This is an implementation of Euclid's algorithm.
        /// </summary>
        /// <param name="first">First <see cref="System.Int32"/>.</param>
        /// <param name="second">Second <see cref="System.Int32"/>.</param>
        /// <returns>The greatest common denominator of the two <see cref="System.Int32"/>'s provided.</returns>
        public static int Gcd(int first, int second)
        {
            if (second == 0) return first;
            return Gcd(second, first % second);
        }

    }

}
