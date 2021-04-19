using Zest.Net.Entities.Attributes;

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
