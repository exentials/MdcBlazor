using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace Exentials.MdcBlazor
{
    public interface ISnackbarOptions
    {
        string Label { get; set; }
        bool Dismissable { get; set; }
        int Timeout { get; set; }
    }
}
