using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exentials.MdcBlazor
{
    public partial class MdcDataTableCell
    {
        [Parameter] public bool Header { get; set; }
        [Parameter] public bool Numeric { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            if (Numeric)
            {
                CssAttributes.Add("mdc-data-table__cell--numeric");
            }
        }
    }
}
