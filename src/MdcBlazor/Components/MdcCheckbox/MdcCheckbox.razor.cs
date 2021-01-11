using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exentials.MdcBlazor
{
    public partial class MdcCheckbox : MdcInputComponentBase<bool?>
    {
        [CascadingParameter(Name = "MdcTouchTargetWrapper")] bool Touchable { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            if (Touchable)
            {
                CssAttributes.Add("mdc-checkbox--touch");
            }
        }
    }
}
