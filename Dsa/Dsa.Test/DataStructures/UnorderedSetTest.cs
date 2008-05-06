using System;
using System.Collections.Generic;
using Dsa.DataStructures;
using Dsa.Test.Utility;
using NUnit.Framework;

namespace Dsa.Test.DataStructures
{
    /// <summary>
    /// Tests for UnorderedSet(Of T).
    /// </summary>
    [TestFixture]
    public class UnorderedSetTest
    {
        /// <summary>
        /// Check to see that the item is added to the set.
        /// </summary>
        [Test]
        public void AddTest()
        {
            UnorderedSet<int> actual = new UnorderedSet<int> {5, 12, 15, 5, 12};
            UnorderedSet<int> expected = new UnorderedSet<int> {5, 12, 15};

            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Check to see that the items in the set are cleared.
        /// </summary>
        [Test]
        public void ClearTest()
        {
            UnorderedSet<int> actual = new UnorderedSet<int> {3, 4, 5};

            actual.Clear();

            Assert.AreEqual(0, actual.Count);
        }

        /// <summary>
        /// Check to see that contains returns the correct value.
        /// </summary>
        [Test]
        public void ContainsTest()
        {
            UnorderedSet<char> actual = new UnorderedSet<char> {'a', 'b', 'c'};

            Assert.IsTrue(actual.Contains('b'));
            Assert.IsFalse(actual.Contains('d'));
        }

        /// <summary>
        /// Check to see that calling Remove leaves the set in the correct state.
        /// </summary>
        [Test]
        public void RemoveTest()
        {
            UnorderedSet<int> actual = new UnorderedSet<int> {4, 1, 89, 90};
            UnorderedSet<int> expected = new UnorderedSet<int> {1, 89, 90};

            Assert.IsTrue(actual.Remove(4));
            Assert.IsFalse(actual.Remove(899));
            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Check to see when using an value type with the same properties twice that only one of them is added
        /// to the set.
        /// </summary>
        [Test]
        public void DuplicateObjectTest()
        {
            UnorderedSet<Person> actual = new UnorderedSet<Person>();
            Person p1 = new Person { FirstName = "Granville", LastName = "Barnett" };
            Person p2 = new Person { FirstName = "Granville", LastName = "Barnett" };

            actual.Add(p1);
            actual.Add(p2);

            Assert.AreEqual(1, actual.Count);
        }

        /// <summary>
        /// Check to see that the array items are returned in the correct order.
        /// </summary>
        [Test]
        public void ToArrayTest()
        {
            UnorderedSet<char> set = new UnorderedSet<char> {'a', 'r', 'd', 'f'};
            char[] expected = { 'a', 'r', 'd', 'f' };

            CollectionAssert.AreEqual(expected, set.ToArray());
        }

        /// <summary>
        /// Check to see that the correct number of items are contained within the set after copying an IEnumerable collection to the
        /// set.
        /// </summary>
        [Test]
        public void CopyIEnumerableToSetTest()
        {
            List<string> originalCollection = new List<string> { "Granville", "John", "Granville", "Betty" };
            UnorderedSet<string> actual = new UnorderedSet<string>(originalCollection);

            Assert.AreEqual(3, actual.Count);
        }

        /// <summary>
        /// Check to see that the correct exception is thrown when the collection whose items are to be copied to the
        /// set is null.
        /// </summary>
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CopyIEnumerableToSetCollectionNullTest()
        {
            const List<string> orginal = null;
            UnorderedSet<string> actual = new UnorderedSet<string>(orginal);
        }
    }
}