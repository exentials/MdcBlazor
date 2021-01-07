using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exentials.MdcBlazor
{
    public partial class MdcIcon
    {
        [Parameter] public RenderFragment ChildContent { get; set; }
    }
}
