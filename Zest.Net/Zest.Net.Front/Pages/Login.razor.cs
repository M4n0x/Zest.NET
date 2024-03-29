﻿using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zest.Net.Entities.Client;
using Zest.Net.Entities.Exceptions;
using Zest.Net.Entities.Models;
using Zest.Net.Entities.Repositories;
using Zest.Net.Front.Shared;

namespace Zest.Net.Front.Pages
{
    /// <summary>
    /// Index page
    /// </summary>
    public partial class Login
    {
        /// <summary>
        /// Authentication repository
        /// </summary>
        [Inject]
        public AuthHttpRepository AuthRepository { get; set; }

        /// <summary>
        /// Zest client to check current User
        /// </summary>
        [Inject]
        public ZestClient Client { get; set; }

        /// <summary>
        /// Session Storage
        /// </summary>
        [Inject]
        private ISyncSessionStorageService SessionStorage { get; set; }

        /// <summary>
        /// NavigationManager to redirect
        /// </summary>
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        /// <summary>
        /// Unlogged Parent layout
        /// </summary>
        [CascadingParameter(Name = "UnloggedLayout")]
        public UnloggedLayout UnloggedLayout { get; set; }

        /// <summary>
        /// Login error text
        /// </summary>
        private string LoginError { get; set; } = "";

        /// <summary>
        /// Define if Login error must be shown
        /// </summary>
        private bool ShowLoginError => LoginError != "";

        /// <summary>
        /// Define if Login button must be activated
        /// </summary>
        private bool IsLoginButtonDeactivated => Username.Length == 0 || Password.Length < 6;

        /// <summary>
        /// Username property
        /// </summary>
        private string Username { get; set; } = "";

        /// <summary>
        /// Password property
        /// </summary>
        private string Password { get; set; } = "";

        /// <summary>
        /// Method fired on button login click
        /// </summary>
        /// <returns>Task</returns>
        private async Task PostLoginForm()
        {
            try
            {
                UnloggedLayout.ShowLoader();
                await AuthRepository.Login(Username, Password);
                SessionStorage.SetItem("Token", Client.Token);
                SessionStorage.SetItem("User", Client.CurrentUser);
                NavigationManager.NavigateTo("");
            }
            catch (Exception e)
            {
                LoginError = e.Message;
            }
            finally
            {
                UnloggedLayout.HideLoader();
            }
        }
    }
}
