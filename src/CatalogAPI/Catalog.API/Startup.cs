using System;
using Catalog.API.Configuration;
using Catalog.Domain.Entity;
using Catalog.Service.Books.Handler;
using Liquid.WebApi.Http.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Catalog.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        private readonly IWebHostEnvironment _env;

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            _env = env;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            if (_env.IsDevelopment() || _env.IsEnvironment("DockerCompose"))
            {
                services.AddCors(options =>
                {
                    options.AddDefaultPolicy(
                        builder =>
                        {
                            builder.SetIsOriginAllowed(origin => new Uri(origin).IsLoopback);
                            builder.AllowAnyHeader();
                            builder.AllowAnyMethod();
                        });
                });
            }

            services.AddLiquidMongoDatabaseWithTelemetry<Book, string>("BookstoreDb");

            services.AddLiquidHttp(typeof(BooksListRequestHandler).Assembly);

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            if (_env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseLiquidConfigure();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
