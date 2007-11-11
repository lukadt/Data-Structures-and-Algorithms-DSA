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
            // factorial of 1 and 2 is 1
            if (number < 2)
            {
                return 1; 
            }
            // add the two sub trees of the factorial calls to get the factorial of n
            return Fibonacci(number - 1) + Fibonacci(number - 2); 
        }

        /// <summary>
        /// Computes the factorial of an <see cref="System.Int32"/>.
        /// </summary>
        /// <param name="number"><see cref="System.Int32"/> to compute the factorial of.</param>
        /// <returns>The factorial of the specified <see cref="System.Int32"/>.</returns>
        public static int Factorial(int number)
        {
            // factorial of 1 is 1
            if (number == 1)
            {
                return 1; 
            }
            // to find the factorial of n simply multipy it by factorial of n..1
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
            // the law of indicies states that a base with the exponent of 0 is 1
            if (exponent == 0)
            {
                return 1;
            }
            return baseNumber * Power(baseNumber, exponent - 1);
        }

        /// <summary>
        /// Computes the greatest common denominator of two <see cref="System.Int32"/>'s.
        /// This is an implementation of Euclid's algorithm.
        /// </summary>
        /// <param name="first">First <see cref="System.Int32"/>.</param>
        /// <param name="second">Second <see cref="System.Int32"/>.</param>
        /// <returns>The greatest common denominator of the two <see cref="System.Int32"/>'s provided.</returns>
        public static int GreatestCommonDenominator(int first, int second)
        {
            // is second is 0 then the greatest common denominator is first
            if (second == 0)
            {
                return first;
            }
            // call Gcd recursively swapping the arguments around with each recursive call
            return GreatestCommonDenominator(second, first % second);
        }

    }

}
