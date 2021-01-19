using Microsoft.AspNetCore.Components;
using System.Collections.Generic;

namespace Exentials.MdcBlazor
{
    public partial class MdcRadioGroup : MdcContainerComponentBase
    {
        private string _value;
        internal readonly List<MdcRadio> Radios = new List<MdcRadio>();

        [Parameter] public string Name { get; set; }
        [Parameter]
        public string Value
        {
            get => _value;
            set
            {
                if (_value != value)
                {
                    _value = value;
                    if (ValueChanged.HasDelegate)
                    {
                        ValueChanged.InvokeAsync(_value);
                    }
                }
            }
        }
        [Parameter] public EventCallback<string> ValueChanged { get; set; }

        internal void SetValue(string value)
        {
            Value = value;
        }

    }
}
