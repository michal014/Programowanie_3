using Microsoft.Extensions.DependencyInjection.Extensions;
using WebAPI.IRepos;
using WebAPI.Repos;

namespace WebAPI
{
    public static class ServiceBootStrap
    {
        public static IServiceCollection AddLogicServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.TryAddScoped<IStudent, StudentRepo>();

            return services;
        }
    }
}
