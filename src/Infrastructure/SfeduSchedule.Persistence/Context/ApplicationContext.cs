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
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Day> Days { get; set; }
        public DbSet<Couple> Couples { get; set; }

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
            modelBuilder.ApplyConfiguration(new CoupleEntityConfiguration());
            modelBuilder.ApplyConfiguration(new DayEntityConfiguration());
            modelBuilder.ApplyConfiguration(new FacultyEntityConfiguration());
            modelBuilder.ApplyConfiguration(new GroupEntityConfiguration());
            modelBuilder.ApplyConfiguration(new InstituteEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ScheduleEntityConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
