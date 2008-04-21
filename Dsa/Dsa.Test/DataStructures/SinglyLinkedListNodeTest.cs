﻿using Dsa.DataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dsa.Test.DataStructures
{
    /// <summary>
    /// Tests for SinglyLinkedListNode.
    /// </summary>
    [TestClass]
    public class SinglyLinkedListNodeTest
    {
        /// <summary>
        /// Check to see that the expected Int32 value of a node is returned.
        /// </summary>
        [TestMethod]
        public void ValueIntTest()
        {
            SinglyLinkedListNode<int> n = new SinglyLinkedListNode<int>(10);

            Assert.AreEqual(10, n.Value);
        }

        /// <summary>
        /// Check to see that the expected string reference type value of a node is returned.
        /// </summary>
        [TestMethod]
        public void ValueStringTest()
        {
            SinglyLinkedListNode<string> n = new SinglyLinkedListNode<string>("Granville");

            Assert.AreEqual("Granville", n.Value);
        }

        /// <summary>
        /// Check to see that the next node of a node is correct.
        /// </summary>
        [TestMethod]
        public void NextTest()
        {
            SinglyLinkedListNode<int> n2 = new SinglyLinkedListNode<int>(20);
            SinglyLinkedListNode<int> n1 = new SinglyLinkedListNode<int>(10) {Next = n2};

            Assert.AreEqual(20, n1.Next.Value);
        }
    }
}