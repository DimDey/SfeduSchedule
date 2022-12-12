using Microsoft.EntityFrameworkCore;
using SfeduSchedule.Application.Interfaces;
using SfeduSchedule.Application.Interfaces.Repository;
using SfeduSchedule.Application.Interfaces.Repository.Base;
using SfeduSchedule.Domain.Entities;
using SfeduSchedule.Persistence.Context;
using SfeduSchedule.Persistence.Repositories;
using SfeduSchedule.Persistence.Repositories.Base;

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
            
            services.AddScoped(typeof(IGroupRepository), typeof(GroupRepository));
            services.AddScoped(typeof(IInsituteRepository), typeof(InstituteRepository));
            services.AddScoped(typeof(IScheduleRepository), typeof(ScheduleRepository));
            services.AddScoped(typeof(IFacultyRepository), typeof(FacultyRepository));

            return services;
        }
    }
}
