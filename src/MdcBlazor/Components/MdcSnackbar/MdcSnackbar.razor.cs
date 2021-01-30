using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace Exentials.MdcBlazor
{
    public partial class MdcSnackbar : MdcComponentBase, ISnackbarOptions
    {
        [Parameter] public string Label { get; set; }
        [Parameter] public string ButtonLabel { get; set; }
        [Parameter] public bool Stacked { get; set; }
        [Parameter] public bool Leading { get; set; }
        [Parameter] public bool Dismissable { get; set; }
        [Parameter] public int Timeout { get; set; } = 5000;
        [Parameter] public EventCallback<string> OnClosed { get; set; }
        [Parameter] public object ButtonActionValue { get; set; }
        [Parameter] public EventCallback<object> OnButtonAction { get; set; }

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
                await SetTimeout(Timeout);
            }
        }

        public Task SetOptions(ISnackbarOptions options)
        {
            Label = options.Label;
            Dismissable = options.Dismissable;
            Timeout = options.Timeout;
            return InvokeAsync(StateHasChanged);
        }

        public ValueTask Open()
        {
            return JsInvokeVoidAsync("open");
        }

        public ValueTask SetTimeout(int timeout)
        {
            return JsInvokeVoidAsync("timeoutMs", timeout);
        }

        public ValueTask<bool> IsOpen()
        {
            return JsInvokeAsync<bool>("isOpen");
        }

        [JSInvokable("MDCSnackbar:closed")]
        public async ValueTask NativeClosed(string reason)
        {
            if ((reason == "action") && (OnButtonAction.HasDelegate))
            {
                await OnButtonAction.InvokeAsync(ButtonActionValue);
            }
            if (OnClosed.HasDelegate)
            {
                await OnClosed.InvokeAsync(reason);
            }
        }
    }
}
