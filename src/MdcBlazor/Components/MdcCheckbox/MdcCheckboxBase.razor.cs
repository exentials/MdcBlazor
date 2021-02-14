using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace Exentials.MdcBlazor
{
    public abstract partial class MdcCheckboxBase<TValue> : MdcInputComponentBase<TValue>
    {
        private readonly string _inputId = MdcComponentHelper.CreateId();
        private MdcComponentBase FormField { get; set; }

        [Parameter] public bool AlignEnd { get; set; }
        [Parameter] public bool NoWrap { get; set; }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);
            if (firstRender)
            {
                if (FormField != null)
                {
                    await JsInvokeVoidAsync("initFormField", FormField.Ref);
                }
            }
        }

        [JSInvokable("MDCCheckbox:change")]
        public ValueTask MDCCheckboxChange(TValue value)
        {
            return Change(value);
        }

    }
}
