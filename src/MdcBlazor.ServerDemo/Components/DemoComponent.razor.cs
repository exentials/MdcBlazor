using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exentials.MdcBlazor.ServerDemo.Components
{
    public partial class DemoComponent
    {
        [Parameter] public RenderFragment ChildContent { get; set; }
    }
}
