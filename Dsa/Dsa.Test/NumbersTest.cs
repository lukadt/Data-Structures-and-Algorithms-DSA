using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dsa.Algorithms;

namespace Dsa.Test {

    [TestClass]
    public class NumbersTest {

        /// <summary>
        /// Test to see that calling Fibonacci algiorithm returns the correct value.
        /// </summary>
        [TestMethod]
        public void FibonacciTest() {
            Assert.AreEqual<int>(13, Numbers.Fibonacci(6));
        }

        /// <summary>
        /// Test to see that calling Factorial algorithm returns the correct value.
        /// </summary>
        [TestMethod]
        public void FactorialTest() {
            Assert.AreEqual<int>(720, Numbers.Factorial(6));
        }

    }

}
