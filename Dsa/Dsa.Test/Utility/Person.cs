using System;

namespace Dsa.Test.Utility
{
    public class Person : IComparable<Person>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int CompareTo(Person other)
        {
            if (FirstName.ToUpper() == other.FirstName.ToUpper() && LastName.ToUpper() == other.LastName.ToUpper())
            {
                return 0;
            }
            return -1;
        }
    }
}
