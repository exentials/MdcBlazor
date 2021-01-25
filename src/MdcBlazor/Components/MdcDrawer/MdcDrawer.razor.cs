using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace Exentials.MdcBlazor
{
    public partial class MdcDrawer : MdcContainerComponentBase
    {
        private bool _open;

        [CascadingParameter(Name = "MdcTopAppBarFixed")] bool MdcTopAppBarFixed { get; set; }
        [CascadingParameter(Name = "MdcDrawerMode")] MdcDrawerType MdcDrawerType { get => DrawerType; set => DrawerType = value; }
        [Parameter] public MdcDrawerType DrawerType { get; set; }

        [Parameter]
        public bool Open
        {
            get { return _open; }
            set
            {
                if (_open != value)
                {
                    _open = value;
                    if (OpenChanged.HasDelegate)
                    {
                        OpenChanged.InvokeAsync(_open);
                    }
                    InvokeAsync(async () => await SetOpen(_open));
                }
            }
        }

        [Parameter] public EventCallback<bool> OpenChanged { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            if (MdcTopAppBarFixed)
            {
                CssAttributes.Add("mdc-top-app-bar--fixed-adjust");
            }

            switch (DrawerType)
            {
                case MdcDrawerType.Dismissible:
                    CssAttributes.Add("mdc-drawer--dismissible");
                    break;
                case MdcDrawerType.Modal:
                    CssAttributes.Add("mdc-drawer--modal");
                    break;
            }
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);
            if (firstRender)
            {
                await SetOpen(_open);
            }
        }

        private ValueTask<bool> JSGetOpen()
        {
            return JsInvokeAsync<bool>("getOpen");
        }

        private ValueTask SetOpen(bool value)
        {
            return JsInvokeVoidAsync("setOpen", value);
        }

        [JSInvokable("MDCDrawer:opened")]
        public Task MDCDrawerOpened()
        {
            Open = true;
            return Task.CompletedTask;
        }

        [JSInvokable("MDCDrawer:closed")]
        public Task MDCDrawerClosed()
        {
            Open = false;
            return Task.CompletedTask;
        }
    }
}
