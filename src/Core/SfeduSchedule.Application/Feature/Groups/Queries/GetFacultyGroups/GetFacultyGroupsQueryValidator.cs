using FluentValidation;

namespace SfeduSchedule.Application.Feature.Groups.Queries.GetFacultyGroups;

public class GetFacultyGroupsQueryValidator : AbstractValidator<GetFacultyGroupsQuery>
{
    public GetFacultyGroupsQueryValidator()
    {
        RuleFor(query =>
            query.FacultyId).NotEqual(Guid.Empty);
    }
}