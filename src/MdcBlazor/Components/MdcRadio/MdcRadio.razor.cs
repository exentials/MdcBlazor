using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Exentials.MdcBlazor
{
    public partial class MdcRadio : MdcInputComponentBase<string>
    {
        private readonly string _inputId = MdcComponentHelper.CreateId();
        private MdcComponentBase FormField { get; set; }
        private bool _checked;

        [Parameter] public string Name { get; set; }
        [Parameter] public bool AlignEnd { get; set; }
        [Parameter]
        public bool Checked
        {
            get => _checked;
            set
            {
                if (_checked != value)
                {
                    _checked = value;
                    if (CheckedChanged.HasDelegate)
                    {
                        CheckedChanged.InvokeAsync(_checked);
                    }
                    InvokeAsync(async () => await JSSetChecked(_checked));
                }
            }
        }
        [Parameter] public EventCallback<bool> CheckedChanged { get; set; }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);
            if (firstRender)
            {
                if (FormField != null)
                {
                    await JsInvokeVoidAsync("initFormField", FormField.Ref);
                }
                await JSSetChecked(Checked);
            }
        }

        protected ValueTask<bool> JSGetChecked()
        {
            return JsInvokeAsync<bool>("getChecked");
        }

        protected ValueTask JSSetChecked(bool value)
        {
            return JsInvokeVoidAsync("setChecked", value);
        }

        [JSInvokable("NativeChange:checked")]
        public ValueTask NativeChange(string value, bool isChecked)
        {
            if (Checked != isChecked)
            {
                Checked = isChecked;
                StateHasChanged();
            }
            return NativeChange(value);
        }
    }
}
