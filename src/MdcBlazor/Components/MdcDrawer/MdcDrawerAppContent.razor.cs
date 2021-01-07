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
        [CascadingParameter(Name = "MdcTopAppBarFixed")] protected bool MdcTopAppBarFixed { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            if (MdcTopAppBarFixed)
            {
                CssAttributes.Add("mdc-top-app-bar--fixed-adjust");
            }
        }
    }
}
