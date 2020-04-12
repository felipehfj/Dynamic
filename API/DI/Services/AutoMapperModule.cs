using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace API.DI.Services
{
    public static class AutoMapperModule
    {
        public static void ResolveAutoMapperModule(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));
        }
    }
}
