using MediatR;

namespace SfeduSchedule.Application.Features.Faculties.Commands.DeleteFaculty;

public class DeleteFacultyCommand : IRequest<Unit>
{
    public Guid Id { get; set; }
}