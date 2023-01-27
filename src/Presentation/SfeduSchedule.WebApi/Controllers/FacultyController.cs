using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SfeduSchedule.Application.Features.Faculties.Commands.CreateFaculty;
using SfeduSchedule.Application.Features.Faculties.Commands.DeleteFaculty;
using SfeduSchedule.Application.Features.Faculties.Commands.UpdateFaculty;
using SfeduSchedule.Application.Features.Faculties.Queries.GetFacultyGroups;
using SfeduSchedule.Application.Features.Faculties.Queries.GetInstituteFaculties;
using SfeduSchedule.Application.Features.Institutes.Queries.GetInsituteList;

namespace SfeduSchedule.WebApi.Controllers;

/// <summary>
/// Методы факультета
/// </summary>
public class FacultyController : BaseController
{
	private readonly IMapper _mapper;

	public FacultyController(IMapper mapper)
	{
		_mapper = mapper;
	}

	/// <summary>
	/// Получение списка факультетов в институте
	/// </summary>
	/// <param name="id">GUID института</param>
	/// <returns></returns>
	[Route("{id}")]
	[HttpGet]
	public async Task<ActionResult<InstituteListVm>> Details(Guid id)
	{
		var query = new GetInstituteFacultiesQuery()
		{
			InstituteId = id
		};

		var result = await Mediator.Send(query);

		return Ok(result);
	}

	/// <summary>
	/// Получение списка групп в факультете
	/// </summary>
	/// <param name="id">GUID факультета</param>
	/// <returns></returns>
	[HttpGet]
	public async Task<ActionResult<GroupsVm>> Groups(Guid id)
	{
		var query = new GetFacultyGroupsQuery()
		{
			FacultyId = id
		};

		var result = await Mediator.Send<GroupsVm>(query);

		return Ok(result);
	}

	/// <summary>
	/// Создание нового факультета
	/// </summary>
	/// <param name="model">Модель создания сущности</param>
	/// <returns></returns>
	[HttpPost]
	public async Task<ActionResult<Guid>> Create([FromBody] CreateFacultyDto model)
	{
		var command = _mapper.Map<CreateFacultyCommand>(model);

		var result = await Mediator.Send(command);

		return Ok(result);
	}


	/// <summary>
	/// Обновление сущности факультета
	/// </summary>
	/// <param name="model">Модель обновления сущности</param>
	/// <remarks>Если необходимо обновить только одно поле из модели, то отправляем только это поле и GUID.</remarks>
	/// <returns></returns>
	[HttpPut]
	public async Task<ActionResult> Update([FromBody] UpdateFacultyDto model)
	{
		var command = _mapper.Map<UpdateFacultyCommand>(model);

		await Mediator.Send(command);
		return Ok();
	}

	/// <summary>
	/// Удаление факультета
	/// </summary>
	/// <param name="id">GUID факультета</param>
	/// <returns></returns>
	[Route("{id}")]
	[HttpDelete]
	public async Task<ActionResult> Delete(Guid id)
	{
		var command = new DeleteFacultyCommand()
		{
			Id = id
		};

		await Mediator.Send(command);

		return Ok();
	}
}