using Microsoft.AspNetCore.Components;

namespace Exentials.MdcBlazor
{
    public partial class MdcCard
    {
        private string _size;

        [Parameter] public string CssCard { get; set; }
        [Parameter] public bool Outlined { get; set; }

        [Parameter] public int Width { get; set; }
        [Parameter] public int Height { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            _size = (Width > 0 && Height > 0) ? $"width: {Width}px; height: {Height}px;" : null;
            if (!string.IsNullOrEmpty(CssCard))
            {
                CssAttributes.Add(CssCard);
            }
            if (Outlined)
            {
                CssAttributes.Add("mdc-card--outlined");
            }

        }
    }
}