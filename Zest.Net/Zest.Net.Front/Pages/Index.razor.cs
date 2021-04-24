using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zest.Net.Entities.Client;
using Zest.Net.Entities.Exceptions;
using Zest.Net.Entities.Repositories;

namespace Zest.Net.Front.Pages
{
    /// <summary>
    /// Index page
    /// </summary>
    public partial class Index
    {
        /// <summary>
        /// Authentication repository
        /// </summary>
        [Inject]
        public AuthHttpRepository AuthRepository { get; set; }

        /// <summary>
        /// User Repository
        /// </summary>
        [Inject]
        public UserHttpRepository UserRepo { get; set; }

        /// <summary>
        /// Resource Repository
        /// </summary>
        [Inject]
        public ResourcesHttpRepository ResourceRepo { get; set; }
    }
}
