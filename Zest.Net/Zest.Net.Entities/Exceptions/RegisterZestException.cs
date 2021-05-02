using System;
using System.Collections.Generic;
using System.Text;

namespace Zest.Net.Entities.Exceptions
{
    /// <summary>
    /// Register error
    /// </summary>
    public class RegisterZestException : ZestException
    {
        /// <summary>
        /// Email field
        /// </summary>
        public string EmailError { get; set; }

        /// <summary>
        /// Username error
        /// </summary>
        public string UsernameError { get; set; }

        /// <summary>
        /// Register error with API
        /// </summary>
        /// <param name="emailError">email field error</param>
        /// <param name="usernameError">username field error</param>
        public RegisterZestException(string emailError, string usernameError) : base("Can not create an account")
        {
            EmailError = emailError;
            UsernameError = usernameError;
        }
    }

    /// <summary>
    /// Register data error
    /// </summary>
    public class RegisterError
    {
        /// <summary>
        /// Email Data error field
        /// </summary>
        public List<string> Email { get; set; }

        /// <summary>
        /// Username Data error field
        /// </summary>
        public List<string> Username { get; set; }
    }
}
