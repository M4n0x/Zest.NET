﻿using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zest.Net.Entities.Client;
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
        /// Method fired on initialization
        /// </summary>
        /// <returns>Task</returns>
        protected override async Task OnInitializedAsync()
        {
            await AuthRepository.Login("lucas", "123123");

            var users = await UserRepo.Get();

            foreach (var user in users)
            {
                Console.WriteLine(user.Firstname);
            }
        }
    }
}
