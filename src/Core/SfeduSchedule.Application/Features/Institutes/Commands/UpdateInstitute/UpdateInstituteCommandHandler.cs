using MediatR;
using SfeduSchedule.Application.Interfaces.Repository;

namespace SfeduSchedule.Application.Features.Institutes.Commands.UpdateInstitute;

public class UpdateInstituteCommandHandler : IRequestHandler<UpdateInstituteCommand, Unit>
{
    private readonly IInsituteRepository _insituteRepository;

    public UpdateInstituteCommandHandler(IInsituteRepository repository)
    {
        _insituteRepository = repository;
    }

    public async Task<Unit> Handle(UpdateInstituteCommand request, CancellationToken cancellationToken)
    {
        var insitute = await _insituteRepository.GetByGuIdAsync(request.Id, cancellationToken);
        insitute.Name = request.Name;
        await _insituteRepository.UpdateAsync(insitute);
        return Unit.Value;
    }   
}