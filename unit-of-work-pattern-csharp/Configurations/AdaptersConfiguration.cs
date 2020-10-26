using Microsoft.Extensions.DependencyInjection;
using UnitOfWorkPatternCSharp.Domain.Adapters;

namespace UnitOfWorkPatternCSharp.Configurations
{
    public static class AdaptersConfiguration
    {
        public static IServiceCollection AddAdapters(this IServiceCollection services)
        {
            services.AddTransient<IStockSystemAdapter, StockSystemAdapter>();
            services.AddTransient<IPackageSystemAdapter, PackageSystemAdapter>();
            services.AddTransient<INotificationSystemAdapter, NotificationSystemAdapter>();

            return services;
        }
    }
}