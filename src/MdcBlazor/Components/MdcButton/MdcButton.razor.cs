using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace Exentials.MdcBlazor
{
    public partial class MdcButton : MdcButtonComponentBase
    {
        [CascadingParameter(Name = "MdcParentContainerType")] Type ParentContainerType { get; set; }
        [CascadingParameter(Name = "MdcTouchTargetWrapper")]  bool Touchable { get; set; }
        [Parameter] public MdcButtonType ButtonType { get; set; }
        [Parameter] public bool TrailingIcon { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            switch (ButtonType)
            {
                case MdcButtonType.Outlined: CssAttributes.Add("mdc-button--outlined"); break;
                case MdcButtonType.Contained: CssAttributes.Add("mdc-button--raised"); break;
                case MdcButtonType.Text:
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
