using app.DataLayer.Generics;
using app.DataLayer.Implementions;
using app.DataLayer.Interfaces;
using app.DataLayer.Repositories.Identity;
using app.DataLayer.Services;
using Microsoft.Extensions.DependencyInjection;

namespace app.DataLayer.Context
{
    public static class DependencyInjection
    {
        public static void AddScoped(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IRolesRepository, RolesRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IEntityDataBaseTransaction, EntityDataBaseTransaction>();
            services.AddScoped<ISeed, Seed>();
        }
    }
}
