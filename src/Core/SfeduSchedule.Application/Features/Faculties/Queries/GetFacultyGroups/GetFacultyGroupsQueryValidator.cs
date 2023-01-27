using FluentValidation;

namespace SfeduSchedule.Application.Features.Faculties.Queries.GetFacultyGroups;

public class GetFacultyGroupsQueryValidator : AbstractValidator<GetFacultyGroupsQuery>
{
	public GetFacultyGroupsQueryValidator()
	{
		RuleFor(query =>
			query.FacultyId).NotEqual(Guid.Empty);
	}
}