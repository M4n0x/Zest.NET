using System;
using System.Collections.Generic;
using System.Text;

namespace Zest.Net.Entities.Attributes
{

    /// <summary>
    /// ApiPath attribute
    /// USed to get entities with a Generic repository
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class ApiPathAttribute : Attribute
    {
        /// <summary>
        /// Path to API resource
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Attribute constructor
        /// </summary>
        /// <param name="path">Api relative path to resource</param>
        public ApiPathAttribute(string path)
        {
            Path = path;
        }
    }
}
