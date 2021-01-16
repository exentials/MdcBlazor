using Microsoft.Extensions.DependencyInjection;

namespace Exentials.MdcBlazor
{
    public static class MdcBlazorToolsExtensions
    {
        public static void AddMdcBlazorTools(this IServiceCollection services)
        {
            services.AddScoped<SnackbarService>();
        }
    }
}