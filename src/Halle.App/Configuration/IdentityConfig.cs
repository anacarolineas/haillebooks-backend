using Halle.App.Data;
using Halle.App.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Halle.App.Configuration
{
    public static class IdentityConfig
    {
        public static IServiceCollection AddIdentityConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            //separação de um contexto para o identity
            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            //add identity na aplicação
            services.AddIdentity<ApplicationUser, Role>()
                .AddEntityFrameworkStores<ApplicationContext>()
                .AddDefaultTokenProviders()
                .AddUserStore<UserStore<ApplicationUser, Role, ApplicationContext, Guid>>()
                .AddRoleStore<RoleStore<Role, ApplicationContext, Guid>>();

            return services;
        }
    }
}
