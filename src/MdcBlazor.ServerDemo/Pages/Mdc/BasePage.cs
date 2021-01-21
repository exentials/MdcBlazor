using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exentials.MdcBlazor.ServerDemo.Pages.Mdc
{
    public class BasePage : ComponentBase
    {

        protected T If<T>(bool? expression, T valueTrue)
        {
            return (expression ?? false) ? valueTrue : default(T);
        }

        protected T If<T>(bool? expression, T valueTrue, T valueFalse)
        {
            return (expression ?? false) ? valueTrue : valueFalse;
        }
    }
}
