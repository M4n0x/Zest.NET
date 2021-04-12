using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Zest.Net.Entities.Client;
using Zest.Net.Entities.Interfaces;
using Zest.Net.Entities.Models;

namespace Zest.Net.Entities.Repositories
{
    public class UserHttpRepository : IGenericHttpRepository<User>
    {
        private readonly ZestClient _client;

        public UserHttpRepository(ZestClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<User>> Get()
        {
            Console.WriteLine(_client.Token);
            return await _client.Get<User>("users");
        }
    }
}
