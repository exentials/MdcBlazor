using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Exentials.MdcBlazor
{
    public partial class MdcDataTablePaginationButton
    {
        [Parameter] public bool Disabled { get; set; }
        [Parameter] public string Icon { get; set; }
        
        [Parameter(CaptureUnmatchedValues = true)]
        public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }
        [Parameter] public EventCallback<EventArgs> OnClick { get; set; }

        [JSInvokable("click")]
        public Task Click()
        {
            if (OnClick.HasDelegate)
            {
                return OnClick.InvokeAsync();
            }
            return Task.CompletedTask;
        }
    }
}
