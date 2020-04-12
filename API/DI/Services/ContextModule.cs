using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Primitives;
using Repository.Context;
using System.Linq;
using System.Security.Claims;

namespace API.DI.Services
{
    public static class ContextModule
    {
        public static void ResolveContextModule(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<DynamicContext>(options =>
            {
                string connection = "DynamicDB1";
                ClaimsPrincipal principal = null;

                var httpContext = new HttpContextAccessor().HttpContext;

                if (httpContext != null)
                {
                    if (httpContext.User != null)
                    {
                        principal = httpContext.User;
                    }

                    if (httpContext.Request.Headers.ContainsKey("audience"))
                    {
                        httpContext.Request.Headers.TryGetValue("audience", out StringValues db);

                        connection = db.First();

                    }
                    if (principal != null)
                    {
                        if (principal.Claims.Count() > 0)
                        {
                            var r = principal.Claims.Where(c => c.Type == "aud").FirstOrDefault();
                            if (r != null)
                            {
                                connection = r.Value;
                            }
                        }
                    }
                }
                

                options.UseSqlServer(Configuration.GetConnectionString(connection));
            });
        }
    }
}
