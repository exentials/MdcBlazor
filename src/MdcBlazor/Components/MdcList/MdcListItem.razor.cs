using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exentials.MdcBlazor
{
    public partial class MdcListItem : MdcComponentBase
    {
        [Parameter] public string Value { get; set; }
        [Parameter] public string Label { get; set; }
        [Parameter] public string SecondaryLabel { get; set; }
    }
}
