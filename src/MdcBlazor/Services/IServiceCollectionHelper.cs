using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exentials.MdcBlazor
{
    public static class IServiceCollectionHelper
    {
        public static void AddMdcBlazor(this IServiceCollection services)
        {
            services.AddSingleton(MdcEventHandlers.MdcEventServiceInstance);
        }

    }
}