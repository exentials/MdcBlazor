using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exentials.MdcBlazor
{
    public partial class MdcDialogAction
    {
        [CascadingParameter] MdcDialog MdcDialog { get; set; }
        [Parameter] public string Label { get; set; }
        [Parameter] public string Name { get; set; }
        [Parameter] public bool Default { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            MdcDialog.TitleId = Id;
        }
    }
}
