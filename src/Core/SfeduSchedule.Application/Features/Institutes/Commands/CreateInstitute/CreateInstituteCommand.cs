using MediatR;

namespace SfeduSchedule.Application.Features.Institutes.Commands.CreateInstitute;

public class CreateInstituteCommand : IRequest<Guid>
{
	public string Name { get; set; }
}