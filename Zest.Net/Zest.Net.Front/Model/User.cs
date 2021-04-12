using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Zest.Net.Front.Model
{
    public class User
    {
        public int Id { get; set; }

        [JsonPropertyName("first_name")]
        public string Firstname { get; set; }
        [JsonPropertyName("last_name")]
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Picture { get; set; }
        public string Username { get; set; }
    }
}
