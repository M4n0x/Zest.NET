using System;
using System.Collections.Generic;
using System.Text;

namespace Zest.Net.Entities.Attributes
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class ApiPathAttribute : Attribute
    {
        public string Path { get; set; }

        public ApiPathAttribute(string path)
        {
            Path = path;
        }
    }
}
