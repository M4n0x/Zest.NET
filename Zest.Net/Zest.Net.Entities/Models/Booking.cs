﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Zest.Net.Entities.Models
{
    /// <summary>
    /// Resource Booking class
    /// </summary>
    public class Booking
    {
        /// <summary>
        /// Booking Id
        /// </summary>
        public int Id { get; set; }

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


        public User User { get; set; }
    }
}
