using BudgetControl.Api.AutoMapConfig;
using BudgetControl.Infrastructure.Identity;
using BudgetControl.Infrastructure.Shared.ConfigurationServices;
using Microsoft.OpenApi.Models;
using System.ComponentModel;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;

namespace BudgetControl.Api.Bootstrap
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Add services to the container.
            services.AddAuthenticationConfiguration();
            services.AddInfrastructure(Configuration);
            services.AddAutoMapperConfiguration();

            services.AddCors();
            services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
                });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            //services.AddSwaggerGen(s =>
            //{
            //    s.SwaggerDoc("v1", new OpenApiInfo { Title = "SaurTech", Version = "v1" });
            //});
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Configure the HTTP request pipeline.
            if (env.IsDevelopment())
            {
                //app.UseSwagger();
                //app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SaurTech v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(x => x
               .AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader());

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
