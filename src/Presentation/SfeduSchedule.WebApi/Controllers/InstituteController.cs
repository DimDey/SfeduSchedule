using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SfeduSchedule.Application.Features.Institutes.Commands.CreateInstitute;
using SfeduSchedule.Application.Features.Institutes.Commands.DeleteInstitute;
using SfeduSchedule.Application.Features.Institutes.Commands.UpdateInstitute;
using SfeduSchedule.Application.Features.Institutes.Queries.GetInsituteList;
using SfeduSchedule.WebApi.Models;

namespace SfeduSchedule.WebApi.Controllers;

/// <summary>
/// Методы института
/// </summary>
public class InstituteController : BaseController
{
	private readonly IMapper _mapper;

	public InstituteController(IMapper mapper)
	{
		_mapper = mapper;
	}


	/// <summary>
	/// Получение списка институтов
	/// </summary>
	/// <returns></returns>
	[HttpGet]
	[ResponseCache(CacheProfileName = "Default120")]
	public async Task<ActionResult<InstituteListVm>> List()
	{
		var query = new GetInstituteListQuery();

		var result = await Mediator.Send(query);

		return Ok(result);
	}


	/// <summary>
	/// Создание сущности института
	/// </summary>
	/// <param name="model">Модель создания института</param>
	/// <returns></returns>
	[HttpPost]
	public async Task<ActionResult<Guid>> Create([FromBody] CreateInstituteDto model)
	{
		var command = _mapper.Map<CreateInstituteCommand>(model);

		var result = await Mediator.Send(command);

		return Ok(result);
	}


	/// <summary>
	/// Обновление института
	/// </summary>
	/// <param name="model">Модель обновления института</param>
	/// <remarks>Если необходимо обновить только одно поле из модели, то отправляем только это поле и GUID.</remarks>
	/// <returns></returns>
	[HttpPut]
	public async Task<ActionResult> Update([FromBody] UpdateInstituteDto model)
	{
		var command = _mapper.Map<UpdateInstituteCommand>(model);

		var result = await Mediator.Send(command);
		return Ok();
	}

	/// <summary>
	/// Удаление института
	/// </summary>
	/// <param name="id">GUID института</param>
	/// <returns></returns>
	[Route("{id}")]
	[HttpDelete]
	public async Task<ActionResult> Delete(Guid id)
	{
		var command = new DeleteInstituteCommand()
		{
			Id = id
		};

		await Mediator.Send(command);

		return Ok();
	}
}