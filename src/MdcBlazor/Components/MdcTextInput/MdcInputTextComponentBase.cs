using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace Exentials.MdcBlazor
{
    public abstract class MdcInputTextComponentBase : MdcInputComponentBase<string>, IMdcInputBox
    {
        [Parameter] public bool Outlined { get; set; }
        [Parameter] public bool NoLabel { get; set; }
        [Parameter] public int? Maxlength { get; set; }
        [Parameter] public bool ShowCounter { get; set; }
        [Parameter] public MdcTextFieldHelperType HelperType { get; set; }
        [Parameter] public string HelperMessage { get; set; }
        [Parameter] public bool Required { get; set; }

        protected string HelperId { get; set; }
        protected readonly CssAttributes CssHelperAttributes = new CssAttributes();

        protected override void OnInitialized()
        {
            base.OnInitialized();
            if (Outlined)
            {
                CssAttributes.Add("mdc-text-field--outlined");
            }
            else
            {
                CssAttributes.Add("mdc-text-field--filled");
            }
            if (NoLabel)
            {
                CssAttributes.Add("mdc-text-field--no-label");
            }
            if (ShowCounter)
            {
                CssAttributes.Add("mdc-text-field--with-internal-counter");
            }
            if (HelperType != MdcTextFieldHelperType.None)
            {
                HelperId = MdcComponentHelper.CreateId();
                switch (HelperType)
                {
                    case MdcTextFieldHelperType.Helper:
                        break;
                    case MdcTextFieldHelperType.HelperPersist:
                        CssHelperAttributes.Add("mdc-text-field-helper-text--persistent");
                        break;
                }
            }
        }
    }
}
