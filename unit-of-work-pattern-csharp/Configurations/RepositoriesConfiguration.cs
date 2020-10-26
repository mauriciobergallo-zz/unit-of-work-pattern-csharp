using Microsoft.Extensions.DependencyInjection;
using UnitOfWorkPatternCSharp.Domain.Repositories;

namespace UnitOfWorkPatternCSharp.Configurations
{
    public static class RepositoriesConfiguration
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<ISellRepository, SellRepository>();
            
            return services;
        }
    }
}