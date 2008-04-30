using System;

namespace Dsa.Utility
{
    /// <summary>
    /// A series of guard methods to check algorithm inputs.
    /// </summary>
    /// <remarks>
    /// The methods are designed to verify preconditions and should always be used to verify the inputs to
    /// all algorithms (within context).
    /// </remarks>
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

        ///<summary>
        ///</summary>
        ///<param name="condition"></param>
        ///<param name="message"></param>
        public static void InvalidOperation(bool condition, string message)
        {
            ArgumentNull(message, "message");
            if (condition)
            {
                throw new InvalidOperationException(message);
            }
        }
    }
}
