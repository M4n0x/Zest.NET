using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Zest.Net.Entities.Client;
using Zest.Net.Entities.Interfaces;
using Zest.Net.Entities.Models;

namespace Zest.Net.Entities.Repositories
{
    /// <summary>
    /// Resources Http repository
    /// </summary>
    public class ResourcesHttpRepository : GenericHttpRepository<Resource>
    {
        /// <summary>
        /// Resources Http repository constructor
        /// </summary>
        /// <param name="client">Zest client</param>
        public ResourcesHttpRepository(ZestClient client) : base(client)
        {
            // Nothing
        }
    }
}
