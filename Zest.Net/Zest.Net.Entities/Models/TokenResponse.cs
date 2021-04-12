using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Zest.Net.Entities.Models
{
    public class TokenResponse
    {
        public string Refresh { get; set; }

        public string Access { get; set; }
    }
}
