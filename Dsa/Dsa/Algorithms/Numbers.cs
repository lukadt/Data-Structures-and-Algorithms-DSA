﻿using System;
using System.Globalization;
using System.Text;
using Dsa.Properties;

namespace Dsa.Algorithms
{
    /// <summary>
    /// Number algorithms.
    /// </summary>
    public static class Numbers
    {
        /// <summary>
        /// Computes the fibonacci number of a positive <see cref="System.Int32"/>.
        /// </summary>
        /// <remarks>
        /// This method is an O(1) operation for inputs 0 or 1, O(n) for larger numbers.
        /// </remarks>
        /// <param name="number">Integer to compute the fibonacci number for.</param>
        /// <returns>Fibonacci number for the specified <see cref="Int32"/>.</returns>
        /// <exception cref="ArgumentOutOfRangeException"><strong>number</strong> is less than <strong>0</strong>.</exception>
        public static int Fibonacci(this int number)
        {
            if (number < 0)
            {
                throw new ArgumentOutOfRangeException(Resources.FibonacciLessThanZero);
            }

            switch (number)
            {
                case 0:
                    return 0;
                case 1:
                    return 1;
                default:
                    {
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
        }

        /// <summary>
        /// Computes the factorial of an <see cref="System.Int32"/>.
        /// </summary>
        /// <remarks>
        /// This method is an O(1) operation for inputs less than 2, O(n) for larger numbers.
        /// </remarks>
        /// <param name="number">Integer to compute the factorial of.</param>
        /// <returns>The factorial of the specified <see cref="System.Int32"/>.</returns>
        /// <exception cref="ArgumentOutOfRangeException"><strong>number</strong> is less than <strong>0</strong>.</exception>
        public static int Factorial(this int number)
        {
            if (number < 0)
            {
                throw new ArgumentOutOfRangeException(Resources.FactorialLessThanZero);
            }

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
        /// <remarks>
        /// This method is an O(1) method when the exponent is 1, otherwise O(n) for larger exponents.
        /// </remarks>
        /// <param name="baseNumber">Base number.</param>
        /// <param name="exponent">Exponent.</param>
        /// <returns>The value of the base raised to the exponent.</returns>
        /// <exception cref="ArgumentOutOfRangeException"><strong>exponent</strong> is less than <strong>0</strong>.</exception>
        public static int Power(int baseNumber, int exponent)
        {
            if (exponent < 0)
            {
                throw new ArgumentOutOfRangeException(Resources.PowerExponentLessThanZero);
            }

            if (exponent == 0)
            {
                return 1; // n^0 = 1
            }
            int power = baseNumber;
            while (exponent > 1)
            {
                power *= baseNumber;
                exponent--;
            }
            return power;
        }

        /// <summary>
        /// Computes the greatest common denominator of two <see cref="System.Int32"/>'s.
        /// </summary>
        /// <param name="first">First integer.</param>
        /// <param name="second">Second integer.</param>
        /// <returns>The greatest common denominator of the two <see cref="System.Int32"/>'s.</returns>
        public static int GreatestCommonDenominator(int first, int second)
        {
            return second == 0 ? first : GreatestCommonDenominator(second, first % second);
        }

        /// <summary>
        /// Converts a positive base 10 integer to it's binary counterpart (base 2).
        /// </summary>
        /// <param name="value">Integer to convert to binary form.</param>
        /// <returns>Binary (base 2) representation of value.</returns>
        /// <exception cref="ArgumentOutOfRangeException"><strong>value</strong> is less than<strong>0</strong>.</exception>
        public static int ToBinary(this int value)
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(Resources.ToBaseNIntNegative);
            }

            StringBuilder sb = new StringBuilder();
            while (value > 0)
            {
                sb.Append(value % 2);
                value /= 2;
            }
            return Int32.Parse(sb.ToString().Reverse(), CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Converts a positive base 10 integer into it's octal counterpart (base 8).
        /// </summary>
        /// <param name="value">Integer to convert to octal form.</param>
        /// <returns>Octal (base 8) representation of value.</returns>
        /// <exception cref="ArgumentOutOfRangeException"><strong>value</strong> is less than <strong>0</strong>.</exception>
        public static int ToOctal(this int value)
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(Resources.ToBaseNIntNegative);
            }

            StringBuilder sb = new StringBuilder();
            while (value > 0)
            {
                sb.Append(value % 8);
                value /= 8;
            }
            return Int32.Parse(sb.ToString().Reverse(), CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Converts a positive base 10 integer into it's hexadecimal counterpart (base 16).
        /// </summary>
        /// <param name="value">Integer to convert to hexadecimal form.</param>
        /// <returns>Hexadecimal (base 16) representation of value.</returns>
        /// <exception cref="ArgumentOutOfRangeException"><strong>value</strong> is less than <strong>0</strong>.</exception>
        public static string ToHex(this int value)
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(Resources.ToBaseNIntNegative);
            }

            StringBuilder sb = new StringBuilder();
            while (value > 0)
            {
                int result = value % 16;
                if (result < 10)
                {
                    sb.Append(result);
                }
                else
                {
                    sb.Append(GetHexSymbol(result));
                }
                value /= 16;
            }
            return sb.ToString().Reverse();
        }

        /// <summary>
        /// Gets char symbol for hex numbers 10 .. 15 (A .. F).
        /// </summary>
        /// <param name="result">Integer to get hex symbol for.</param>
        /// <returns>Hex symbol for that number.</returns>
        private static char GetHexSymbol(int result)
        {
            char symbol = ' ';
            switch (result)
            {
                case 10:
                    symbol = 'A';
                    break;
                case 11:
                    symbol = 'B';
                    break;
                case 12:
                    symbol = 'C';
                    break;
                case 13:
                    symbol = 'D';
                    break;
                case 14:
                    symbol = 'E';
                    break;
                case 15:
                    symbol = 'F';
                    break;
            }
            return symbol;
        }
    }
}