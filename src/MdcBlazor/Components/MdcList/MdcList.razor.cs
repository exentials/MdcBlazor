using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace Exentials.MdcBlazor
{
    public partial class MdcList
    {
        private int _selectedIndex = -1;

        [Parameter] public bool Dense { get; set; }
        [Parameter] public bool TwoLine { get; set; }
        [Parameter] public bool SingleSelection { get; set; }
        [Parameter] public int SelectedIndex { 
            get => _selectedIndex; 
            set
            {
                if (_selectedIndex != value)
                {
                    _selectedIndex = value;
                    if (SelectedIndexChanged.HasDelegate)
                    {
                        SelectedIndexChanged.InvokeAsync(_selectedIndex);
                    }
                    InvokeAsync(async () => await JSSetSelectedIndex(_selectedIndex));
                }
            }
        }
        [Parameter] public EventCallback<int> SelectedIndexChanged { get; set; }


        protected override void OnInitialized()
        {
            base.OnInitialized();
            if (Dense)
            {
                CssAttributes.Add("mdc-list--dense");
            }
            if (TwoLine)
            {
                CssAttributes.Add("mdc-list--two-line");
            }
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);
            if (firstRender)
            {
                await JSSetSingleSelection(SingleSelection);
                if (SelectedIndex > -1)
                {
                    await JSSetSelectedIndex(SelectedIndex);
                }
            }
        }

        private ValueTask JSSetSingleSelection(bool value)
        {
            return JsInvokeVoidAsync("setSingleSelection", value);
        }
        private ValueTask<int> JSSetSelectedIndex()
        {
            return JsInvokeAsync<int>("getSelectedIndex");
        }

        private ValueTask JSSetSelectedIndex(int value)
        {
            return JsInvokeVoidAsync("setSelectedIndex", value);
        }

        [JSInvokable("MDCList:action")]
        public ValueTask ListAction(int index)
        {
            if (SelectedIndex != index)
            {
                SelectedIndex = index;
                StateHasChanged();
            }
            return ValueTask.CompletedTask;
        }

    }
}
