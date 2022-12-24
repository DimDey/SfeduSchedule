using MediatR;

namespace SfeduSchedule.Application.Features.Faculties.Queries.GetInstituteFaculties;

public class GetInstituteFacultiesCommand : IRequest<FacultyListVm>
{
    public Guid InstituteId { get; set; }
}