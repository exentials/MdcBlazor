using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exentials.MdcBlazor
{
    public partial class MdcSlider : MdcInputComponentBase<int>
    {
        int _valueStart;

        [Parameter] public MdcSliderType SliderType { get; set; }
        [Parameter] public int Min { get; set; }
        [Parameter] public int Max { get; set; } = 100;
        [Parameter] public int Step { get; set; } = 1;
        [Parameter] public int ValueStart { 
            get => _valueStart; 
            set
            {
                if (_valueStart != value)
                {
                    if (ValueStartChanged.HasDelegate)
                    {
                        _valueStart = value;
                        ValueStartChanged.InvokeAsync(_valueStart);
                        InvokeAsync(async () => await JSSetValueStart(_valueStart));
                    }
                }
            } 
        }
        [Parameter] public EventCallback<int> ValueStartChanged { get; set; }

        protected ValueTask<int> JSGetValueStart()
        {
            return JsInvokeAsync<int>("getValueStart");
        }

        protected ValueTask JSSetValueStart(int value)
        {
            return JsInvokeVoidAsync("setValueStart", value);
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            if (SliderType == MdcSliderType.Discrete)
            {
                CssAttributes.Add("mdc-slider--discrete");
            }
        }


        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);
            if (firstRender)
            {
                //await JSSetValueStart(ValueStart);
            }
        }
    }
}
