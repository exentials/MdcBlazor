using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace Exentials.MdcBlazor
{
    public abstract class MdcButtonComponentBase : MdcComponentBase 
    {
        [Parameter] public string Title { get; set; }
        [Parameter] public string Label { get; set; }
        [Parameter] public string Icon { get; set; }
        [Parameter] public string TooltipId { get; set; }
        [Parameter] public string Command { get; set; }
        [Parameter] public bool Disabled { get; set; }
        [Parameter] public EventCallback<EventArgs> OnClick { get; set; }
        protected Task ClickHandler(EventArgs args)
        {
            return OnClick.InvokeAsync(args);
        }

    }
}
