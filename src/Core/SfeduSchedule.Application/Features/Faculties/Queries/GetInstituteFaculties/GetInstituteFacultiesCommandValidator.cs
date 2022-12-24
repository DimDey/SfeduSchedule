using FluentValidation;

namespace SfeduSchedule.Application.Features.Faculties.Queries.GetInstituteFaculties;

public class GetInstituteFacultiesCommandValidator : AbstractValidator<GetInstituteFacultiesCommand>
{
    public GetInstituteFacultiesCommandValidator()
    {
        RuleFor(command =>
            command.InstituteId).NotEqual(Guid.Empty);
    }
}