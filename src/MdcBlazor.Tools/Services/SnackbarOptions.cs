using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace Exentials.MdcBlazor
{
    public class SnackbarOptions : ISnackbarOptions
    {
        public string Label { get; set; }
        public string ButtonLabel { get; set; }
        public bool Dismissable { get; set; }
        public int Timeout { get; set; } = 5000;
        public object ButtonActionValue { get; set; }
        public EventCallback<object> OnButtonAction { get; set; }
    }
}
