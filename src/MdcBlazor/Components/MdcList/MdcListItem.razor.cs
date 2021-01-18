using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exentials.MdcBlazor
{
    public partial class MdcListItem : MdcComponentBase
    {
        private string _inputId;

        [CascadingParameter] MdcList MdcList { get; set; }
        [Parameter] public string Value { get; set; }
        [Parameter] public string Label { get; set; }
        [Parameter] public string SecondaryLabel { get; set; }

        private string InputId
        {
            get
            {
                if (_inputId != null)
                {
                    _inputId = Value;
                }
                return _inputId;
            }
        }

        private string Name
        {
            get { return MdcList?.Name; }
        }

        internal string Role 
        { 
            get
            {
                if (MdcList != null)
                {
                    switch (MdcList.Role)
                    {
                        case "listbox": return "option";
                        case "radiogroup": return "radio";
                        case "group": return "checkbox";
                    }
                }
                return null;
            }
        }
    }
}
