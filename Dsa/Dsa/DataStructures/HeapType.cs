namespace Dsa.DataStructures
{
    // todo: code review
    /// <summary>
    /// Defines the type of the <see cref="Heap{T}"/>.
    /// </summary>
    public enum HeapType
    {
        /// <summary>
        /// Min - each parent's key is less than or equal to that of its children.
        /// </summary>
        Min,
        /// <summary>
        /// Max - each parent's key is greater than or equal to that of its children.
        /// </summary>
        Max
    }
}