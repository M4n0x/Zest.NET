using System.Text.Json.Serialization;
using Zest.Net.Entities.Attributes;

namespace Zest.Net.Entities.Models
{
    /// <summary>
    /// User data class
    /// </summary>
    [ApiPath("users")]
    public class User
    {
        /// <summary>
        /// User constructor
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="firstname">Firstname</param>
        /// <param name="lastname">Lastname</param>
        /// <param name="email">Email</param>
        /// <param name="password">Password</param>
        public User(string username, string firstname, string lastname, string email, string password)
        {
            Username = username;
            Firstname = firstname;
            Lastname = lastname;
            Email = email;
            Password = password;
        }

        /// <summary>
        /// User Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// User Firstname
        /// </summary>
        [JsonPropertyName("first_name")]
        public string Firstname { get; set; }

        /// <summary>
        /// User Lastname
        /// </summary>
        [JsonPropertyName("last_name")]
        public string Lastname { get; set; }

        /// <summary>
        /// User Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// User Password
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// User Profile Picture
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Picture { get; set; }

        /// <summary>
        /// User Username
        /// </summary>
        public string Username { get; set; }
    }
}
