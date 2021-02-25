using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace Exentials.MdcBlazor
{
    public partial class MdcTextarea
    {
        [Parameter] public bool Resizable { get; set; }

        [JSInvokable("MDCTextArea:change")]
        public override ValueTask TextChange(string value)
        {
            return Change(value);
        }
    }
}
