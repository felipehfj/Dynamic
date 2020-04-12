using Business.Core;
using Microsoft.Extensions.DependencyInjection;

namespace API.DI.Services
{
    public static class BusinessModule
    {
        public static void ResolveBusinessModule(this IServiceCollection services)
        {
            services.AddTransient<IUserBusiness, UserBusiness>();
            services.AddTransient<IUserAuthBusiness, UserAuthBusiness>();
        }
    }
}
