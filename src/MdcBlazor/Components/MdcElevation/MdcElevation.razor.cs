using Microsoft.AspNetCore.Components;

namespace Exentials.MdcBlazor
{
    public partial class MdcElevation
    {
        [Parameter] public MdcElevationLevel Level { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            CssAttributes.Add($"mdc-elevation--z{(int)Level}");
            CssAttributes.Add($"mdc-elevation-transition");
        }
    }
}
