using Microsoft.EntityFrameworkCore;
using SfeduSchedule.Application.Interfaces;
using SfeduSchedule.Application.Interfaces.Repository.Base;
using SfeduSchedule.Persistence.Context;
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
				//options.UseSqlServer(connectionString);
			});
			services.AddScoped<IApplicationContext>(provider =>
				provider.GetService<ApplicationContext>());

			services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));

			return services;
		}
	}
}
