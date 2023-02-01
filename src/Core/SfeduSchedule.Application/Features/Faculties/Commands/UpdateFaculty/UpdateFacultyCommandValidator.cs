using FluentValidation;

namespace SfeduSchedule.Application.Features.Faculties.Commands.UpdateFaculty;

public class UpdateFacultyCommandValidator : AbstractValidator<UpdateFacultyCommand>
{
	public UpdateFacultyCommandValidator()
	{
		RuleFor(command =>
			command.Id).NotEqual(Guid.Empty);
	}
}