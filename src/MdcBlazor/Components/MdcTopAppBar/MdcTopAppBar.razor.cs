using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exentials.MdcBlazor
{
    public partial class MdcTopAppBar
    {
        private readonly CssAttributes CssClassAdjustAttributes = new CssAttributes();
        [CascadingParameter(Name = "MdcTopAppBarFixed")] bool MdcTopAppBarFixed { get => Fixed; set => Fixed = value; }
        [Parameter] public bool Fixed { get; set; }
        [Parameter] public EventCallback OnNavToggle { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            if (Fixed)
            {
                CssAttributes.Add("mdc-top-app-bar--fixed");
            }
        }

        [JSInvokable("MDCTopAppBar:nav")]
        public Task MDCTopAppBarNav()
        {
            if (OnNavToggle.HasDelegate)
            {
                return OnNavToggle.InvokeAsync();
            }
            return Task.CompletedTask;
        }

    }
}
