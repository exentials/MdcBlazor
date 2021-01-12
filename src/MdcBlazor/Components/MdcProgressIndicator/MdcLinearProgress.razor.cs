using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exentials.MdcBlazor
{
    public partial class MdcLinearProgress : MdcProgressIndicatorBase
    {
        [Parameter] public bool Reverse { get; set; }

        protected ValueTask JSSetReverse(bool value)
        {
            return JsInvokeVoidAsync("setReverse", value);
        }        

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);
            if (firstRender)
            {
                await JSSetReverse(Reverse);
            }
        }

    }
}
