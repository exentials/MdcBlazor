using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exentials.MdcBlazor
{
    public class DataTableSource
    {
        private IEnumerable _data;
        public DataTableSource(IEnumerable data)
        {
            _data = data;
        }

        public IEnumerable Rows
        {
            get
            {
                return _data;
            }
        }
    }
}
