using MediatR;

namespace SfeduSchedule.Application.Features.Groups.Queries.GetFacultyGroups;

public class GetFacultyGroupsQuery : IRequest<GroupsVm>
{
    public Guid FacultyId { get; set; }
}