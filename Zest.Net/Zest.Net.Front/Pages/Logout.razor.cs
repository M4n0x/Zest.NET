using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zest.Net.Entities.Repositories;

namespace Zest.Net.Front.Pages
{
    public partial class Logout
    {
        /// <summary>
        /// Authentication repository
        /// </summary>
        [Inject]
        public AuthHttpRepository AuthRepository { get; set; }

        /// <summary>
        /// Session Storage
        /// </summary>
        [Inject]
        private ISyncSessionStorageService SessionStorage { get; set; }

        /// <summary>
        /// On Initialized event, automatically logout current user
        /// </summary>
        protected override void OnInitialized()
        {
            AuthRepository.Logout();
            SessionStorage.RemoveItem("Token");
            SessionStorage.RemoveItem("User");
        }
    }
}
