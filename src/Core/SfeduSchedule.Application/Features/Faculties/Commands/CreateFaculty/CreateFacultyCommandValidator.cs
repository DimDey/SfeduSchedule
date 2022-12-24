using FluentValidation;

namespace SfeduSchedule.Application.Features.Faculties.Commands.CreateFaculty;

public class CreateFacultyCommandValidator : AbstractValidator<CreateFacultyCommand>
{
    public CreateFacultyCommandValidator()
    {
        RuleFor(command =>
            command.Name).NotEmpty();
        RuleFor(command =>
            command.InstituteId).NotEqual(Guid.Empty);
    }
}