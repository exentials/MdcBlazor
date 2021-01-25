using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exentials.MdcBlazor
{
    public partial class MdcMenuItem
    {
        [CascadingParameter] MdcMenuSelectionGroup MdcMenuSelectionGroup { get; set; }
        [Parameter] public string Label { get; set; }
        [Parameter] public bool Disabled { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            if (Disabled)
            {
                CssAttributes.Add("mdc-list-item--disabled");
            }
        }
    }
}
