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
        [Parameter] public int Min { get; set; } = 0;
        [Parameter] public int Max { get; set; } = 100;
        [Parameter] public int Step { get; set; } = 1;

        protected override void OnInitialized()
        {
            base.OnInitialized();
            if (SliderType == MdcSliderType.Discrete)
            {
                CssAttributes.Add("mdc-slider--discrete");
            }
        }

    }
}
