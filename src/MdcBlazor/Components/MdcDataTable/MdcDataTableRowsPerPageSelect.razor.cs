using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exentials.MdcBlazor
{
    public partial class MdcDataTableRowsPerPageSelect
    {
        private string _paginationSelectId = MdcComponentHelper.CreateId();

        private int _pageSize;

        [Parameter] public int Value {
            get => _pageSize;
            set
            {
                if (_pageSize != value)
                {
                    _pageSize = value;
                    if (ValueChanged.HasDelegate)
                    {
                        ValueChanged.InvokeAsync(_pageSize);
                    }
                }
            } 
        }
        [Parameter] public EventCallback<int> ValueChanged { get; set; }

        [JSInvokable("MDCSelect:change")]
        public ValueTask MDCSelectChange(string value)
        {
            Value = Convert.ToInt32(value);
            return ValueTask.CompletedTask;
        }
    }
}
