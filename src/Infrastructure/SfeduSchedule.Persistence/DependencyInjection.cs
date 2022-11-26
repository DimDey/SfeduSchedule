using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using SfeduSchedule.Application.Interfaces;
using SfeduSchedule.Application.Interfaces.Repository;
using SfeduSchedule.Domain.Entities;
using SfeduSchedule.Persistence.Context;
using SfeduSchedule.Persistence.Repository;

namespace SfeduSchedule.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<ApplicationContext>(options =>
            {
                options.UseNpgsql(connectionString);
            });
            services.AddScoped<IApplicationContext>(provider =>
                provider.GetService<ApplicationContext>());
            
            services.AddScoped<IRepository<Group>, GroupRepository>();

            return services;
        }
    }
}
