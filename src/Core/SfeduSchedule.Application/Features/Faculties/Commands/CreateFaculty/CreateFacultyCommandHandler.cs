using MediatR;
using SfeduSchedule.Application.Interfaces.Repository.Base;
using SfeduSchedule.Domain.Entities;

namespace SfeduSchedule.Application.Features.Faculties.Commands.CreateFaculty;

public class CreateFacultyCommandHandler : IRequestHandler<CreateFacultyCommand, Guid>
{
	private readonly IRepository<Faculty> _facultyRepository;

	public CreateFacultyCommandHandler(IRepository<Faculty> repository)
	{
		_facultyRepository = repository;
	}

	public async Task<Guid> Handle(CreateFacultyCommand request, CancellationToken cancellationToken)
	{
		var faculty = new Faculty()
		{
			Id = Guid.NewGuid(),
			Name = request.Name,
			Groups = new List<Group>(),
			InstituteId = request.InstituteId
		};

		await _facultyRepository.AddAsync(faculty);

		return faculty.Id;
	}
}