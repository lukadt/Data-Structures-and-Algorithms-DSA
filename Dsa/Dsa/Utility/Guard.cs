using System;

namespace Dsa.Utility
{
    /// <summary>
    /// A series of guard methods to check algorithm inputs.
    /// <remarks>
    /// The methods are designed to verify preconditions and should be used always.
    /// </remarks>
    /// </summary>
    public static class Guard
    {
        /// <summary>
        /// Guards against a null object reference.
        /// </summary>
        /// <param name="value">Object to verify is not null.</param>
        /// <param name="paramName">Name of the parameter.</param>
        /// <exception cref="ArgumentNullException"><strong>value</strong> -- or -- <strong>paramName</strong> are <strong>null</strong>.</exception>
        public static void ArgumentNull(object value, string paramName)
        {
            if (paramName == null)
            {
                throw new ArgumentNullException("paramName");
            }
            if (value == null)
            {
                throw new ArgumentNullException(paramName);
            }
        }
    }
}
