using MediatR;

namespace SfeduSchedule.Application.Features.Institutes.Commands.DeleteInstitute;

public class DeleteInstituteCommand : IRequest<Unit>
{
	public Guid Id { get; set; }
}