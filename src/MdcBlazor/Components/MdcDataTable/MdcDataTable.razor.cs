using Microsoft.AspNetCore.Components;
using System.Collections.Generic;

namespace Exentials.MdcBlazor
{
    public partial class MdcDataTable : MdcContainerComponentBase
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
        [Parameter] public bool Selector { get; set; }
        [Parameter] public string Label { get; set; }
        [Parameter] public DataTableSource DataSource { get; set; }

    }
}