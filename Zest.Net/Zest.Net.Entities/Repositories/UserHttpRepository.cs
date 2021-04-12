using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Zest.Net.Entities.Client;
using Zest.Net.Entities.Interfaces;
using Zest.Net.Entities.Models;

namespace Zest.Net.Entities.Repositories
{
    public class UserHttpRepository : GenericHttpRepository<User>
    {
        public UserHttpRepository(ZestClient client) : base(client)
        {

        }
    }
}
