using System;
using Dsa.Algorithms;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dsa.Test
{

    /// <summary>
    /// Numbers tests.
    /// </summary>
    [TestClass]
    public class NumbersTest
    {

        /// <summary>
        /// Check to see that calling Fibonacci algiorithm returns the correct value.
        /// </summary>
        [TestMethod]
        public void FibonacciTest()
        {
            Assert.AreEqual(0, Numbers.Fibonacci(0));
            Assert.AreEqual(1, Numbers.Fibonacci(1));
            Assert.AreEqual(1, Numbers.Fibonacci(2));
            Assert.AreEqual(2, Numbers.Fibonacci(3));
            Assert.AreEqual(3, Numbers.Fibonacci(4));
            Assert.AreEqual(5, Numbers.Fibonacci(5));
            Assert.AreEqual(8, Numbers.Fibonacci(6));
            Assert.AreEqual(13, Numbers.Fibonacci(7));
        }

        /// <summary>
        /// Check to see that the correct exception is thrown when fibonacci is called with a number less than 0.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void FibonacciNumberLessThanZeroTest()
        {
            Numbers.Fibonacci(-1);
        }

        /// <summary>
        /// Check to see that calling Factorial algorithm returns the correct value.
        /// </summary>
        [TestMethod]
        public void FactorialTest()
        {
            Assert.AreEqual(1, Numbers.Factorial(0));
            Assert.AreEqual(1, Numbers.Factorial(1));
            Assert.AreEqual(2, Numbers.Factorial(2));
            Assert.AreEqual(6, Numbers.Factorial(3));
            Assert.AreEqual(24, Numbers.Factorial(4));
            Assert.AreEqual(120, Numbers.Factorial(5));
            Assert.AreEqual(720, Numbers.Factorial(6));
        }

        /// <summary>
        /// Check to see that the correct exception is thrown when calling Factorial using a negative integer.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void FactorialNumberLessThanZeroTest()
        {
            Numbers.Factorial(-1);
        }

        /// <summary>
        /// Check to see that the power method returns the correct value.
        /// </summary>
        [TestMethod]
        public void PowerNotZeroTest()
        {
            Assert.AreEqual(1, Numbers.Power(0, 0));
            Assert.AreEqual(4, Numbers.Power(2, 2));
            Assert.AreEqual(243, Numbers.Power(3, 5));
            Assert.AreEqual(1024, Numbers.Power(2, 10));
            Assert.AreEqual(4, Numbers.Power(-2, 2));
        }
        
        /// <summary>
        /// Check to see that the correct expception is thrown when the exponent is negative.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void PowerExponentLessThanZeroTest()
        {
            Numbers.Power(2, -1);
        }

        /// <summary>
        /// Check to see that calling the Gcd method results in the expected value being returned.
        /// </summary>
        [TestMethod]
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
        [TestMethod]
        public void ToBaseTwoTest()
        {
            int actual = 23;

            Assert.AreEqual(10111, actual.ToBinary());
        }

        /// <summary>
        /// Check to see that the correct exception is raised when the int to convert to binary is negative.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ToBaseTwoNegativeIntTest()
        {
            int actual = -1;

            actual.ToBinary();
        }

        /// <summary>
        /// Check to see that the correct value is returned when converting a base 10 integer to
        /// it's base 8 counterpart.
        /// </summary>
        [TestMethod]
        public void ToOctalTest()
        {
            int actual = 18;

            Assert.AreEqual(22, actual.ToOctal());
        }

        /// <summary>
        /// Check to see that the correct exception is thrown when the int to covert to octal is negative.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ToOctalNegativeIntTest()
        {
            int actual = -1;

            actual.ToOctal();
        }

        /// <summary>
        /// Check to see that the correct string is returned when converting a base 10 integer its base 16
        /// equivalent.
        /// </summary>
        [TestMethod]
        public void ToHexTest()
        {
            int actual1 = 63923;
            int actual2 = 2362;
            int actual3 = 14397;
            int actual4 = 222;
            int actual5 = 43975;

            Assert.AreEqual("F9B3", actual1.ToHex());
            Assert.AreEqual("93A", actual2.ToHex());
            Assert.AreEqual("383D", actual3.ToHex());
            Assert.AreEqual("DE", actual4.ToHex());
            Assert.AreEqual("ABC7", actual5.ToHex());
        }

        /// <summary>
        /// Check to see the correct exception is raised when the value provided is negative.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ToHexNegativeIntTest()
        {
            int actual = -1;

            actual.ToHex();
        }

    }

}