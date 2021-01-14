using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exentials.MdcBlazor
{
    public partial class MdcDataTableHeaderCell
    {
        [Parameter] public string Content { get; set; }
        [Parameter] public bool Numeric { get; set; }
        [Parameter] public bool Sortable { get; set; }
        [Parameter] public bool SortDescend { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            if (Numeric)
            {
                CssAttributes.Add("mdc-data-table__header-cell--numeric");
            }
            if (Sortable)
            {
                CssAttributes.Add("mdc-data-table__header-cell--with-sort");
                if (SortDescend)
                {
                    CssAttributes.Add("mdc-data-table__header-cell--sorted-descending");
                }else
                {
                    CssAttributes.Add("mdc-data-table__header-cell--sorted");
                }
            }
        }
    }
}
