using SfeduSchedule.Application.Interfaces;
using SfeduSchedule.Application.Interfaces.Repository;
using SfeduSchedule.Domain.Entities;
using SfeduSchedule.Persistence.Repositories.Base;

namespace SfeduSchedule.Persistence.Repositories;

public class InstituteRepository : BaseRepository<Institute>, IInsituteRepository
{
    public InstituteRepository(IApplicationContext context) : base(context)
    {
    }
}