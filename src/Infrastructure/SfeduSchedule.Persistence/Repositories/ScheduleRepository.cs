using SfeduSchedule.Application.Interfaces;
using SfeduSchedule.Application.Interfaces.Repository;
using SfeduSchedule.Domain.Entities;
using SfeduSchedule.Persistence.Repositories.Base;

namespace SfeduSchedule.Persistence.Repositories;

public class ScheduleRepository : BaseRepository<Schedule>, IScheduleRepository
{
    public ScheduleRepository(IApplicationContext context) : base(context)
    {
    }
}