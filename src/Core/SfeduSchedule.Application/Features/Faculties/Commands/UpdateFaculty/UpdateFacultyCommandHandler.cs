using MediatR;
using SfeduSchedule.Application.Interfaces.Repository;

namespace SfeduSchedule.Application.Features.Faculties.Commands.UpdateFaculty;

public class UpdateFacultyCommandHandler : IRequestHandler<UpdateFacultyCommand>
{
    private readonly IFacultyRepository _facultyRepository;

    public UpdateFacultyCommandHandler(IFacultyRepository repository)
    {
        _facultyRepository = repository;
    }
    
    public async Task<Unit> Handle(UpdateFacultyCommand request, CancellationToken cancellationToken)
    {
        var entity = await _facultyRepository.GetByGuIdAsync(request.Id);

        entity.Name = request.Name;

        await _facultyRepository.UpdateAsync(entity);
        return Unit.Value;
    }
}