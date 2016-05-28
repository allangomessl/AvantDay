using Avant.Data;
using Avant.Data.Repositories;
using Avant.Domain;
using Avant.Domain.Utils;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Avant.Web
{
    public class Startup
    {
        private readonly IConfigurationRoot _config;
        public Startup(IHostingEnvironment env)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("config.json")
                .AddJsonFile($"config.{env.EnvironmentName}.json", true);
            configuration.AddEnvironmentVariables();
            _config = configuration.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
             var connectionString = _config["Data:DefaultConnection:ConnectionString"];
            services.AddEntityFramework()
                .AddSqlServer()
                .AddDbContext<DataContext>();
            services.AddCors();
            services.AddMvc();

            services.AddScoped<IDataContext, DataContext>();
            services.AddScoped<ICrudRepository<Category>, CrudRepository<Category>>();
            services.AddScoped<CategoryService>();

            services.AddScoped<ICrudRepository<Product>, CrudRepository<Product>>();
            services.AddScoped<ProductService>();

            services.AddScoped<ICrudRepository<Order>, CrudRepository<Order>>();
            services.AddScoped<OrderService>();

        }

        public void Configure(IApplicationBuilder app, ILoggerFactory logger, IDataContext dataContext)
        {
            dataContext.Migrate();
            app.UseCors(builder => builder.AllowAnyOrigin()
                                          .AllowAnyHeader()
                                          .AllowAnyMethod());
            app.UseIISPlatformHandler();
            app.UseMvc(routes => { routes.MapRoute("api", "api/{controller}/{id?}", new { action = "Index" }); });
        }

        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
