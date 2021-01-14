using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exentials.MdcBlazor
{
    public partial class DataTableColumnContainer
    {
        DataColumCollection _column;
        public DataColumCollection Columns
        {
            get
            {
                if (_column == null)
                {
                    _column = new DataColumCollection();
                }
                return _column;
            }
        }
        [Parameter] public DataTableSource DataSource { get; set; }
        [Parameter] public bool Selector { get; set; }

    }
}
