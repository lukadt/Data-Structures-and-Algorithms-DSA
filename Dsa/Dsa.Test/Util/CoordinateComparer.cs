using System.Collections.Generic;

namespace Dsa.Test
{

    /// <summary>
    /// A simple stuct that exists so we can simply model a comparer for.
    /// </summary>
    public struct Coordinate
    {
        
        public int X { get; set; }
        public int Y { get; set; }

        public Coordinate(int x, int y) : this()
        {
            X = x;
            Y = y;
        }

    }

    public class CoordinateComparer : IComparer<Coordinate>
    {
        /// <summary>
        /// A dummy comparer.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int Compare(Coordinate x, Coordinate y)
        {
            if (x.X == y.X && x.Y == y.Y)
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }
    }
}
