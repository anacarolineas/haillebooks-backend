using Halle.Application.Interfaces;
using Halle.Application.Notifications;
using Halle.Business.Interfaces;
using Halle.Business.Services;
using Halle.Data;

namespace Halle.App.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            //adicionar contexto, scoped interface -> class repository and service
            services.AddScoped<Context>();

            services.AddScoped<IAuthorService, AuthorService>();
            services.AddScoped<INotification, Notifier>();

            return services;
        }
    }
}
