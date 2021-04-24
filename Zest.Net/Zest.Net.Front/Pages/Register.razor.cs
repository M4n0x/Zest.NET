using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zest.Net.Entities.Exceptions;
using Zest.Net.Entities.Repositories;
using Zest.Net.Front.Shared;

namespace Zest.Net.Front.Pages
{
    public partial class Register
    {
        /// <summary>
        /// Authentication repository
        /// </summary>
        [Inject]
        public AuthHttpRepository AuthRepository { get; set; }

        /// <summary>
        /// NavigationManager to redirect
        /// </summary>
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        /// <summary>
        /// Parent layout
        /// </summary>
        [CascadingParameter(Name = "UnloggedLayout")]
        public UnloggedLayout UnloggedLayout { get; set; }

        /// <summary>
        /// Register error text
        /// </summary>
        private string RegisterError { get; set; } = "";

        /// <summary>
        /// Define if register error must be shown
        /// </summary>
        private bool ShowRegisterError => RegisterError != "";

        /// <summary>
        /// Define if register button must be activated
        /// </summary>
        private bool IsRegisterButtonDeactivated => Username.Length == 0 || Password.Length < 6 || Firstname.Length == 0 || Lastname.Length == 0 || Email.Length == 0;

        /// <summary>
        /// Username property
        /// </summary>
        private string Username { get; set; } = "";

        /// <summary>
        /// Firstname property
        /// </summary>
        private string Firstname { get; set; } = "";

        /// <summary>
        /// Lastname property
        /// </summary>
        private string Lastname { get; set; } = "";

        /// <summary>
        /// Email property
        /// </summary>
        private string Email { get; set; } = "";

        /// <summary>
        /// Password property (with API)
        /// </summary>
        private string Password { get; set; } = "";

        /// <summary>
        /// Email error
        /// </summary>
        private string EmailError { get; set; } = "";

        /// <summary>
        /// Username error (with API)
        /// </summary>
        private string UsernameError { get; set; } = "";

        /// <summary>
        /// Method fired on button register click
        /// </summary>
        /// <returns>Task</returns>
        private async Task PostRegisterForm()
        {
            try
            {
                UnloggedLayout.ShowLoader();
                await AuthRepository.Register(Username, Firstname, Lastname, Email, Password);
                NavigationManager.NavigateTo($"Home");
            }
            catch (RegisterZestException e)
            {
                RegisterError = e.Message;
                EmailError = e.EmailError;
                UsernameError = e.UsernameError;
            }
            finally
            {
                UnloggedLayout.HideLoader();
            }
        }

        /// <summary>
        /// Remove Username error on keydown
        /// </summary>
        private void OnKeydownUsername()
        {
            UsernameError = UsernameError = "";
        }

        /// <summary>
        /// Remove email error on keydown
        /// </summary>
        private void OnKeydownEmail()
        {
            EmailError = EmailError = "";
        }
    }
}
