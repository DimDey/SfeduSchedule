using System.Linq.Expressions;

namespace SfeduSchedule.Application.Interfaces.Repository.Base
{
	public interface IRepository<T> where T : class
	{
		Task<T?> GetByGuIdAsync(Guid guid, CancellationToken cancellationToken = default);
		Task<IEnumerable<T>> ListAllAsync(CancellationToken cancellationToken = default);
		IQueryable<T> ListAllQuery();
		Task<ICollection<T>> FindAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default);
		IQueryable<T> FindWhere(Expression<Func<T, bool>> expression);
		Task<T> AddAsync(T entity, CancellationToken cancellationToken = default);
		Task UpdateAsync(T entity, CancellationToken cancellationToken = default);
		Task DeleteAsync(T entity, CancellationToken cancellationToken = default);
	}
}
