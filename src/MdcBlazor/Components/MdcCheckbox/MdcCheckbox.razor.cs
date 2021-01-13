﻿using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace Exentials.MdcBlazor
{
    public partial class MdcCheckbox : MdcInputComponentBase<bool?>
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
    }
}
