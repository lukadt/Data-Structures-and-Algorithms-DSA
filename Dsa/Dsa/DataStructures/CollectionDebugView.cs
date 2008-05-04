using System.Collections.Generic;
using System.Diagnostics;
using Dsa.Utility;

namespace Dsa.DataStructures
{
    /// <summary>
    /// CollectionDebugView assists the locals debug window in Visual Studio.
    /// </summary>
    /// <remarks>
    /// This emulates BCL collections that provide a simple view of collections and a more intimate view (raw view).
    /// </remarks>
    /// <typeparam name="T">Type of the CollectionDebugView.</typeparam>
    internal sealed class CollectionDebugView<T>
    {
        private readonly ICollection<T> _collection;

        public CollectionDebugView(ICollection<T> collection)
        {
            Guard.ArgumentNull(collection, "collection");
            
            _collection = collection;
        }

        /// <summary>
        /// Gets all the items in the collection as an array. By making the RootHidden the debugger doesn't display the items as
        /// elements of the property Items, rather just items of the array.
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
