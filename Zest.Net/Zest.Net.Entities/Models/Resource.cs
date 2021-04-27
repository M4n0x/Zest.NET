using System.Collections.Generic;
using System.Text.Json.Serialization;
using Zest.Net.Entities.Attributes;
using System.ComponentModel.DataAnnotations;

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
        
        public int Id { get; set; } = -1;

        /// <summary>
        /// Resource name
        /// </summary>
        [StringLength(255, ErrorMessage = "Identifier too long (255 character limit).")]
        public string Name { get; set; }

        /// <summary>
        /// Resource Description
        /// </summary>
        public string Description { get; set; }

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
        /// Resource Picture
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Picture { get; set; }

        /// <summary>
        /// Resource ShareId
        /// </summary>
        [JsonPropertyName("share_id")]
        public string ShareId { get; set; }

        /// <summary>
        /// Resource Author
        /// </summary>
        public User Author { get; set; }

        /// <summary>
        /// Resource bookings
        /// </summary>
        public List<Booking> Bookings { get; set; }
    }
}
