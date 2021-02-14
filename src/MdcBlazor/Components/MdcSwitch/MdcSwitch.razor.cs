using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exentials.MdcBlazor
{
    public partial class MdcSwitch : MdcInputComponentBase<bool>
    {

        [JSInvokable("MDCSwitch:change")]
        public ValueTask MDCCheckboxChange(bool value)
        {
            return Change(value);
        }
    }
}
