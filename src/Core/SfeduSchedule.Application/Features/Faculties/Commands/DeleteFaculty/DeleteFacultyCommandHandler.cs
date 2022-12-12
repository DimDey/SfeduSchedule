using MediatR;
using SfeduSchedule.Application.Interfaces.Repository;

namespace SfeduSchedule.Application.Features.Faculties.Commands.DeleteFaculty;

public class DeleteFacultyCommandHandler : IRequestHandler<DeleteFacultyCommand, Unit>
{
    private readonly IFacultyRepository _facultyRepository;

    public DeleteFacultyCommandHandler(IFacultyRepository repository)
    {
        _facultyRepository = repository;
    }
    
    public async Task<Unit> Handle(DeleteFacultyCommand request, CancellationToken cancellationToken)
    {
        var entity = await _facultyRepository.GetByGuIdAsync(request.Id);

        await _facultyRepository.DeleteAsync(entity);

        return Unit.Value;
    }
}