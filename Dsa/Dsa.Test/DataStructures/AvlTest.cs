using NUnit.Framework;
using Dsa.DataStructures;

namespace Dsa.Test.DataStructures
{
    /// <summary>
    /// Tests for Avl tree.
    /// </summary>
    [TestFixture]
    public class AvlTest
    {
        /// <summary>
        /// Check to see that the tree structure is correct after inserting nodes which will cause a rebalancing.
        /// </summary>
        [Test]
        public void AddTest()
        {
            Avl<int> actual = new Avl<int> { 10, 20, 30 };

            Assert.AreEqual(20, actual.Root.Value);
            Assert.AreEqual(10, actual.Root.Left.Value);
            Assert.AreEqual(30, actual.Root.Right.Value);
        }
    }
}
