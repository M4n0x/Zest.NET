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
        [JsonPropertyName("id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public int Id { get; set; } = 0;

        /// <summary>
        /// Resource name
        /// </summary>
        [StringLength(255, ErrorMessage = "Identifier too long (255 character limit).")]
        [Required]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Resource Description
        /// </summary>
        [Required]
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        /// Resource date start
        /// </summary>
        [JsonPropertyName("date_start")]
        public string DateStart { get; set; } = System.DateTime.Now.ToString("yyyy-MM-dd");

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
        [JsonPropertyName("picture")]
        public string Picture { get; set; }

        /// <summary>
        /// Resource ShareId
        /// </summary>
        [JsonPropertyName("share_id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string ShareId { get; set; }

        /// <summary>
        /// Resource Author
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public User Author { get; set; }

        /// <summary>
        /// Resource bookings
        /// </summary>
        [JsonPropertyName("bookings")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<Booking> Bookings { get; set; }
    }
}
