using Microsoft.AspNetCore.Components;

namespace Exentials.MdcBlazor
{
    public partial class MdcChipset : MdcContainerComponentBase
    {
        [Parameter] public MdcChipsetType ChipsetType { get; set; }
        [Parameter] public string TrailingIcon { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            switch (ChipsetType)
            {
                case MdcChipsetType.None:
                    break;
                case MdcChipsetType.Choice:
                    CssAttributes.Add("mdc-chip-set--choice");
                    break;
                case MdcChipsetType.Filter:
                    CssAttributes.Add("mdc-chip-set--filter");
                    break;
                case MdcChipsetType.Input:
                    CssAttributes.Add("mdc-chip-set--input");
                    if (TrailingIcon == null)
                    {
                        TrailingIcon = MdcIcons.Cancel;
                    }
                    break;
                case MdcChipsetType.Action:
                    break;
            }
        }

    }
}
