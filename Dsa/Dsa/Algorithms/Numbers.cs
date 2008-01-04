using System;
using Dsa.Properties;

namespace Dsa.Algorithms
{

    /// <summary>
    /// Number algorithms.
    /// </summary>
    public static class Numbers
    {

        /// <summary>
        /// Computes the fibonnaci number of a positive <see cref="System.Int32"/>.
        /// </summary>
        /// <param name="number">The <see cref="System.Int32"/> to compute the fibonnacci number for.</param>
        /// <returns>An <see cref="System.Int32"/> representing the fibonacci number.</returns>
        /// <exception cref="ArgumentOutOfRangeException"><strong>number</strong> is less than <strong>0</strong>.</exception>
        public static int Fibonacci(int number)
        {
            if (number < 0)
            {
                throw new ArgumentOutOfRangeException(Resources.FibonacciLessThanZero);
            }

            // base cases
            if (number == 0) // fibonacci of 0 is 0
            {
                return 0;
            }
            else if (number == 1) // fibonacci of 1 is 1
            {
                return 1;
            }
            else
            {
                // number > 1
                int[] fibs = new int[number + 1];
                fibs[0] = 0;
                fibs[1] = 1;
                for (int i = 2; i <= number; i++)
                {
                    fibs[i] = fibs[i - 1] + fibs[i - 2];
                }

                return fibs[number];
            }
        }

        /// <summary>
        /// Computes the factorial of an <see cref="System.Int32"/>.
        /// </summary>
        /// <param name="number"><see cref="System.Int32"/> to compute the factorial of.</param>
        /// <returns>The factorial of the specified <see cref="System.Int32"/>.</returns>
        /// <exception cref="ArgumentOutOfRangeException"><strong>number</strong> is less than <strong>0</strong>.</exception>
        public static int Factorial(int number)
        {
            if (number < 0)
            {
                throw new ArgumentOutOfRangeException(Resources.FactorialLessThanZero);
            }

            // factorial of 0, and 1 is 1
            if (number < 2)
            {
                return 1;
            }
            else
            {
                int factorial = 1;
                for (int i = 2; i <= number; i++)
                {
                    factorial *= i;
                }

                return factorial;
            }
        }

        /// <summary>
        /// Computes the power of an <see cref="System.Int32"/> to a given exponent.
        /// </summary>
        /// <param name="baseNumber">The base number.</param>
        /// <param name="exponent">The exponent.</param>
        /// <returns>The value of the base raised to the exponent.</returns>
        /// <exception cref="ArgumentOutOfRangeException"><strong>exponent</strong> is less than <strong>0</strong>.</exception>
        public static int Power(int baseNumber, int exponent)
        {
            if (exponent < 0)
            {
                throw new ArgumentOutOfRangeException(Resources.PowerExponentLessThanZero);
            }

            // the law of indicies states that a base with the exponent of 0 is 1
            if (exponent == 0)
            {
                return 1;
            }
            else
            {
                int power = baseNumber;
                while (exponent > 1)
                {
                    power *= baseNumber;
                    exponent--;
                }
                return power;
            }
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
