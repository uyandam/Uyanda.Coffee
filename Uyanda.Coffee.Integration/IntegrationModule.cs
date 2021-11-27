using Microsoft.Extensions.DependencyInjection;
using Uyanda.Coffee.Integration.AlphaVantage;
using Uyanda.Coffee.Application.Integration;


namespace Uyanda.Coffee.Integration
{
    public static class IntegrationModule
    {
        public static IServiceCollection AddIntegrationModule(this IServiceCollection services)
        {
            services.AddTransient <IAlphaVantageIntegration, AlphaVantageIntegration>();
            return services;
        }
    }
}
