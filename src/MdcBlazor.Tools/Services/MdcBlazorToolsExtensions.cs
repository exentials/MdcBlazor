using Microsoft.Extensions.DependencyInjection;

namespace Exentials.MdcBlazor
{
    public static class MdcBlazorToolsExtensions
    {
        public static void AddMdcBlazor(this IServiceCollection services)
        {
            services.AddScoped<SnackbarService>();
        }
    }
}