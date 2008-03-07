using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Dsa.DataStructures
{

    /// <summary>
    /// CollectionDebugView assists the locals debug window in Visual Studio. All collections in DSA get this support for free.
    /// </summary>
    /// <remarks>
    /// This emulates BCL collections that provide a simple view of collections and a more intimate view (this is called the raw view).
    /// </remarks>
    /// <typeparam name="T">Type of the CollectionDebugView.</typeparam>
    internal sealed class CollectionDebugView<T>
    {

        private ICollection<T> _collection;

        public CollectionDebugView(ICollection<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException("collection");
            }
            _collection = collection;
        }

        /// <summary>
        /// Get's all the k in the collection as an array. By making the RootHidden the debugger doesn't display the k as
        /// elements of the property Items, rather just k of the array.
        /// </summary>
        [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
        public T[] Items
        {
            get
            {
                T[] items = new T[_collection.Count];
                _collection.CopyTo(items, 0);
                return items;
            }
        }

    }

}
