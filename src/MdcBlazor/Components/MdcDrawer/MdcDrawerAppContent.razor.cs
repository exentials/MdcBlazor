using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exentials.MdcBlazor
{
    public partial class MdcDrawerAppContent
    {
        [CascadingParameter] MdcTopAppBarContainer MdcTopAppBarContainer { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            if (Has(MdcTopAppBarContainer))
            {
                CssAttributes.Add("mdc-top-app-bar--fixed-adjust");
            }
        }
    }
}
