using Microsoft.AspNetCore.Components;

namespace Exentials.MdcBlazor
{
    public partial class MdcCardMedia
    {
        private string _backgroundImage;
        [Parameter] public string CssMedia { get; set; }
        [Parameter] public MdcCardMediaAspect Aspect { get; set; }
        [Parameter] public string Source { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            if (!string.IsNullOrEmpty(CssMedia))
            {
                CssAttributes.Add(CssMedia);
            }
            if (Aspect == MdcCardMediaAspect.Square)
            {
                CssAttributes.Add("mdc-card__media--square");
            }
            else if (Aspect == MdcCardMediaAspect.SixteenNine)
            {
                CssAttributes.Add("mdc-card__media--16-9");
            }
            if (Has(Source))
            {
                _backgroundImage = $"background-image: URL({Source})";
            }
        }
    }
}
