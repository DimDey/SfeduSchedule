using System.Reflection;
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
			services.AddAutoMapper(config =>
			{
				config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
				config.AddProfile(new AssemblyMappingProfile(typeof(IApplicationContext).Assembly));
			});

			services.AddControllers().AddNewtonsoftJson(opts =>
			{
				opts.SerializerSettings.Converters.Add(new StringEnumConverter());
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
			app.UseSwagger();
			app.UseSwaggerUI();

			app.UseMiddleware<ExpectionHandlerMiddleware>();
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
