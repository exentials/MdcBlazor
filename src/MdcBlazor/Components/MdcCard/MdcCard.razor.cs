using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exentials.MdcBlazor
{
    public partial class MdcCard
    {
        [Parameter] public string CssCard { get; set; }
        [Parameter] public bool Outlined { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            if (!string.IsNullOrEmpty(CssCard))
            {
                CssAttributes.Add(CssCard);
            }
            if (Outlined)
            {
                CssAttributes.Add("mdc-card--outlined");
            }
        }
    }
}