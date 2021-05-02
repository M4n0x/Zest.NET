using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Zest.Net.Front.Shared
{
    /// <summary>
    /// Unlogged code behind partial class
    /// </summary>
    public partial class UnloggedLayout
    {
        /// <summary>
        /// Loader class to apply to loader div
        /// </summary>
        private string LoaderClass { get; set; } = "hide";

        /// <summary>
        /// Show Loader
        /// </summary>
        public void ShowLoader()
        {
            LoaderClass = "";
        }

        /// <summary>
        /// Hide loader
        /// </summary>
        public void HideLoader()
        {
            LoaderClass = "hide";
        }
    }
}
