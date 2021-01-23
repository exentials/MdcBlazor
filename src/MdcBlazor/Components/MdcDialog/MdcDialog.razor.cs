using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace Exentials.MdcBlazor
{
    public partial class MdcDialog
    {
        internal string TitleId { get; set; }
        private string _contentId { get; set; }
        private bool _isOpen;
        [Parameter] public RenderFragment Header { get; set; }
        [Parameter] public RenderFragment Content { get; set; }
        [Parameter] public RenderFragment Actions { get; set; }
        [Parameter]
        public bool IsOpen
        {
            get => _isOpen;
            set
            {
                if (_isOpen != value)
                {
                    _isOpen = value;
                    if (IsOpenChanged.HasDelegate)
                    {
                        IsOpenChanged.InvokeAsync(_isOpen);
                    }
                    InvokeAsync(async () => await JSSetOpen(_isOpen));
                }
            }
        }
        [Parameter] public EventCallback<bool> IsOpenChanged { get; set; }
        [Parameter] public EventCallback OnOpening { get; set; }
        [Parameter] public EventCallback OnOpened { get; set; }
        [Parameter] public EventCallback<string> OnClosing { get; set; }
        [Parameter] public EventCallback<string> OnClosed { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            if (Has(Content))
            {
                _contentId = MdcComponentHelper.CreateId();
            }
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);
            if (firstRender)
            {
                await JSSetOpen(IsOpen);
            }
        }

        private ValueTask JSSetOpen(bool value)
        {
            return JsInvokeVoidAsync("setOpen", value);
        }
        private ValueTask<bool> JSGetOpen()
        {
            return JsInvokeAsync<bool>("getOpen");
        }

        [JSInvokable("MDCDialog:opening")]
        public Task MDCDialogOpening()
        {
            if (OnOpening.HasDelegate)
            {
                return OnOpening.InvokeAsync();
            }
            return Task.CompletedTask;
        }

        [JSInvokable("MDCDialog:opened")]
        public Task MDCDialogOpened()
        {
            if (OnOpened.HasDelegate)
            {
                return OnOpened.InvokeAsync();
            }
            return Task.CompletedTask;
        }

        [JSInvokable("MDCDialog:closing")]
        public Task MDCDialogClosing(string action)
        {
            if (OnClosing.HasDelegate)
            {
                return OnClosing.InvokeAsync(action);
            }
            return Task.CompletedTask;
        }

        [JSInvokable("MDCDialog:closed")]
        public Task MDCDialogClosed(string action)
        {
            IsOpen = false;
            if (OnClosed.HasDelegate)
            {
                return OnClosed.InvokeAsync(action);
            }
            return Task.CompletedTask;
        }
    }
}
