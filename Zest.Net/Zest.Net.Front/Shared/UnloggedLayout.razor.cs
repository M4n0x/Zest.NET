using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Zest.Net.Front.Shared
{
    public partial class UnloggedLayout
    {

        private string LoaderClass { get; set; } = "hide";

        public void ShowLoader()
        {
            LoaderClass = "";
        }

        public void HideLoader()
        {
            LoaderClass = "hide";
        }
    }
}
