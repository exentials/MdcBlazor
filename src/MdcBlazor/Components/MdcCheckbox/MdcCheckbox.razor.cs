using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exentials.MdcBlazor
{
    public partial class MdcCheckbox : MdcInputComponentBase<bool?>
    {
        [CascadingParameter(Name = "MdcTouchTargetWrapper")] protected bool Touchable { get; set; }
        [Parameter] public string Label { get; set; }
        [Parameter] public bool Indeterminate { get; set; }
        [Parameter] public bool Disabled { get; set; }

        private string IndeterminateString
        {
            get { return (Indeterminate && (Value == null)) ? "true" : null; }
        }

        private async Task InputChangeHandler()
        {
            Indeterminate = await GetIndeterminate();
            Value = await GetInputValue();
        }

        private ValueTask<bool> GetIndeterminate()
        {
            return JsInvokeAsync<bool>("getIndeterminate");
        }

        private ValueTask SetIndeterminate(bool value)
        {
            return JsInvokeVoidAsync("setIndeterminate", value);
        }

        private ValueTask<bool> GetChecked()
        {
            return JsInvokeAsync<bool>("getChecked");
        }

        private ValueTask SetChecked(bool value)
        {
            return JsInvokeVoidAsync("setChecked", value);
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            if (Disabled)
            {
                CssAttributes.Add("mdc-checkbox--disabled");
            }
            if (Touchable)
            {
                CssAttributes.Add("mdc-checkbox--touch");
            }
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);
            if (firstRender)
            {
                await SetInputValue(Value);
            }
        }

        protected override async ValueTask<bool?> GetInputValue()
        {
            return (await GetIndeterminate()) ? null : await GetChecked();
        }

        protected override async ValueTask SetInputValue(bool? value)
        {
            bool? inputValue = await GetInputValue();
            if (inputValue != value)
            {
                if (value.HasValue)
                {
                    await SetChecked(value.Value);
                }
                else
                {
                    await SetIndeterminate(true);
                    await SetChecked(false);
                }
            }
        }

    }
}
