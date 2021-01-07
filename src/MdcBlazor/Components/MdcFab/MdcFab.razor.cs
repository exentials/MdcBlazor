using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace Exentials.MdcBlazor
{
    public partial class MdcFab
    {
        [CascadingParameter(Name = "MdcTouchTargetWrapper")] protected bool Touchable { get; set; }
        [Parameter] public MdcFabStyle Style { get; set; }
        [Parameter] public RenderFragment ChildContent { get; set; }
        [Parameter] public bool Exited { get; set; }

        protected override void OnInitialized()
        {
            switch (Style)
            {
                case MdcFabStyle.Regular:
                    break;
                case MdcFabStyle.Mini:
                    CssAttributes.Add("mdc-fab--mini");
                    break;
                case MdcFabStyle.Extended:
                    CssAttributes.Add("mdc-fab--extended");
                    break;
            }
            if (Touchable)
            {
                CssAttributes.Add("mdc-fab--touch");
            }
            if (Exited)
            {
                CssAttributes.Add("mdc-fab--exited");
            }
            base.OnInitialized();
        }

    }
}
