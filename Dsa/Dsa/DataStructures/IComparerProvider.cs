using System.Collections.Generic;

namespace Dsa.DataStructures
{
    /// <summary>
    /// Defines a mechanism for retrieving a <see cref="IComparer{T}"/> being used by a DSA collection.
    /// </summary>
    /// <typeparam name="T">Type of <see cref="IComparer{T}"/>.</typeparam>
    public interface IComparerProvider<T>
    {
        /// <summary>
        /// Gets the <see cref="IComparer{T}"/> being used.
        /// </summary>
        IComparer<T> Comparer { get; }
    }
}