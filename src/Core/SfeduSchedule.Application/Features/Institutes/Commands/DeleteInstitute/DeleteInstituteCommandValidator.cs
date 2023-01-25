using FluentValidation;

namespace SfeduSchedule.Application.Features.Institutes.Commands.DeleteInstitute;

public class DeleteInstituteCommandValidator : AbstractValidator<DeleteInstituteCommand>
{
	public DeleteInstituteCommandValidator()
	{
		RuleFor(command =>
			command.Id).NotEqual(Guid.Empty);
	}
}