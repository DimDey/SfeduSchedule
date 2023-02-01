using MediatR;

namespace SfeduSchedule.Application.Features.Groups.Commands.CreateGroup;

public class CreateGroupCommand : IRequest<Guid>
{
	public string Name { get; set; }
	public Guid FacultyId { get; set; }
}