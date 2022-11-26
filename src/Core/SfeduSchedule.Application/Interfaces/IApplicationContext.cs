using Microsoft.EntityFrameworkCore;
using SfeduSchedule.Domain.Entities;

namespace SfeduSchedule.Application.Interfaces
{
    public interface IApplicationContext
    {
        public DbSet<Group> Groups { get; set; }
        public DbSet<Institute> Institutes { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Day> Days { get; set; }
        public DbSet<Couple> Couples { get; set; }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
