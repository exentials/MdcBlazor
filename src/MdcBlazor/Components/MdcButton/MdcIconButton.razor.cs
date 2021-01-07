using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace Exentials.MdcBlazor
{
    public partial class MdcIconButton
    {
        [CascadingParameter(Name = "MdcParentContainerType")] protected Type ContainerType { get; set; }        

        protected override void OnInitialized()
        {
            base.OnInitialized();
            if (ContainerType == typeof(MdcCardActions))
            {
                CssAttributes.Add("mdc-card__action");
                CssAttributes.Add("mdc-card__action--icon");
            }
        }
    }
}
