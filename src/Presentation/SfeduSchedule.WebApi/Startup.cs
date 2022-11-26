using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SfeduSchedule.Application.Common.Mappings;
using SfeduSchedule.Application.Interfaces;
using SfeduSchedule.Application.Interfaces.Repository;
using SfeduSchedule.Domain.Entities;
using SfeduSchedule.Persistence;
using SfeduSchedule.Persistence.Repository;

namespace SfeduSchedule.WebApi
{
    public class Startup
    {
        public IConfiguration configuration { get; }
        public Startup(IConfiguration config)
        {
            configuration = config;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddPersistence(configuration);

            services.AddAutoMapper(config =>
            {
                config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
                config.AddProfile(new AssemblyMappingProfile(typeof(IApplicationContext).Assembly));
            });
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddScoped<IRepository<Group>, GroupRepository>();
            

            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if(env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
