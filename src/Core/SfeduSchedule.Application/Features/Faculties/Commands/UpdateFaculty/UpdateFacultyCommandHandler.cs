using MediatR;
using SfeduSchedule.Application.Common.Exceptions;
using SfeduSchedule.Application.Interfaces.Repository.Base;
using SfeduSchedule.Domain.Entities;

namespace SfeduSchedule.Application.Features.Faculties.Commands.UpdateFaculty;

public class UpdateFacultyCommandHandler : IRequestHandler<UpdateFacultyCommand>
{
	private readonly IRepository<Faculty> _facultyRepository;

	public UpdateFacultyCommandHandler(IRepository<Faculty> repository)
	{
		_facultyRepository = repository;
	}

	public async Task<Unit> Handle(UpdateFacultyCommand request, CancellationToken cancellationToken)
	{
		var entity = await _facultyRepository.GetByGuIdAsync(request.Id);
		if(entity == null || entity.Id != request.Id) 
		{
			throw new NotFoundException(nameof(Faculty), request.Id);
		}

		if (!string.IsNullOrEmpty(request.Name))
			entity.Name = request.Name;

		await _facultyRepository.UpdateAsync(entity);
		return Unit.Value;
	}
}