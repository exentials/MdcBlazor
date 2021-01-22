using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System.Threading.Tasks;

namespace Exentials.MdcBlazor
{
    public partial class MdcCardActions
    {
        [Parameter] public bool FullBleed { get; set; }
        [Parameter] public EventCallback OnClick { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            if (FullBleed)
            {
                CssAttributes.Add("mdc-card__actions--full-bleed");
            }
        }

        private Task ClickHandler(MouseEventArgs args)
        {
            if (OnClick.HasDelegate)
            {
                return OnClick.InvokeAsync();
            }
            return Task.CompletedTask;
        }
    }
}
