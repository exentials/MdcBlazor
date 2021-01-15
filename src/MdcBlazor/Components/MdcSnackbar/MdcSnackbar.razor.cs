using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exentials.MdcBlazor
{
    public partial class MdcSnackbar
    {
        [Parameter] public string Label { get; set; }
        [Parameter] public string ButtonLabel { get; set; }
        [Parameter] public bool Stacked { get; set; }
        [Parameter] public bool Leading { get; set; }
        [Parameter] public bool Dismissable { get; set; }
        [Parameter] public int Timeout { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            if (Stacked)
            {
                CssAttributes.Add("mdc-snackbar--stacked");
            }

            if (Leading)
            {
                CssAttributes.Add("mdc-snackbar--leading"); 
            }
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);
            if (firstRender)
            {
                await JsInvokeVoidAsync("timeoutMs", Timeout);
            }
        }

        public ValueTask Open()
        {
            return JsInvokeVoidAsync("open");
        }
    }
}
