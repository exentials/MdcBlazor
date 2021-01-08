using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exentials.MdcBlazor
{
    internal static class MdcComponentHelper
    {

        public static string CreateId()
        {
            return $"_mdc_{Guid.NewGuid()}";
        }

    }
}
