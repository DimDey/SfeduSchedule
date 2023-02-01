using FluentValidation;

namespace SfeduSchedule.Application.Features.Faculties.Commands.DeleteFaculty;

public class DeleteFacultyCommandValidator : AbstractValidator<DeleteFacultyCommand>
{
	public DeleteFacultyCommandValidator()
	{
		RuleFor(x => x.Id).NotEqual(Guid.Empty);
	}
}