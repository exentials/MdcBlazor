using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace Exentials.MdcBlazor
{
    public partial class MdcButton
    {
        [CascadingParameter(Name = "MdcParentContainerType")] protected Type ParentContainerType { get; set; }
        [CascadingParameter(Name = "MdcTouchTargetWrapper")] protected bool Touchable { get; set; }
        [Parameter] public MdcButtonStyle ButtonStyle { get; set; }
        [Parameter] public bool TrailingIcon { get; set; }

        protected override void OnInitialized()
        {
            switch (ButtonStyle)
            {
                case MdcButtonStyle.Outlined: CssAttributes.Add("mdc-button--outlined"); break;
                case MdcButtonStyle.Contained: CssAttributes.Add("mdc-button--raised"); break;
                case MdcButtonStyle.Text:
                    break;
            }
            if (ParentContainerType == typeof(MdcCardActions))
            {
                CssAttributes.Add("mdc-card__action", "mdc-card__action--button");
            }
            if (Touchable)
            {
                CssAttributes.Add("mdc-button--touch");
            }
        }

    }
}
