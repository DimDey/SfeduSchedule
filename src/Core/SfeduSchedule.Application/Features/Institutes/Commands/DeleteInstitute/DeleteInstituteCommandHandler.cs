using MediatR;
using SfeduSchedule.Application.Common.Exceptions;
using SfeduSchedule.Application.Interfaces.Repository.Base;
using SfeduSchedule.Domain.Entities;

namespace SfeduSchedule.Application.Features.Institutes.Commands.DeleteInstitute;

public class DeleteInstituteCommandHandler : IRequestHandler<DeleteInstituteCommand, Unit>
{
	private readonly IRepository<Institute> _insituteRepository;
	public DeleteInstituteCommandHandler(IRepository<Institute> repository)
	{
		_insituteRepository = repository;
	}

	public async Task<Unit> Handle(DeleteInstituteCommand request, CancellationToken cancellationToken)
	{
		var institute = await _insituteRepository.GetByGuIdAsync(request.Id, cancellationToken);
		if (institute == null || institute.Id != request.Id)
		{
			throw new NotFoundException(nameof(Institute), request.Id);
		}

		await _insituteRepository.DeleteAsync(institute);
		return Unit.Value;
	}
}