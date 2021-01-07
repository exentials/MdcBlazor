using Microsoft.AspNetCore.Components;

namespace Exentials.MdcBlazor
{
    public abstract class MdcContainerComponentBase : MdcComponentBase
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }
    }
}
