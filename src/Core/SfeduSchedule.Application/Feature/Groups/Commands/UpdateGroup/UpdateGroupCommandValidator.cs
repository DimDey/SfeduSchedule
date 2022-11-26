using FluentValidation;

namespace SfeduSchedule.Application.Feature.Groups.Commands.UpdateGroup;

public class UpdateGroupCommandValidator : AbstractValidator<UpdateGroupCommand>
{
    public UpdateGroupCommandValidator()
    {
        RuleFor(command =>
            command.Id).NotEqual(Guid.Empty);
        RuleFor(command =>
            command.Name).NotEmpty().MaximumLength(64);
        RuleFor(command =>
            command.FacultyId).NotEqual(Guid.Empty);
    }
}