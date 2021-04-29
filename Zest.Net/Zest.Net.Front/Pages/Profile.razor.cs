using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Zest.Net.Entities.Client;
using Zest.Net.Entities.Models;
using Zest.Net.Entities.Repositories;

namespace Zest.Net.Front.Pages
{
    public partial class Profile
    {
        /// <summary>
        /// Authentication repository
        /// </summary>
        [Inject]
        public ZestClient Client { get; set; }

        /// <summary>
        /// Resources repository
        /// </summary>
        [Inject]
        public ResourcesHttpRepository ResourceRepository { get; set; }

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
        /// Session Storage
        /// </summary>
        [Inject]
        private ISyncSessionStorageService SessionStorage { get; set; }

        /// <summary>
        /// Firstname property
        /// </summary>
        private string Firstname { get; set; }

        /// <summary>
        /// Lastname property
        /// </summary>
        private string Lastname { get; set; }

        /// <summary>
        /// Email property
        /// </summary>
        private string Email { get; set; }

        /// <summary>
        /// Username property
        /// </summary>
        private string Username { get; set; }

        /// <summary>
        /// File property
        /// </summary>
        private IBrowserFile File { get; set; } = null;

        /// <summary>
        /// My Resources property
        /// </summary>
        private IEnumerable<Resource> Resources { get; set; } = new List<Resource>();

        /// <summary>
        /// Picture field
        /// </summary>
        private string _picture = null;

        /// <summary>
        /// Picture property
        /// </summary>
        private string Picture { get => _picture != null ? Picture : $"https://eu.ui-avatars.com/api/?name={Lastname}+{Firstname}&background=71945c&color=fff&rounded=true&format=svg&size=150"; }

        /// <summary>
        /// Define if register button must be activated
        /// </summary>
        private bool IsUpdateButtonDeactivated => Firstname.Length == 0 || Lastname.Length == 0;

        /// <summary>
        /// Method fired on initialization
        /// </summary>
        /// <returns>Task</returns>
        protected override async Task OnInitializedAsync()
        {
            Firstname = Client.CurrentUser.Firstname;
            Lastname = Client.CurrentUser.Lastname;
            Email = Client.CurrentUser.Email;
            Username = Client.CurrentUser.Username;
            _picture = Client.CurrentUser.Picture;

            Resources = await ResourceRepository.Get();
        }

        /// <summary>
        /// Post MyProfile form
        /// </summary>
        /// <returns>Task</returns>
        private async Task PostProfileForm()
        {

            var formContent = new MultipartFormDataContent
            {
                // Send form text values here
                {new StringContent(Firstname), "first_name"},
                {new StringContent(Lastname),"description" },
            };

            if (File != null)
            {
                formContent.Add(new StreamContent(File.OpenReadStream()), "picture", File.Name);
            }

            Client.CurrentUser.Lastname = Lastname;
            Client.CurrentUser.Firstname = Firstname;

            await AuthRepository.PatchProfile(formContent);
            SessionStorage.SetItem("User", Client.CurrentUser);
        }

        /// <summary>
        /// Handle file 
        /// </summary>
        /// <param name="e"></param>
        private void LoadPicture(InputFileChangeEventArgs e)
        {
            File = e.File;
        }
    }
}