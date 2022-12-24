using MediatR;

namespace SfeduSchedule.Application.Features.Institutes.Commands.UpdateInstitute;

public class UpdateInstituteCommand : IRequest<Unit>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    
}