using System;
using System.Collections.Generic;
using System.Text;

namespace Zest.Net.Entities.Exceptions
{
    /// <summary>
    /// Custom Zest Exception
    /// </summary>
    public class ZestException : Exception
    {
        /// <summary>
        /// Zest Exception
        /// </summary>
        /// <param name="message">Exception message</param>
        public ZestException(string message) : base(message)
        {
            // nothing
        }
    }
}
