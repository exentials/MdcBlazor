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
        [Parameter] public bool IsOpen 
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
        [Parameter] public EventCallback<int> OnSelected { get; set; }

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
                await JSSetOpen(IsOpen);
            }
        }

        private ValueTask<bool> JSGetOpen()
        {
            return JsInvokeAsync<bool>("getOpen");
        }

        private ValueTask JSSetOpen(bool value)
        {
            return JsInvokeVoidAsync("setOpen", value);
        }

        public ValueTask SetFixedPosition(bool value)
        {
            return JsInvokeVoidAsync("setFixedPosition", value);
        }

        public ValueTask SetAbsolutePosition(int x,int y)
        {
            return JsInvokeVoidAsync("setAbsolutePosition", x,y);
        }        

        [JSInvokable("MDCMenu:selected")]
        public Task MDCMenuSelected(int index)
        {
            _isOpen = false;
            if (OnSelected.HasDelegate)
            {
                return OnSelected.InvokeAsync(index);
            }
            return Task.CompletedTask;
        }
    }
}
