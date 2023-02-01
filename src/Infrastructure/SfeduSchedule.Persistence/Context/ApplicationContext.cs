using Microsoft.EntityFrameworkCore;
using SfeduSchedule.Application.Interfaces;
using SfeduSchedule.Domain.Entities;
using SfeduSchedule.Persistence.EntityConfiguration;

namespace SfeduSchedule.Persistence.Context
{
	public class ApplicationContext : DbContext, IApplicationContext
	{
		public DbSet<Group> Groups { get; set; }
		public DbSet<Institute> Institutes { get; set; }
		public DbSet<Faculty> Faculties { get; set; }
		public DbSet<DayEvent> Events { get; set; }

		public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
		{
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseLazyLoadingProxies();
			base.OnConfiguring(optionsBuilder);
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new EventEntityConfiguration());
			modelBuilder.ApplyConfiguration(new FacultyEntityConfiguration());
			modelBuilder.ApplyConfiguration(new GroupEntityConfiguration());
			modelBuilder.ApplyConfiguration(new InstituteEntityConfiguration());
			base.OnModelCreating(modelBuilder);
		}
	}
}