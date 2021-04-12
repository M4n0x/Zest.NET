using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Zest.Net.Entities.Attributes;
using Zest.Net.Entities.Interfaces;

namespace Zest.Net.Entities.Models
{
    /// <summary>
    /// Resource data class
    /// </summary>
    [ApiPath("ressources")]
    public class Resource
    {
        /// <summary>
        /// Resource Id
        /// </summary>
        public int Id { get; set; }
    }
}
