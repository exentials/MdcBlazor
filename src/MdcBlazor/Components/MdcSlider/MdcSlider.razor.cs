using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exentials.MdcBlazor
{
    public partial class MdcSlider : MdcInputComponentBase<int>
    {
        [Parameter] public MdcSliderType SliderType { get; set; }
        [Parameter] public int Min { get; set; } = 0;
        [Parameter] public int Max { get; set; } = 100;
        [Parameter] public int Step { get; set; } = 5;
        [Parameter] public bool TickMark { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            if (SliderType == MdcSliderType.Discrete)
            {
                CssAttributes.Add("mdc-slider--discrete");
            }
            if (TickMark)
            {
                CssAttributes.Add("mdc-slider--tick-marks");
            }
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);
            if (firstRender)
            {
            }
        }

        [JSInvokable("MDCSlider:change")]
        public ValueTask MDCSliderChange(int value)
        {
            return Change(value);
        }

        [JSInvokable("MDCSlider:input")]
        public ValueTask MDCSliderInput(int value)
        {
            return Change(value);
        }

    }
}
