using FluentValidation;

namespace SfeduSchedule.Application.Features.Groups.Queries.GetFacultyGroups;

public class GetFacultyGroupsQueryValidator : AbstractValidator<GetFacultyGroupsQuery>
{
	public GetFacultyGroupsQueryValidator()
	{
		RuleFor(query =>
			query.FacultyId).NotEqual(Guid.Empty);
	}
}