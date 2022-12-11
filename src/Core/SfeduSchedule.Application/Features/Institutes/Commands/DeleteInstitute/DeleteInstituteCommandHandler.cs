using MediatR;
using SfeduSchedule.Application.Interfaces.Repository;

namespace SfeduSchedule.Application.Features.Institutes.Commands.DeleteInstitute;

public class DeleteInstituteCommandHandler : IRequestHandler<DeleteInstituteCommand, Unit>
{
    private readonly IInsituteRepository _insituteRepository;
    public DeleteInstituteCommandHandler(IInsituteRepository repository)
    {
        _insituteRepository = repository;
    }
    
    public async Task<Unit> Handle(DeleteInstituteCommand request, CancellationToken cancellationToken)
    {
        var institute = await _insituteRepository.GetByGuIdAsync(request.Id, cancellationToken);

        await _insituteRepository.DeleteAsync(institute);
        return Unit.Value;
    }
}