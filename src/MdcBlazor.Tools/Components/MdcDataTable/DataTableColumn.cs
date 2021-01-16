using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exentials.MdcBlazor
{
    public class DataTableColumn : MdcComponentBase
    {
        [CascadingParameter] DataColumCollection Columns { get; set; }
        [Parameter] public string Header { get; set; }
        [Parameter] public string FieldName { get; set; }
        [Parameter] public string Format { get; set; }
        [Parameter] public bool Numeric { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            if (Columns != null)
            {
                Columns.Add(new DataColumn { 
                    Header = Header,
                    FieldName = FieldName,
                    Format = Format,
                    Numeric = Numeric
                });
            }
        }
    }
}
