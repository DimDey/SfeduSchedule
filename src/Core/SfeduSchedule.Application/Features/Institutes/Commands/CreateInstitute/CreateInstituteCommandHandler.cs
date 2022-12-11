using MediatR;
using SfeduSchedule.Application.Interfaces.Repository;
using SfeduSchedule.Domain.Entities;

namespace SfeduSchedule.Application.Features.Institutes.Commands.CreateInstitute;

public class CreateInstituteCommandHandler : IRequestHandler<CreateInstituteCommand, Guid>
{
    private readonly IInsituteRepository _insituteRepository;

    public CreateInstituteCommandHandler(IInsituteRepository repository)
    {
        _insituteRepository = repository;
    }
    
    public async Task<Guid> Handle(CreateInstituteCommand request, CancellationToken cancellationToken)
    {
        var institute = new Institute()
        {
            Id = Guid.NewGuid(),
            Name = request.Name
        };

        await _insituteRepository.AddAsync(institute);

        return institute.Id;
    }
}