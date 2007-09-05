using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dsa.DataStructures;

namespace Dsa.Test {

    [TestClass]
    public class StackCollectionTest {

        /// <summary>
        /// Test to see that Pushing an item onto the stack results in the intended behaviour.
        /// </summary>
        [TestMethod]
        public void PushTest() {
            StackCollection<int> myStack = new StackCollection<int>();

            myStack.Push(10);
            myStack.Push(20);

            Assert.AreEqual<int>(20, myStack.Peek());
        }

        /// <summary>
        /// Test to see that calling Peek returns the correct item.
        /// </summary>
        [TestMethod]
        public void PeekTest() {
            StackCollection<int> myStack = new StackCollection<int>();

            myStack.Push(10);
            myStack.Push(20);
            myStack.Push(30);

            Assert.AreEqual<int>(30, myStack.Peek());
        }

        /// <summary>
        /// Test to see that the correct item is returned and the item at the top of the stack is 
        /// updated appropriatley after calling Pop.
        /// </summary>
        [TestMethod]
        public void PopTest() {
            StackCollection<int> actual = new StackCollection<int>();

            actual.Push(10);
            actual.Push(20);
            actual.Push(30);

            Assert.AreEqual<int>(30, actual.Pop());
            Assert.AreEqual<int>(20, actual.Peek());
        }

    }

}
