using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exentials.MdcBlazor
{
    public partial class MdcDialogTitle
    {
        [CascadingParameter] MdcDialog MdcDialog { get; set; }
        [Parameter] public string Label { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            MdcDialog.TitleId = Id;
        }
    }
}
