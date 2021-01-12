using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exentials.MdcBlazor
{
    public partial class MdcCircularProgress : MdcProgressIndicatorBase
    {
        private string _styleSize;

        [Parameter] public MdcCircularProgressSize Size { get; set; }

        protected override void OnInitialized()
        {
           base.OnInitialized();
            switch (Size)
            {
                case MdcCircularProgressSize.Small:
                    _styleSize = "width:24px;height:24px;";
                    break;
                case MdcCircularProgressSize.Medium:
                    _styleSize = "width:36px;height:36px;";
                    break;
                case MdcCircularProgressSize.Large:
                    _styleSize = "width:48px;height:48px;";
                    break;
            }
        }
    }
}
