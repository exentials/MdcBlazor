using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace Exentials.MdcBlazor
{
    public abstract class MdcInputTextComponentBase : MdcInputComponentBase<string>
    {
        [Parameter] public bool Outlined { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            if (Disabled)
            {
                CssAttributes.Add("mdc-text-field--disabled");
            }
        }

        protected override ValueTask<string> GetInputValue()
        {
            return JsInvokeAsync<string>("getValue");
        }

        protected override ValueTask SetInputValue(string value)
        {
            return JsInvokeVoidAsync("setValue", value);
        }
    }
}
