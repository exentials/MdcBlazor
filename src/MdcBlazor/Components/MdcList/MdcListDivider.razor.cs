using Microsoft.AspNetCore.Components;

namespace Exentials.MdcBlazor
{
    public partial class MdcListDivider
    {
        [CascadingParameter] MdcList MdcList { get; set; }
    }
}
