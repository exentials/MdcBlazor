using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exentials.MdcBlazor.ServerDemo.Components
{
    public partial class DemoComponentContainer
    {
        object objectKey = new Object();
        [Parameter] public RenderFragment ChildContent { get; set; }

        public void Refresh()
        {
            objectKey = new Object();
        }
    }
}
