using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exentials.MdcBlazor
{
    public partial class MdcSwitch : MdcInputComponentBase<bool>
    {
        protected override ValueTask<bool>JSGetInputValue()
        {
            return JsInvokeAsync<bool>("getChecked");
        }

        protected override ValueTask JSSetInputValue(bool value)
        {
            return JsInvokeVoidAsync("setChecked",value);
        }

        protected override ValueTask<bool> JSGetDisabled()
        {
            return JsInvokeAsync<bool>("getDisabled");
        }

        protected override ValueTask JSSetDisabled(bool value)
        {
            return JsInvokeVoidAsync("setDisabled", value);
        }
    }
}
