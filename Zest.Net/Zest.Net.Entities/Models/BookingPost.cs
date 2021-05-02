using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Zest.Net.Entities.Models
{
    /// <summary>
    /// Resource Booking class
    /// </summary>
    public class BookingPost
    {


        /// <summary>
        /// Resource date start
        /// </summary>
        [JsonPropertyName("date_start")]
        public string DateStart { get; set; }

        /// <summary>
        /// Resource Date End
        /// </summary>
        [JsonPropertyName("date_end")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string DateEnd { get; set; }

        /// <summary>
        /// User id
        /// </summary>
        [JsonPropertyName("user")]
        public int User { get; set; }
    }
}
