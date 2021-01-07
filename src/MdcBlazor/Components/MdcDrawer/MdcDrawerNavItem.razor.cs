using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exentials.MdcBlazor
{
    public partial class MdcDrawerNavItem
    {
        [Inject] private NavigationManager NavigationManager { get; set; }
        [Parameter] public string Href { get; set; }
        [Parameter] public string Icon { get; set; }
        [Parameter] public bool Active { get; set; }
        [Parameter] public EventCallback<bool> ActiveChanged { get; set; }

        protected override void OnInitialized()
        {
            var uri = NavigationManager.Uri;
            if (Active)
            {
                CssAttributes.Add("mdc-list-item--activated");
            }
        }
    }
}
