using System;
using System.Collections.Generic;

namespace Dsa.DataStructures
{

    /// <summary>
    /// Abstract class that provides basic functionality for all data structures that use a <see cref="IComparer{T}"/>
    /// somewhere in their implementation.
    /// </summary>
    /// <typeparam name="T">Type of <see cref="ComparerProvider{T}"/></typeparam>
    [Serializable]
    public abstract class ComparerProvider<T> : IComparerProvider<T>
    {

        [NonSerialized]
        private readonly IComparer<T> _comparer;

        /// <summary>
        /// Initializes a new instance of the <see cref="ComparerProvider{T}"/> class.
        /// </summary>
        /// <remarks>
        /// Calling <see cref="ComparerProvider{T}"/> with the default constructor uses a default comparer.
        /// </remarks>
        protected ComparerProvider()
        {
            _comparer = Comparer<T>.Default;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ComparerProvider{T}"/> class with a specified <see cref="IComparer{T}"/>.
        /// </summary>
        /// <param name="comparer">The comparer to use.</param>
        /// <exception cref="ArgumentNullException"><strong>comparer</strong> is <strong>null</strong>.</exception>
        protected ComparerProvider(IComparer<T> comparer)
        {
            if (comparer == null)
            {
                throw new ArgumentNullException("comparer");
            }
            _comparer = comparer;
        }

        #region IComparerProvider<T> Members

        /// <summary>
        /// Gets the <see cref="IComparer{T}"/> being used.
        /// </summary>
        public IComparer<T> Comparer
        {
            get { return _comparer; }
        }

        #endregion

    }

}
