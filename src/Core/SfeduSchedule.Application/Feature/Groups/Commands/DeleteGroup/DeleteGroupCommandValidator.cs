using FluentValidation;

namespace SfeduSchedule.Application.Feature.Groups.Commands.DeleteGroup;

public class DeleteGroupCommandValidator : AbstractValidator<DeleteGroupCommand>
{
    public DeleteGroupCommandValidator()
    {
        RuleFor(command =>
            command.Id).NotEqual(Guid.Empty);
    }
}