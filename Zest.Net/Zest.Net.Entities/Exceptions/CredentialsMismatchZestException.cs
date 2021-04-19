using System;
using System.Collections.Generic;
using System.Text;

namespace Zest.Net.Entities.Exceptions
{
    public class CredentialsMismatchZestException : ZestException
    {
        public CredentialsMismatchZestException() : base("Credentials mismatch")
        {

        }
    }
}
