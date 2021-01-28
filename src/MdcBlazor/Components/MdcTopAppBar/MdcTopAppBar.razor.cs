using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace Exentials.MdcBlazor
{
    public partial class MdcTopAppBar
    {
        private readonly CssAttributes CssClassAdjustAttributes = new CssAttributes();
        [CascadingParameter] MdcTopAppBarContainer MdcTopAppBarContainer { get; set; }
        [Parameter] public RenderFragment Header { get; set; }
        [Parameter] public MdcTopAppBarType BarType { get; set; }
        [Parameter] public EventCallback OnNavToggle { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            if (Has(MdcTopAppBarContainer))
            {
                CssAttributes.Add("drawer-below-top-app-bar");
            }     
            switch (BarType)
            {
                case MdcTopAppBarType.Regular:
                    CssClassAdjustAttributes.Add("mdc-top-app-bar--fixed-adjust");
                    break;
                case MdcTopAppBarType.Short:
                    CssAttributes.Add("mdc-top-app-bar--short");
                    CssClassAdjustAttributes.Add("mdc-top-app-bar--short-fixed-adjust");                    
                    break;
                case MdcTopAppBarType.ShortClosed:
                    CssAttributes.Add("mdc-top-app-bar--short");
                    CssAttributes.Add("mdc-top-app-bar--short-collapsed");
                    CssClassAdjustAttributes.Add("mdc-top-app-bar--short-fixed-adjust");
                    break;
                case MdcTopAppBarType.Fixed:
                    CssAttributes.Add("mdc-top-app-bar--fixed");                    
                    CssClassAdjustAttributes.Add("mdc-top-app-bar--fixed-adjust");
                    break;
                case MdcTopAppBarType.Prominent:
                    CssAttributes.Add("mdc-top-app-bar mdc-top-app-bar--prominent");
                    CssClassAdjustAttributes.Add("mdc-top-app-bar--prominent-fixed-adjust");
                    break;
                case MdcTopAppBarType.Dense:
                    CssAttributes.Add("mdc-top-app-bar mdc-top-app-bar--dense");
                    CssClassAdjustAttributes.Add("mdc-top-app-bar--dense-fixed-adjust");
                    break;
            }
        }

        [JSInvokable("MDCTopAppBar:nav")]
        public Task MDCTopAppBarNav()
        {
            if (OnNavToggle.HasDelegate)
            {
                return OnNavToggle.InvokeAsync();
            }
            return Task.CompletedTask;
        }

    }
}
