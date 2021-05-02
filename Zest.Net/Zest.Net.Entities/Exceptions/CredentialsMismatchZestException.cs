using System;
using System.Collections.Generic;
using System.Text;

namespace Zest.Net.Entities.Exceptions
{
    /// <summary>
    /// Credentials mismatch exception
    /// </summary>
    public class CredentialsMismatchZestException : ZestException
    {
        /// <summary>
        /// Exception constructor
        /// </summary>
        public CredentialsMismatchZestException() : base("Credentials mismatch")
        {
            // nothing
        }
    }
}
