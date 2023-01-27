using MediatR;

namespace SfeduSchedule.Application.Features.Faculties.Queries.GetFacultyGroups;

public class GetFacultyGroupsQuery : IRequest<GroupsVm>
{
	public Guid FacultyId { get; set; }
}