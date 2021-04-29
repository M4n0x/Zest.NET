using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Zest.Net.Entities.Client;
using Zest.Net.Entities.Models;

namespace Zest.Net.Entities.Repositories
{
    /// <summary>
    /// Auth Http repository used to contact token model
    /// </summary>
    public class AuthHttpRepository
    {
        /// <summary>
        /// Zest client
        /// </summary>
        private readonly ZestClient _client;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="client">Zest client</param>
        public AuthHttpRepository(ZestClient client)
        {
            _client = client;
        }

        /// <summary>
        /// Login request
        /// </summary>
        /// <param name="username">username property</param>
        /// <param name="password">password property</param>
        /// <returns>Task</returns>
        public virtual async Task Login(string username, string password)
        {
            await _client.Login(username, password);
        }

        public async Task PatchProfile(MultipartFormDataContent content)
        {
            await _client.RequestMultipart<object, object>("users/profile", HttpMethod.Patch, content);
        }

        /// <summary>
        /// Logout current user
        /// </summary>
        public void Logout()
        {
            _client.Logout();
        }

        /// <summary>
        /// Register request
        /// </summary>
        /// <param name="username">Username property</param>
        /// <param name="firstname">Firstname property</param>
        /// <param name="lastname">Lastname property</param>
        /// <param name="email">Email property</param>
        /// <param name="password">Password property</param>
        /// <returns>Task</returns>
        public virtual async Task Register(string username, string firstname, string lastname, string email, string password)
        {
            await _client.Register(username, firstname, lastname, email, password);
        }
    }
}
