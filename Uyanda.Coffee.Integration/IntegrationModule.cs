using Microsoft.Extensions.DependencyInjection;
using Uyanda.Coffee.Integration.AlphaVantage;
using Uyanda.Coffee.Application.Integration;
using Uyanda.Coffee.Integration.ApiLayer;

namespace Uyanda.Coffee.Integration
{
    public static class IntegrationModule
    {
        public static IServiceCollection AddIntegrationModule(this IServiceCollection services)
        {
            services.AddTransient <IAlphaVantageIntegration, AlphaVantageIntegration>();
            services.AddTransient<IApiLayerIntegration, ApiLayerIntegration>();
            return services;
        }
    }
}
