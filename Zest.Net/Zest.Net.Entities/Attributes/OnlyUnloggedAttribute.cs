using System;
using System.Collections.Generic;
using System.Text;

namespace Zest.Net.Entities.Attributes
{
    /// <summary>
    /// Only UnLogged attribute to define that user can't access page when logged in
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class OnlyUnloggedAttribute : Attribute
    {
        public OnlyUnloggedAttribute()
        {
            // nothing
        }
    }
}
