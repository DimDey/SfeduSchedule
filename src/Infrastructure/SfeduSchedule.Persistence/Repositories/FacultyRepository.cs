using SfeduSchedule.Application.Interfaces;
using SfeduSchedule.Application.Interfaces.Repository;
using SfeduSchedule.Domain.Entities;
using SfeduSchedule.Persistence.Repositories.Base;

namespace SfeduSchedule.Persistence.Repositories;

public class FacultyRepository : BaseRepository<Faculty>, IFacultyRepository
{
    public FacultyRepository(IApplicationContext context) : base(context)
    {
    }
}