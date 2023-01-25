using MediatR;
using SfeduSchedule.Application.Common.Exceptions;
using SfeduSchedule.Application.Interfaces.Repository.Base;
using SfeduSchedule.Domain.Entities;

namespace SfeduSchedule.Application.Features.Institutes.Commands.UpdateInstitute;

public class UpdateInstituteCommandHandler : IRequestHandler<UpdateInstituteCommand, Unit>
{
	private readonly IRepository<Institute> _insituteRepository;

	public UpdateInstituteCommandHandler(IRepository<Institute> repository)
	{
		_insituteRepository = repository;
	}

	public async Task<Unit> Handle(UpdateInstituteCommand request, CancellationToken cancellationToken)
	{
		var insitute = await _insituteRepository.GetByGuIdAsync(request.Id, cancellationToken);
		if (insitute == null || insitute.Id != request.Id) 
		{
			throw new NotFoundException(nameof(Institute), request.Id);
		}

		if (!string.IsNullOrEmpty(request.Name))
			insitute.Name = request.Name;

		await _insituteRepository.UpdateAsync(insitute);
		return Unit.Value;
	}
}