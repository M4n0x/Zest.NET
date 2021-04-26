using Blazored.SessionStorage;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zest.Net.Entities.Attributes;
using Zest.Net.Entities.Client;
using Zest.Net.Entities.Models;

namespace Zest.Net.Front.Helpers
{
    /// <summary>
    /// Zets custom Route View 
    /// </summary>
    public class AppRouteView : RouteView
    {
        /// <summary>
        /// NavigationManager to redirect
        /// </summary>
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        /// <summary>
        /// Zest client to check current User
        /// </summary>
        [Inject]
        public ZestClient Client { get; set; }

        /// <summary>
        /// Render a View
        /// </summary>
        /// <param name="builder">View Builder</param>
        protected override void Render(RenderTreeBuilder builder)
        {
            var authorize = Attribute.GetCustomAttribute(RouteData.PageType, typeof(AuthorizeAttribute)) != null;
            var onlyUnlogged = Attribute.GetCustomAttribute(RouteData.PageType, typeof(OnlyUnloggedAttribute)) != null;
            if (authorize && Client.Token == null)
            {
                NavigationManager.NavigateTo($"Login");
            }
            else if (onlyUnlogged && Client.Token != null)
            {
                NavigationManager.NavigateTo($"");
            }
            else
            {
                base.Render(builder);
            }
        }
    }
}
