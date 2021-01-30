using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exentials.MdcBlazor
{
    public partial class MdcTabBar
    {
        private int _activeTab;
        [Parameter] public int ActiveTab { 
            get => _activeTab; 
            set
            {
                if (_activeTab != value)
                {
                    _activeTab = value;
                    if (ActiveTabChanged.HasDelegate)
                    {
                        ActiveTabChanged.InvokeAsync(_activeTab);
                    }
                    InvokeAsync(async () => await JsActivateTab(_activeTab));
                }
            } 
        }
        [Parameter] public EventCallback<int> ActiveTabChanged { get; set; }
        [Parameter] public bool Stacked { get; set; }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);
            if (firstRender)
            {
                await JsActivateTab(ActiveTab);
            }
        }

        private ValueTask JsActivateTab(int index)
        {
            return JsInvokeVoidAsync("activateTab", index);
        }

        [JSInvokable("MDCTabBar:activated")]
        public ValueTask ChangeTab(int index)
        {             
            if (index != ActiveTab)
            {
                ActiveTab = index;
            }
            return ValueTask.CompletedTask;
        }
    }
}
