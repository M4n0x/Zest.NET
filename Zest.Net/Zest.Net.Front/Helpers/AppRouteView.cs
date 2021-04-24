using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zest.Net.Entities.Client;

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
            if (authorize && Client.Token != null)
            {
                NavigationManager.NavigateTo($"login");
            }
            else
            {
                base.Render(builder);
            }
        }
    }
}
