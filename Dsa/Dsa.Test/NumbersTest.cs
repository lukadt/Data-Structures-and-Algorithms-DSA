using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dsa.Algorithms;

namespace Dsa.Test
{

    [TestClass]
    public class NumbersTest
    {

        /// <summary>
        /// Test to see that calling Fibonacci algiorithm returns the correct value.
        /// </summary>
        [TestMethod]
        public void FibonacciTest()
        {
            Assert.AreEqual(13, Numbers.Fibonacci(6));
        }

        /// <summary>
        /// Test to see that calling Factorial algorithm returns the correct value.
        /// </summary>
        [TestMethod]
        public void FactorialTest()
        {
            Assert.AreEqual(720, Numbers.Factorial(6));
        }

        /// <summary>
        /// Test to see that the power method returns the correct value.
        /// </summary>
        [TestMethod]
        public void PowerNotZeroTest()
        {
            Assert.AreEqual(4, Numbers.Power(2, 2));
        }

        /// <summary>
        /// Test to see that 1 is returned when the exponent is 0
        /// </summary>
        [TestMethod]
        public void PowerZeroTest()
        {
            Assert.AreEqual(1, Numbers.Power(2, 0));
        }

        /// <summary>
        /// Test to see that calling the Gcd method results in the expected value being returned.
        /// </summary>
        [TestMethod]
        public void GcdTest()
        {
            Assert.AreEqual(1, Numbers.Gcd(9, 4));
            Assert.AreEqual(3, Numbers.Gcd(3, 9));
            Assert.AreEqual(5, Numbers.Gcd(10, 5));
            Assert.AreEqual(1, Numbers.Gcd(5, 12));
            Assert.AreEqual(5, Numbers.Gcd(-10, 5));
            Assert.AreEqual(5, Numbers.Gcd(5, -10));
        }
    }

}
