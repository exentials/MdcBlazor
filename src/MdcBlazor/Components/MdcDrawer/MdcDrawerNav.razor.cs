using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exentials.MdcBlazor
{
    public partial class MdcDrawerNav
    {
        [Parameter] public EventCallback OnAction { get; set; }


        [JSInvokable("MDCList:action")]
        public Task MDCListAction(int index)
        {
            if (OnAction.HasDelegate)
            {
                return OnAction.InvokeAsync();
            }
            return Task.CompletedTask;
        }
    }
}
