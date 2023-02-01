using FluentValidation;

namespace SfeduSchedule.Application.Features.Institutes.Commands.CreateInstitute;

public class CreateInstituteCommandValidator : AbstractValidator<CreateInstituteCommand>
{
	public CreateInstituteCommandValidator()
	{
		RuleFor(command =>
			command.Name).NotEmpty().MaximumLength(64);
	}
}