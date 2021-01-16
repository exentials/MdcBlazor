using Microsoft.Extensions.DependencyInjection;

namespace Exentials.MdcBlazor
{
    public static class MdcBlazorExtensions
    {
        public static void AddMdcBlazor(this IServiceCollection services)
        {
            services.AddSingleton(MdcEventHandlers.MdcEventServiceInstance);
        }
    }
}