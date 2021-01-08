using Microsoft.AspNetCore.Components;

namespace Exentials.MdcBlazor
{
    public partial class MdcTextField
    {
        [Parameter] public string Prefix { get; set; }
        [Parameter] public string Suffix { get; set; }
        [Parameter] public bool AlignEnd { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            if (AlignEnd)
            {
                CssAttributes.Add("mdc-text-field--end-aligned");
            }
        }
    }
}