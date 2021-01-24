using Microsoft.AspNetCore.Components;

namespace Exentials.MdcBlazor
{
    public partial class MdcLayoutGrid
    {
        /// <summary>
        /// Specifies the grid should have fixed column width
        /// </summary>
        [Parameter] public bool FixedColumnWidth { get; set; }

        /// <summary>
        /// Specifies the alignment of the whole grid
        /// </summary>
        [Parameter] public MdcLayoutGridAlign Align { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            if (Align != MdcLayoutGridAlign.None)
            {
                string align = Align switch
                {
                    MdcLayoutGridAlign.Left => "left",
                    MdcLayoutGridAlign.Right => "right",
                    _ => string.Empty
                };
                CssAttributes.Add($"mdc-layout-grid--align-{align}");
            }
        }
    }
}
