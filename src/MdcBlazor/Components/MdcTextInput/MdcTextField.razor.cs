using Microsoft.AspNetCore.Components;

namespace Exentials.MdcBlazor
{
    public partial class MdcTextField
    {
        [Parameter] public string Prefix { get; set; }
        [Parameter] public string Suffix { get; set; }
        [Parameter] public bool AlignEnd { get; set; }
        [Parameter] public string LeadingIcon { get; set; }
        [Parameter] public string TrailingIcon { get; set; }


        protected override void OnInitialized()
        {
            base.OnInitialized();
            if (AlignEnd)
            {
                CssAttributes.Add("mdc-text-field--end-aligned");
            }
            if (!string.IsNullOrEmpty(LeadingIcon))
            {
                CssAttributes.Add("mdc-text-field--with-leading-icon");
            }
            if (!string.IsNullOrEmpty(TrailingIcon))
            {
                CssAttributes.Add("mdc-text-field--with-trailing-icon");
            }
        }
    }
}