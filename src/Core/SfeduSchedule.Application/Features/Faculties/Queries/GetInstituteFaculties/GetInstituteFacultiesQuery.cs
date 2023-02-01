using MediatR;

namespace SfeduSchedule.Application.Features.Faculties.Queries.GetInstituteFaculties;

public class GetInstituteFacultiesQuery : IRequest<FacultyListVm>
{
    public Guid InstituteId { get; set; }
}