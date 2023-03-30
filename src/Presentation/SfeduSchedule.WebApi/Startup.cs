using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Converters;
using SfeduSchedule.Application;
using SfeduSchedule.Application.Common.Mappings;
using SfeduSchedule.Application.Interfaces;
using SfeduSchedule.Persistence;
using SfeduSchedule.WebApi.Middleware;

namespace SfeduSchedule.WebApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration config)
        {
            Configuration = config;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting(options => options.LowercaseUrls = true);

            services.AddPersistence(Configuration);
            services.AddApplication();
            services.AddAutoMapper(options =>
            {
                options.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
                options.AddProfile(new AssemblyMappingProfile(typeof(IApplicationContext).Assembly));
            });

            services.AddResponseCaching();
            services.AddControllers(options =>
            {
                options.CacheProfiles.Add("Default10", new CacheProfile
                {
                    Duration = 10,
                    VaryByQueryKeys = new string[] { "id" },
                    Location = ResponseCacheLocation.Any
                });
            }).AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.Converters.Add(new StringEnumConverter());
            }); ;
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(x =>
            {
                x.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"), true);
            });
            services.AddSwaggerGenNewtonsoftSupport();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseMiddleware<ExpectionHandlerMiddleware>();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
            );
            app.UseResponseCaching();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
