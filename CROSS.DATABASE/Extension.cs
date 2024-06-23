using BCP.SLK.DATABASE;
using Microsoft.Extensions.DependencyInjection;

namespace CROSS.DATABASE
{
    public static class Extension
    {
        public static IServiceCollection AddDataBase(this IServiceCollection services)
        {
            services.AddSingleton<IDBOptions, DBOptions>();
            services.AddSingleton<IManagerDataBase, ManagerDataBase>();
            return services;
        }
    }
}
