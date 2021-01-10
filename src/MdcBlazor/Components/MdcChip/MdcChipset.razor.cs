using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exentials.MdcBlazor
{
    public partial class MdcChipset : MdcContainerComponentBase
    {
        [Parameter] public MdcChipsetType Type { get; set; }
        protected string TrailingIcon { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            switch (Type)
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
                    TrailingIcon = MdcIcons.Cancel;
                    break;
                case MdcChipsetType.Action:
                    break;
            }
        }
    }
}
