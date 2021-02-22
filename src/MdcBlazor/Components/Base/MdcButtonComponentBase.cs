using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace Exentials.MdcBlazor
{
    public abstract class MdcButtonComponentBase : MdcComponentBase
    {
        private bool _disabled;
        [Parameter] public string Title { get; set; }
        [Parameter] public string Label { get; set; }
        [Parameter] public string Icon { get; set; }
        [Parameter] public string TooltipId { get; set; }
        [Parameter] public string Command { get; set; }
        [Parameter]
        public bool Disabled
        {
            get => _disabled;
            set
            {
                if (_disabled != value)
                {
                    _disabled = value;
                    InvokeAsync(async () => await JSSetDisabled(_disabled));
                }
            }
        }

        [Parameter] public EventCallback<EventArgs> OnClick { get; set; }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);
            if (firstRender)
            {
                await JSSetDisabled(Disabled);
            }
        }

        [JSInvokable("click")]
        public Task Click()
        {
            if (OnClick.HasDelegate)
            {
                return OnClick.InvokeAsync();
            }
            return Task.CompletedTask;
        }

        protected ValueTask<bool> JSGetDisabled()
        {
            return JsInvokeAsync<bool>("getDisabled");
        }

        protected ValueTask JSSetDisabled(bool value)
        {
            return JsInvokeVoidAsync("setDisabled", value);
        }

    }
}
