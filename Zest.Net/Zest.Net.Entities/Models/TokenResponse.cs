using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Zest.Net.Entities.Models
{
    /// <summary>
    /// Token response class
    /// </summary>
    public class TokenResponse
    {
        /// <summary>
        /// Refresh token value
        /// </summary>
        public string Refresh { get; set; }

        /// <summary>
        /// Access token value
        /// </summary>
        public string Access { get; set; }
    }
}
