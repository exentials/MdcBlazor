using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exentials.MdcBlazor
{
    public partial class MdcCardActions
    {
        [Parameter] public bool FullBleed { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            if (FullBleed)
            {
                CssAttributes.Add("mdc-card__actions--full-bleed");
            }
        }
    }
}
