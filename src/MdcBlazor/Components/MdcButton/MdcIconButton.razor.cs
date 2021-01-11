using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace Exentials.MdcBlazor
{
    public partial class MdcIconButton : MdcButtonComponentBase
    {
        [CascadingParameter(Name = "MdcParentContainerType")] Type ParentContainerType { get; set; }        

        protected override void OnInitialized()
        {
            base.OnInitialized();
            if (ParentContainerType == typeof(MdcCardActions))
            {
                CssAttributes.Add("mdc-card__action");
                CssAttributes.Add("mdc-card__action--icon");
            }
        }
    }
}
