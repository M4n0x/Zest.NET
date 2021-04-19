using System;
using System.Collections.Generic;
using System.Text;

namespace Zest.Net.Entities.Exceptions
{
    public class RegisterZestException : ZestException
    {
        public string EmailError { get; set; }
        public string UsernameError { get; set; }

        public RegisterZestException(string emailError, string usernameError) : base("Can not create an account")
        {
            EmailError = emailError;
            UsernameError = usernameError;
        }
    }

    public class RegisterError
    {
        public List<string> Email { get; set; }

        public List<string> Username { get; set; }
    }
}
