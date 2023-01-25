using Microsoft.EntityFrameworkCore;
using SfeduSchedule.Domain.Entities;

namespace SfeduSchedule.Application.Interfaces
{
    public interface IApplicationContext
    {
        public DbSet<Group> Groups { get; set; }
        public DbSet<Institute> Institutes { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<DayEvent> Events { get; set; }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
    }
}
