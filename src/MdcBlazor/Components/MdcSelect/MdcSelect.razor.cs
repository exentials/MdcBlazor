using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exentials.MdcBlazor
{
    public partial class MdcSelect : MdcInputComponentBase<string>, IMdcInputBox
    {
        private string SelectId { get; set; } = MdcComponentHelper.CreateId();
        private string HelperId { get; set; } = MdcComponentHelper.CreateId();
        private readonly CssAttributes CssHelperAttributes = new CssAttributes();

        [Parameter] public bool Outlined { get; set; }
        [Parameter] public bool Required { get; set; }
        [Parameter] public bool NoLabel { get; set; }
        [Parameter] public MdcTextFieldHelperType HelperType { get; set; }
        [Parameter] public string HelperMessage { get; set; }
        [Parameter] public RenderFragment ChildContent { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            if (Outlined)
            {
                CssAttributes.Add("mdc-select--outlined");
            }
            else
            {
                CssAttributes.Add("mdc-select--filled");
            }
            if (NoLabel)
            {
                CssAttributes.Add("mdc-select--no-label");
            }
            if (HelperType != MdcTextFieldHelperType.None)
            {
                HelperId = MdcComponentHelper.CreateId();
                switch (HelperType)
                {
                    case MdcTextFieldHelperType.Helper:
                        break;
                    case MdcTextFieldHelperType.HelperPersist:
                        CssHelperAttributes.Add("mdc-select-helper-text--validation-msg-persistent");
                        break;
                }
            }
        }

        [JSInvokable("MDCSelect:change")]
        public ValueTask MDCSelectChange(string value)
        {
            return Change(value);
        }
    }
}
