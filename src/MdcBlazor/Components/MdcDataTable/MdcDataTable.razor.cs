using Microsoft.AspNetCore.Components;
using System.Collections.Generic;

namespace Exentials.MdcBlazor
{
    public partial class MdcDataTable : MdcContainerComponentBase
    {
        [Parameter] public string Label { get; set; }
        [Parameter] public bool Sticky { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            if (Sticky)
            {
                CssAttributes.Add("mdc-data-table--sticky-header");
            }
        }
    }
}