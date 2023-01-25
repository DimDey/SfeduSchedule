using MediatR;

namespace SfeduSchedule.Application.Features.Faculties.Commands.CreateFaculty;

public class CreateFacultyCommand : IRequest<Guid>
{
	public Guid InstituteId { get; set; }
	public string Name { get; set; }
}