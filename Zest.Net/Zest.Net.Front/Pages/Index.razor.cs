using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zest.Net.Entities.Client;
using Zest.Net.Entities.Repositories;

namespace Zest.Net.Front.Pages
{
    public partial class Index
    {
        [Inject]
        public ZestClient Http { get; set; }

        [Inject]
        public UserHttpRepository UserRepo { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await Http.Login("lucas", "123123");

            var users = await UserRepo.Get();

            foreach (var user in users)
            {
                Console.WriteLine(user.Firstname);
            }
        }
    }
}
