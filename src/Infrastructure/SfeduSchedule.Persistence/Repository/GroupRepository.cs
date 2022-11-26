using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SfeduSchedule.Application.Common.Exceptions;
using SfeduSchedule.Application.Interfaces;
using SfeduSchedule.Application.Interfaces.Repository;
using SfeduSchedule.Domain.Entities;

namespace SfeduSchedule.Persistence.Repository
{
    public class GroupRepository : IRepository<Group>
    {
        private readonly IApplicationContext _dbContext;
        public GroupRepository(IApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Group?> GetByGuIdAsync(Guid guid, CancellationToken cancellationToken)
        {
            return await _dbContext.Groups.FirstOrDefaultAsync(x => x.Id == guid);
        }

        public async Task<IReadOnlyList<Group>> ListAllAsync(CancellationToken cancellationToken)
        {
            return await _dbContext.Groups.ToListAsync(cancellationToken);
        }

        public async Task<Group> AddAsync(Group entity, CancellationToken cancellationToken)
        {
            await _dbContext.Groups.AddAsync(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return entity;
        }

        public async Task UpdateAsync(Group entity, CancellationToken cancellationToken)
        {
            var updateEntity = await _dbContext.Groups.FirstOrDefaultAsync(x => x.Id == entity.Id, cancellationToken);
            if (updateEntity == null)
            {
                throw new NotFoundException(nameof(Group), entity.Id);
            }

            updateEntity.Name = entity.Name;
            updateEntity.FacultyId = entity.FacultyId;

            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(Group entity, CancellationToken cancellationToken)
        {
            _dbContext.Groups.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<IReadOnlyList<Group>> FindAsync(Expression<Func<Group, bool>> expression, CancellationToken cancellationToken)
        {
            return await _dbContext.Groups.Where(expression).ToListAsync(cancellationToken);
        }
    }
}
