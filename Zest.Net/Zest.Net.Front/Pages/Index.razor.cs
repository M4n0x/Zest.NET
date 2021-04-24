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

        /// <summary>
        /// Method fired on initialization
        /// </summary>
        /// <returns>Task</returns>
        protected override async Task OnInitializedAsync()
        {
            try
            {
                //await AuthRepository.Register("lucas2", "Lulu", "Fridez", "lucas.fridez@ssyopmail.com", "123123");
                await AuthRepository.Login("lucas", "123123");
            } catch(RegisterZestException e)
            {
                Console.WriteLine(e.UsernameError);
                Console.WriteLine(e.EmailError);
                // Show error
            }

            //try
            //{
            //    await AuthRepository.Login("lucas", "123123");
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e);
            //}

            //var users = await UserRepo.Get();

            //foreach (var user in users)
            //{
            //    Console.WriteLine(user.Firstname);
            //}
        }
    }
}
