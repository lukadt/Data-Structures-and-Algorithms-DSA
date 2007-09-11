using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Dsa.DataStructures {

    /// <summary>
    /// CollectionDebugView is a class to be used to assist with the locals debug window in
    /// VS.  Can be used with any custom collection that implements ICollection(Of T).
    /// </summary>
    /// <typeparam name="T">Type of the CollectionDebugView.</typeparam>
    internal sealed class CollectionDebugView<T> {

        private ICollection<T> _collection;

        public CollectionDebugView(ICollection<T> collection) {
            if (collection == null) {
                throw new ArgumentNullException("collection");
            }
            _collection = collection;
        }

        /// <summary>
        /// Get's all the items in the collection as an array.
        /// By making the RootHidden the debugger doesn't display the items as
        /// elements of the property Items, rather just items of the array.
        /// </summary>
        [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
        public T[] Items {
            get {
                T[] items = new T[_collection.Count];
                _collection.CopyTo(items, 0);
                return items;
            }
        }

    }

}
