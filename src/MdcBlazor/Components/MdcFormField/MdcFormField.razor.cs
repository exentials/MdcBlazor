using Microsoft.AspNetCore.Components;

namespace Exentials.MdcBlazor
{
    public partial class MdcFormField : MdcContainerComponentBase
    {
        [Parameter] public bool AlignEnd { get; set; }
        [Parameter] public bool NoWrap { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            if (AlignEnd)
            {
                CssAttributes.Add("mdc-form-field--align-end");
            }
            if (NoWrap)
            {
                CssAttributes.Add("mdc-form-field--nowrap");
            }
        }
    }
}
