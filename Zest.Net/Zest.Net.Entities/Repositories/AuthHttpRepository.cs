using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Zest.Net.Entities.Client;
using Zest.Net.Entities.Models;

namespace Zest.Net.Entities.Repositories
{
    class AuthHttpRepository
    {
        /// <summary>
        /// Zest client
        /// </summary>
        private readonly ZestClient _client;

        public virtual async Task Login(string username, string password)
        {
            await _client.Login(username, password);
        }

        public virtual async Task Register(string username, string firstname, string lastname, string email, string password)
        {
            await _client.Register(username, firstname, lastname, email, password);
        }
    }
}
