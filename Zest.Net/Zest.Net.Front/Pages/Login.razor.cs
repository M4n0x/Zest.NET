using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zest.Net.Entities.Exceptions;
using Zest.Net.Entities.Repositories;

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

        private string LoginError { get; set; } = "";

        private bool ShowLoginError => LoginError != "";

        private bool IsLoginButtonDeactivated => Username.Length == 0 || Password.Length < 6;

        private string Username { get; set; } = "";

        private string Password { get; set; } = "";

        /// <summary>
        /// Method fired on button login click
        /// </summary>
        /// <returns>Task</returns>
        private async Task PostLoginForm()
        {
            try
            {
                await AuthRepository.Login(Username, Password);
            }
            catch (Exception e)
            {
                LoginError = e.Message;
            }
        }
    }
}
