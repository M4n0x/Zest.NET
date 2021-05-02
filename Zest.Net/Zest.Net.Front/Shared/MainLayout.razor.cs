using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zest.Net.Entities.Client;

namespace Zest.Net.Front.Shared
{
    /// <summary>
    /// Partial class MainLayout
    /// </summary>
    public partial class MainLayout
    {
        /// <summary>
        /// Zest client to check current User
        /// </summary>
        [Inject]
        public ZestClient Client { get; set; }
    }
}
