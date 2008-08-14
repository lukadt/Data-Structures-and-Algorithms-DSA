﻿using System;
using Dsa.Algorithms;
using NUnit.Framework;

namespace Dsa.Test.Algorithms
{
    /// <summary>
    /// Numbers tests.
    /// </summary>
    [TestFixture]
    public sealed class NumbersTest
    {
        /// <summary>
        /// Check to see that calling Fibonacci algorithm returns the correct value.
        /// </summary>
        [Test]
        public void FibonacciTest()
        {
            Assert.AreEqual(0, 0.Fibonacci());
            Assert.AreEqual(1, 1.Fibonacci());
            Assert.AreEqual(1, 2.Fibonacci());
            Assert.AreEqual(2, 3.Fibonacci());
            Assert.AreEqual(3, 4.Fibonacci());
            Assert.AreEqual(5, 5.Fibonacci());
            Assert.AreEqual(8, 6.Fibonacci());
            Assert.AreEqual(13, 7.Fibonacci());
        }

        /// <summary>
        /// Check to see that the correct exception is thrown when fibonacci is called with a number less than 0.
        /// </summary>
        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void FibonacciNumberLessThanZeroTest()
        {
            (-1).Fibonacci();
        }

        /// <summary>
        /// Check to see that calling Factorial algorithm returns the correct value.
        /// </summary>
        [Test]
        public void FactorialTest()
        {
            Assert.AreEqual(1, 0.Factorial());
            Assert.AreEqual(1, 1.Factorial());
            Assert.AreEqual(2, 2.Factorial());
            Assert.AreEqual(6, 3.Factorial());
            Assert.AreEqual(24, 4.Factorial());
            Assert.AreEqual(120, 5.Factorial());
            Assert.AreEqual(720, 6.Factorial());
        }

        /// <summary>
        /// Check to see that the correct exception is thrown when calling Factorial using a negative integer.
        /// </summary>
        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void FactorialNumberLessThanZeroTest()
        {
            (-1).Factorial();
        }

        /// <summary>
        /// Check to see that the power method returns the correct value.
        /// </summary>
        [Test]
        public void PowerNotZeroTest()
        {
            Assert.AreEqual(1, Numbers.Power(0, 0));
            Assert.AreEqual(4, Numbers.Power(2, 2));
            Assert.AreEqual(243, Numbers.Power(3, 5));
            Assert.AreEqual(1024, Numbers.Power(2, 10));
            Assert.AreEqual(4, Numbers.Power(-2, 2));
        }
        
        /// <summary>
        /// Check to see that the correct exception is thrown when the exponent is negative.
        /// </summary>
        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void PowerExponentLessThanZeroTest()
        {
            Numbers.Power(2, -1);
        }

        /// <summary>
        /// Check to see that calling the Gcd method results in the expected value being returned.
        /// </summary>
        [Test]
        public void GcdTest()
        {
            Assert.AreEqual(1, Numbers.GreatestCommonDenominator(9, 4));
            Assert.AreEqual(3, Numbers.GreatestCommonDenominator(3, 9));
            Assert.AreEqual(5, Numbers.GreatestCommonDenominator(10, 5));
            Assert.AreEqual(1, Numbers.GreatestCommonDenominator(5, 12));
            Assert.AreEqual(5, Numbers.GreatestCommonDenominator(-10, 5));
            Assert.AreEqual(5, Numbers.GreatestCommonDenominator(5, -10));
        }

        /// <summary>
        /// Check to see that the integer returned is correct.
        /// </summary>
        [Test]
        public void ToBaseTwoTest()
        {
            const int actual = 23;

            Assert.AreEqual(10111, actual.ToBinary());
        }

        /// <summary>
        /// Check to see that the correct exception is raised when the int to convert to binary is negative.
        /// </summary>
        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ToBaseTwoNegativeIntTest()
        {
            const int actual = -1;

            actual.ToBinary();
        }

        /// <summary>
        /// Check to see that the correct value is returned when converting a base 10 integer to
        /// it's base 8 counterpart.
        /// </summary>
        [Test]
        public void ToOctalTest()
        {
            const int actual = 18;

            Assert.AreEqual(22, actual.ToOctal());
        }

        /// <summary>
        /// Check to see that the correct exception is thrown when the int to covert to octal is negative.
        /// </summary>
        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ToOctalNegativeIntTest()
        {
            const int actual = -1;

            actual.ToOctal();
        }

        /// <summary>
        /// Check to see that the correct string is returned when converting a base 10 integer its base 16
        /// equivalent.
        /// </summary>
        [Test]
        public void ToHexTest()
        {
            const int actual1 = 63923;
            const int actual2 = 2362;
            const int actual3 = 14397;
            const int actual4 = 222;
            const int actual5 = 43975;

            Assert.AreEqual("F9B3", actual1.ToHex());
            Assert.AreEqual("93A", actual2.ToHex());
            Assert.AreEqual("383D", actual3.ToHex());
            Assert.AreEqual("DE", actual4.ToHex());
            Assert.AreEqual("ABC7", actual5.ToHex());
        }

        /// <summary>
        /// Check to see the correct exception is raised when the value provided is negative.
        /// </summary>
        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ToHexNegativeIntTest()
        {
            const int actual = -1;

            actual.ToHex();
        }

        /// <summary>
        /// Check to see that the correct value is returned when checking a few numbers if they are primes.
        /// </summary>
        [Test]
        public void IsPrimeTest()
        {
            Assert.IsFalse(1.IsPrime());
            Assert.IsTrue(2.IsPrime());
            Assert.IsTrue(3.IsPrime());
            Assert.IsFalse(4.IsPrime());
            Assert.IsTrue(5.IsPrime());
            Assert.IsFalse(6.IsPrime());
            Assert.IsTrue(7.IsPrime());
            Assert.IsFalse(8.IsPrime());
            Assert.IsFalse(9.IsPrime());
            Assert.IsFalse(10.IsPrime());
            Assert.IsTrue(11.IsPrime());
        }

        /// <summary>
        /// Check to see that the correct value is returned when the number of digits is less
        /// than 1.
        /// </summary>
        [Test]
        public void MaxValueDigitsLessThanZeroTest()
        {
            Assert.AreEqual(0, Numbers.MaxValue(Base.Binary, 0));
        }

        /// <summary>
        /// Check to see that the correct max value is returned.
        /// </summary>
        [Test]
        public void MaxValueHexadecimalTest()
        {
            Assert.AreEqual(255, Numbers.MaxValue(Base.Hexadecimal, 2));
        }

        /// <summary>
        /// Check to see correct max value for binary is returned.
        /// </summary>
        [Test]
        public void MaxValueBinaryTest()
        {
            Assert.AreEqual(1023, Numbers.MaxValue(Base.Binary, 10));
        }

        /// <summary>
        /// Check to see that the correct max value for octal is returned.
        /// </summary>
        [Test]
        public void MaxValueOctalTest()
        {
            Assert.AreEqual(32767, Numbers.MaxValue(Base.Octal, 5));
        }

        /// <summary>
        /// Check to see that the correct max value for decimal is returned.
        /// </summary>
        [Test]
        public void MaxValueDecimalTest()
        {
            Assert.AreEqual(9999, Numbers.MaxValue(Base.Decimal, 4));
        }
    }
}