using Halle.Data;

namespace Halle.App.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            //adicionar contexto, scoped interface -> class repository and service
            services.AddScoped<Context>();
            return services;
        }
    }
}
