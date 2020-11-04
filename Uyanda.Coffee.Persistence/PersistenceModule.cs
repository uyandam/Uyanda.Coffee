using Microsoft.Extensions.DependencyInjection;
using Uyanda.Coffee.Application.Features.BeverageManagement.Persistence;
using Uyanda.Coffee.Persistence.Accessors;

namespace Uyanda.Coffee.Persistence
{
    public static class PersistenceModule
    {
        public static IServiceCollection AddPersistenceModule(this IServiceCollection services)
        {
            services.AddTransient<IBeverageAccessor, BeverageAccessor>();
            services.AddTransient<IUnitOfWork, LocalDbContext>();

            return services;
        }
    }
}
