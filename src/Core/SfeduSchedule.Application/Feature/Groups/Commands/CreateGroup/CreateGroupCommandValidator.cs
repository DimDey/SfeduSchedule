using FluentValidation;

namespace SfeduSchedule.Application.Feature.Groups.Commands.CreateGroup;

public class CreateGroupCommandValidator : AbstractValidator<CreateGroupCommand>
{
    public CreateGroupCommandValidator()
    {
        RuleFor(command =>
            command.Name).NotEmpty().MaximumLength(64);
        RuleFor(command =>
            command.FacultyId).NotEqual(Guid.Empty);
    }
}