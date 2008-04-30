using System;
using Dsa.Utility;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dsa.Test.Utility
{
    /// <summary>
    /// Test for the Guard family of methods.
    /// </summary>
    [TestClass]
    public class GuardTest
    {
        /// <summary>
        /// Check to see that the correct exception is thrown when the argument being verified is null.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ArgumentNullParamNameIsNotTest()
        {
            const string s = null;

            Guard.ArgumentNull(s, "s");
        }

        /// <summary>
        /// Check to see that the correct exception is thrown when the paramName is null.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ArgumentNullParamNameNullTest()
        {
            const string s = null;

            try
            {
                Guard.ArgumentNull(s, null);
            }
            catch (ArgumentNullException e)
            {
                Assert.AreEqual("paramName", e.ParamName);
                throw;
            }
        }

        /// <summary>
        /// Check to see that no exceptions are thrown when the argument is not null.
        /// </summary>
        [TestMethod]
        public void ArgumentIsNotNullTest()
        {
            const string s = "Granville";

            Guard.ArgumentNull(s, "s");
        }

        /// <summary>
        /// Check to see that the correct exception is thrown.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void InvalidOperationConditionTrueTest()
        {
            Guard.InvalidOperation(1 < 12, "Oh dead.");
        }

        /// <summary>
        /// Check to see that the correct exception is thrown when the message is null.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void InvalidOperationMessageNullTest()
        {
            Guard.InvalidOperation(2 < 3, null);
        }

        /// <summary>
        /// Check to make sure no exception is raised when the condition is false.
        /// </summary>
        [TestMethod]
        public void InvalidOperationConditionFalseTest()
        {
            Guard.InvalidOperation(2 > 4, "test");
        }
    }
}
