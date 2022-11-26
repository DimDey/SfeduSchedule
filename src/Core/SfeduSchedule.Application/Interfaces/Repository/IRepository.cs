using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SfeduSchedule.Domain.Entities;

namespace SfeduSchedule.Application.Interfaces.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<T?> GetByGuIdAsync(Guid guid, CancellationToken cancellationToken);
        Task<IReadOnlyList<T>> ListAllAsync(CancellationToken cancellationToken);
        Task<IReadOnlyList<T>> FindAsync(Expression<Func<Group, bool>> expression, CancellationToken cancellationToken);
        Task<T> AddAsync(T entity, CancellationToken cancellationToken);
        Task UpdateAsync(T entity, CancellationToken cancellationToken);
        Task DeleteAsync(T entity, CancellationToken cancellationToken);
    }
}
