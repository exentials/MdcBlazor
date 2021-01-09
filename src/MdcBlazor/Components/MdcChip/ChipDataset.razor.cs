using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exentials.MdcBlazor
{
    public partial class ChipDataset
    {
        [Parameter] public IEnumerable<Chip> DataSource { get; set; }
    }
}
