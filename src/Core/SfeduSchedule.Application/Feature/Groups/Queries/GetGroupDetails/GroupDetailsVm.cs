using SfeduSchedule.Application.Common.Mappings;
using SfeduSchedule.Application.ViewModels;
using SfeduSchedule.Domain.Entities;

namespace SfeduSchedule.Application.Feature.Groups.Queries.GetGroupDetails;

public class GroupDetailsVm : IMapWith<Group>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid FacultyId { get; set; }
    public IEnumerable<ScheduleViewModel> Schedules { get; set; }
}