using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exentials.MdcBlazor.ServerDemo.Components
{
    public partial class DemoComponent
    {
        [Parameter] public RenderFragment TopBar { get; set; }
        [Parameter] public RenderFragment Content { get; set; }
        [Parameter] public RenderFragment TopOption { get; set; }
        [Parameter] public RenderFragment Options { get; set; }
    }
}
