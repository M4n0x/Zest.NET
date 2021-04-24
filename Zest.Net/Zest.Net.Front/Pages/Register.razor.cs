﻿using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zest.Net.Entities.Repositories;

namespace Zest.Net.Front.Pages
{
    public partial class Register
    {
        /// <summary>
        /// Authentication repository
        /// </summary>
        [Inject]
        public AuthHttpRepository AuthRepository { get; set; }

        private string RegisterError { get; set; } = "";

        private bool ShowRegisterError => RegisterError != "";

        private bool IsRegisterButtonDeactivated => Username.Length == 0 || Password.Length < 6 || Firstname.Length == 0 || Lastname.Length == 0 || Email.Length == 0;

        private string Username { get; set; } = "";

        private string Firstname { get; set; } = "";

        private string Lastname { get; set; } = "";

        private string Email { get; set; } = "";

        private string Password { get; set; } = "";

        /// <summary>
        /// Method fired on button register click
        /// </summary>
        /// <returns>Task</returns>
        private async Task PostRegisterForm()
        {
            try
            {
                await AuthRepository.Register(Username, Firstname, Lastname, Email, Password);
            }
            catch (Exception e)
            {
                RegisterError = e.Message;
            }
        }
    }
}
