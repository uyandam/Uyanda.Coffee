using Microsoft.Extensions.DependencyInjection;
using Uyanda.Coffee.Application.Features.BeverageManagement.Services;

namespace Uyanda.Coffee.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplicationModule(this IServiceCollection services)
        {
            services.AddTransient<IBeverageManagementService, BeverageManagementService>();

            return services;
        }
    }
}
