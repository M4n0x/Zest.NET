using Zest.Net.Entities.Client;
using Zest.Net.Entities.Models;

namespace Zest.Net.Entities.Repositories
{
    /// <summary>
    /// User Http repository
    /// </summary>
    public class UserHttpRepository : GenericHttpRepository<User>
    {
        /// <summary>
        /// User Http Repository constructor
        /// </summary>
        /// <param name="client">Zest client</param>
        public UserHttpRepository(ZestClient client) : base(client)
        {
            // Nothing
        }
    }
}
