using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exentials.MdcBlazor
{
    public partial class MdcMenu
    {
        private bool _isOpen;
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
                    InvokeAsync(async () => await JsSetOpen(_isOpen));
                }
            }
        }
        [Parameter] public EventCallback<bool> IsOpenChanged { get; set; }
        [Parameter] public EventCallback<int> OnSelected { get; set; }
        [Parameter] public MdcMenuAnchorCorner AnchorCorner { get; set; }

        public void Open()
        {
            IsOpen = true;
        }

        public void Close()
        {
            IsOpen = false;
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);
            if (firstRender)
            {
                await JsSetOpen(IsOpen);
            }
            await JsSetAnchorCorner(AnchorCorner);
        }

        private ValueTask<bool> JSGetOpen()
        {
            return JsInvokeAsync<bool>("getOpen");
        }

        private ValueTask JsSetOpen(bool value)
        {
            return JsInvokeVoidAsync("setOpen", value);
        }

        private ValueTask JsSetAnchorCorner(MdcMenuAnchorCorner value)
        {
            return JsInvokeVoidAsync("setAnchorCorner", value);
        }

        public ValueTask SetFixedPosition(bool value)
        {
            return JsInvokeVoidAsync("setFixedPosition", value);
        }

        public ValueTask SetAbsolutePosition(int x, int y)
        {
            return JsInvokeVoidAsync("setAbsolutePosition", x, y);
        }
       
        [JSInvokable("MDCMenuSurface:closed")]
        public Task MDCMenuSurfaceClosed()
        {
            IsOpen = false;
            return Task.CompletedTask;
        }


        [JSInvokable("MDCMenu:selected")]
        public Task MDCMenuSelected(int index)
        {
            if (OnSelected.HasDelegate)
            {
                return OnSelected.InvokeAsync(index);
            }
            return Task.CompletedTask;
        }
    }
}
