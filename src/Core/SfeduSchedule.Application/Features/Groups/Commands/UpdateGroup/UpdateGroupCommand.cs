using MediatR;

namespace SfeduSchedule.Application.Features.Groups.Commands.UpdateGroup;

public class UpdateGroupCommand : IRequest<Unit>
{
	public Guid Id { get; set; }
	public string Name { get; set; }
	public Guid FacultyId { get; set; }
}