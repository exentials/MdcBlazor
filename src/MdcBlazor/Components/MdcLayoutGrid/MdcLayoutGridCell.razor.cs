using Microsoft.AspNetCore.Components;

namespace Exentials.MdcBlazor
{
    public partial class MdcLayoutGridCell
    {
        /// <summary>
        /// Specifies the number of columns the cell spans
        /// </summary>
        [Parameter] public int Span { get; set; }
        /// <summary>
        /// Specifies the order of the cell
        /// </summary>
        [Parameter] public int Order { get; set; }
        /// <summary>
        /// Specifies the number of columns the cell spans on desktop device
        /// </summary>
        [Parameter] public int DesktopSpan { get; set; }
        /// <summary>
        /// Specifies the number of columns the cell spans on a tablet device
        /// </summary>
        [Parameter] public int TabletSpan { get; set; }
        /// <summary>
        /// Specifies the number of columns the cell spans on a phone device
        /// </summary>
        [Parameter] public int PhoneSpan { get; set; }
        /// <summary>
        /// Specifies the alignment of cell
        /// </summary>
        [Parameter] public MdcLayoutGridCellAlign Align { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            if (Span > 0 && Span <= 12)
            {
                CssAttributes.Add($"mdc-layout-grid__cell--span-{Span}");
            }
            if (Order > 0 && Order <= 12)
            {
                CssAttributes.Add($"mdc-layout-grid__cell--order-{Order}");
            }
            if (DesktopSpan > 0 && DesktopSpan <= 12)
            {
                CssAttributes.Add($"mdc-layout-grid__cell--span-{DesktopSpan}-desktop");
            }
            if (TabletSpan > 0 && TabletSpan <= 12)
            {
                CssAttributes.Add($"mdc-layout-grid__cell--span-{TabletSpan}-tablet");
            }
            if (PhoneSpan > 0 && PhoneSpan <= 12)
            {
                CssAttributes.Add($"mdc-layout-grid__cell--span-{PhoneSpan}-phone");
            }
            if (Align != MdcLayoutGridCellAlign.None)
            {
                string align = Align switch
                {
                    MdcLayoutGridCellAlign.Top => "top",
                    MdcLayoutGridCellAlign.Middle => "middle",
                    MdcLayoutGridCellAlign.Bottom => "bottom",
                    _ => string.Empty
                };
                CssAttributes.Add($"mdc-layout-grid__cell--align-{align}");
            }
        }
    }
}