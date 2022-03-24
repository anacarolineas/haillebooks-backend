using Halle.App.Configuration;
using Halle.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Halle.App
{
    public class Startup : IStartup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration) 
            => _configuration = configuration;

        public void Configure(WebApplication app, IWebHostEnvironment environment)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<Context>(options =>
            {
                options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddAutoMapper(typeof(Startup));
            services.AddControllers();

            //desativa validação automática da model state
            //services.Configure<ApiBehaviorOptions>(options =>
            //{
            //    options.SuppressModelStateInvalidFilter = true;
            //});
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.ResolveDependencies();
        }
    }

    public static class StartupExtensions
    {
        public static WebApplicationBuilder UseStartup<TStartup>(this WebApplicationBuilder webApplicationBuilder) where TStartup : IStartup // método de extensão
        {
            var startup = Activator.CreateInstance(typeof(TStartup), webApplicationBuilder.Configuration) as IStartup;
            if (startup == null) throw new ArgumentException("Classe Startup.cs inválida");

            startup.ConfigureServices(webApplicationBuilder.Services);
            var app = webApplicationBuilder.Build();

            startup.Configure(app, app.Environment);
            app.Run();

            return webApplicationBuilder;
        }
    }

    public interface IStartup
    {
        void Configure(WebApplication app, IWebHostEnvironment environment);
        void ConfigureServices(IServiceCollection services);
    }
}
