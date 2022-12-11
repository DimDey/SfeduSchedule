using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SfeduSchedule.Application.Common.Exceptions;
using SfeduSchedule.Application.Interfaces;
using SfeduSchedule.Application.Interfaces.Repository.Base;
using SfeduSchedule.Domain.Entities;

namespace SfeduSchedule.Persistence.Repositories.Base;

public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
{
    private readonly IApplicationContext _applicationContext;
    private readonly DbSet<TEntity> _entitySet;
    
    public BaseRepository(IApplicationContext context)
    {
        _applicationContext = context;
        _entitySet = _applicationContext.Set<TEntity>();
    }
    
    public async Task<TEntity?> GetByGuIdAsync(Guid guid, CancellationToken cancellationToken)
    {
        var entity = await _entitySet.FirstOrDefaultAsync(x => x.Id == guid, cancellationToken);
        if (entity == null || entity.Id != guid)
        {
            throw new NotFoundException(typeof(TEntity).Name, guid);
        }
        
        return entity;
    }

    public async Task<IEnumerable<TEntity>> ListAllAsync(CancellationToken cancellationToken)
    {
        return await _entitySet.ToListAsync(cancellationToken);
    }

    public IQueryable<TEntity> ListAllQuery()
    {
        return _entitySet.AsQueryable();
    }

    public IQueryable<TEntity> FindWhere(Expression<Func<TEntity, bool>> expression)
    {
        return _entitySet.Where(expression);
    }

    public async Task<ICollection<TEntity>> FindAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken)
    {
        return await _entitySet.Where(expression).ToListAsync(cancellationToken);
    }

    public async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken)
    {
        await _entitySet.AddAsync(entity, cancellationToken);
        await _applicationContext.SaveChangesAsync(cancellationToken);

        return entity;
    }

    public async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken)
    {
        _entitySet.Update(entity);
        await _applicationContext.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(TEntity entity, CancellationToken cancellationToken)
    {
        _entitySet.Remove(entity);
        await _applicationContext.SaveChangesAsync(cancellationToken);
    }
}