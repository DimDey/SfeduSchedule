using MediatR;
using SfeduSchedule.Application.Common.Exceptions;
using SfeduSchedule.Application.Interfaces.Repository.Base;
using SfeduSchedule.Domain.Entities;

namespace SfeduSchedule.Application.Features.Faculties.Commands.DeleteFaculty;

public class DeleteFacultyCommandHandler : IRequestHandler<DeleteFacultyCommand, Unit>
{
	private readonly IRepository<Faculty> _facultyRepository;

	public DeleteFacultyCommandHandler(IRepository<Faculty> repository)
	{
		_facultyRepository = repository;
	}

	public async Task<Unit> Handle(DeleteFacultyCommand request, CancellationToken cancellationToken)
	{
		var entity = await _facultyRepository.GetByGuIdAsync(request.Id);
		if (entity == null || entity.Id != request.Id)
		{
			throw new NotFoundException(nameof(Faculty), request.Id);
		}

		await _facultyRepository.DeleteAsync(entity);

		return Unit.Value;
	}
}