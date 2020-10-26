using Microsoft.Extensions.DependencyInjection;
using UnitOfWorkPatternCSharp.Domain.UnitsOfWork;

namespace UnitOfWorkPatternCSharp.Configurations
{
    public static class UnitsOfWorkConfiguration
    {
        public static IServiceCollection AddUnitsOfWork(this IServiceCollection services)
        {
            services.AddTransient<ISellProductUnitOfWork, SellProductUnitOfWork>();
            
            return services;
        }
    }
}