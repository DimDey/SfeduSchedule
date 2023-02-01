using FluentValidation;

namespace SfeduSchedule.Application.Features.Faculties.Queries.GetInstituteFaculties;

public class GetInstituteFacultiesQueryValidator : AbstractValidator<GetInstituteFacultiesQuery>
{
    public GetInstituteFacultiesQueryValidator()
    {
        RuleFor(command =>
            command.InstituteId).NotEqual(Guid.Empty);
    }
}