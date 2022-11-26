using FluentValidation;

namespace SfeduSchedule.Application.Feature.Groups.Queries.GetGroupDetails;

public class GetGroupDetailsQueryValidator : AbstractValidator<GetGroupDetailsQuery>
{
    public GetGroupDetailsQueryValidator()
    {
        RuleFor(query =>
            query.Id).NotEqual(Guid.Empty);
    }
}