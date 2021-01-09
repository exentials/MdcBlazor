using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exentials.MdcBlazor
{
    public partial class MdcChip
    {
        [CascadingParameter(Name = "MdcChipsetType")] protected MdcChipsetType MdcChipsetType { get; set; }
        [CascadingParameter(Name = "MdcChipTrailingIcon")] protected string TrailingIcon { get; set; }
        [Parameter] public bool Selected { get; set; }
        [Parameter] public string LeadingIcon { get; set; }
        [Parameter] public string Text { get; set; }

        private Dictionary<string, object> PrimaryActionAttributes { get; set; } = new Dictionary<string, object>();

        protected override void OnInitialized()
        {
            base.OnInitialized();
            switch (MdcChipsetType)
            {
                case MdcChipsetType.None:
                    break;
                case MdcChipsetType.Choice:
                    CssAttributes.Add("mdc-chip-set--choice");
                    PrimaryActionAttributes.Add("role", "option");
                    break;
                case MdcChipsetType.Filter:
                    CssAttributes.Add("mdc-chip-set--filter");
                    PrimaryActionAttributes.Add("role", "checkbox");
                    break;
                case MdcChipsetType.Input:
                    CssAttributes.Add("mdc-chip-set--input");
                    TrailingIcon = MdcIcons.Cancel;
                    break;
                case MdcChipsetType.Action:
                    PrimaryActionAttributes.Add("role", "button");
                    break;
            }
        }
    }
}
