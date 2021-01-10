using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exentials.MdcBlazor
{
    public partial class MdcTab
    {
        [CascadingParameter(Name = "MdcTabStacked")] bool MdcTabStacked { get; set; }
        [Parameter] public string Icon { get; set; }
        [Parameter] public string Label { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            if (MdcTabStacked)
            {
                CssAttributes.Add("mdc-tab--stacked");
            }
        }
    }
}
