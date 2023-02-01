using FluentValidation;

namespace SfeduSchedule.Application.Features.Institutes.Commands.UpdateInstitute;

public class UpdateInstituteCommandValidator : AbstractValidator<UpdateInstituteCommand>
{
	public UpdateInstituteCommandValidator()
	{
		RuleFor(command =>
			command.Id).NotEqual(Guid.Empty);
	}
}