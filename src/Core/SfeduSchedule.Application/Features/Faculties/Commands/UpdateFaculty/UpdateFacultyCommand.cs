using MediatR;

namespace SfeduSchedule.Application.Features.Faculties.Commands.UpdateFaculty;

public class UpdateFacultyCommand : IRequest
{
	public Guid Id { get; set; }
	public string Name { get; set; }
}