using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exentials.MdcBlazor
{
    public class PageChangeEventArgs : EventArgs
    {
        public PageChangeEventArgs(int page, int pageSize)
        {
            Page = page;
            PageSize = pageSize;
        }

        public int Page { get; private set; }
        public int PageSize { get; private set; }
    }
}
