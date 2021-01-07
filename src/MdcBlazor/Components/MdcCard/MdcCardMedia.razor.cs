using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exentials.MdcBlazor
{
    public partial class MdcCardMedia
    {
        [Parameter] public string Title { get; set; }
        [Parameter] public string CssMedia { get; set; }
        [Parameter] public bool SixteenNine { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            if (!string.IsNullOrEmpty(CssMedia))
            {
                CssAttributes.Add(CssMedia);
            }
            if (SixteenNine)
            {
                CssAttributes.Add("mdc-card__media--16-9");
            }
        }
    }
}
