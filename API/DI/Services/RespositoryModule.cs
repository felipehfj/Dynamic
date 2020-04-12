using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repository.Repos;
using Repository.Services;

namespace API.DI.Services
{
    public static class RespositoryModule
    {
        public static void ResolveRepositoryModule(this IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserAuthRepository, UserAuthRepository>();

            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}
