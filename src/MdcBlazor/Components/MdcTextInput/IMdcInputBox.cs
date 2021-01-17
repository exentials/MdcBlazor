using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exentials.MdcBlazor
{
    public interface IMdcInputBox
    {
        bool Outlined { get; set; }
        bool Required { get; set; }
    }
}
