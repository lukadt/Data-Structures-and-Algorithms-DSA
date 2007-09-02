using System;
using Dsa.DataStructures;

namespace ConsoleApplication {

    class Program {

        static void Main(string[] args) {
            SinglyLinkedListCollectionExample();
        }

        /// <summary>
        /// Creates a SinglyLinkedListCollection(Of T) and then performs some common operations on the
        /// collection.
        /// </summary>
        static void SinglyLinkedListCollectionExample() {
            SinglyLinkedListCollection<string> sll = new SinglyLinkedListCollection<string>();
            sll.AddLast("Bing");
            sll.AddBefore(sll.Head, "Chandler");
            sll.AddFirst("Monica");
            sll.AddAfter(sll.Head, "Geller");
            foreach (string s in sll) {
                Console.WriteLine(s);
            }
            string[] myArray = new string[sll.Count];
            sll.CopyTo(myArray);
            Console.WriteLine();
            foreach (string s in myArray) {
                Console.WriteLine(s);
            }
            Console.WriteLine();
            Console.WriteLine("Contains Joey? {0}", sll.Contains("Joey"));
            Console.WriteLine("Contains Monica? {0}", sll.Contains("Monica"));
            sll.Remove("Chandler");
            Console.WriteLine();
            foreach (string s in sll) {
                Console.WriteLine(s);
            }
            sll.RemoveFirst();
            sll.RemoveLast();
            Console.WriteLine();
            Console.WriteLine("Head value: {0}, Tail value: {1}", sll.Head.Value, sll.Tail.Value);
        }

    }

}
