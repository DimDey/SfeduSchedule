using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SfeduSchedule.Application.Features.Groups.Commands.CreateGroup;
using SfeduSchedule.Application.Features.Groups.Commands.DeleteGroup;
using SfeduSchedule.Application.Features.Groups.Commands.UpdateGroup;
using SfeduSchedule.Application.Features.Groups.Queries.GetGroupDetails;
using SfeduSchedule.WebApi.Models;

namespace SfeduSchedule.WebApi.Controllers
{
	/// <summary>
	/// Методы группы факультета
	/// </summary>
	public class GroupController : BaseController
	{
		private readonly IMapper _mapper;

		public GroupController(IMapper mapper)
		{
			_mapper = mapper;
		}

		/// <summary>
		/// Получение информации о группе
		/// </summary>
		/// <param name="id">GUID группы</param>
		/// <returns></returns>
		[Route("{id}")]
		[HttpGet]
		public async Task<ActionResult<GroupDetailsVm>> Details(Guid id)
		{
			var query = new GetGroupDetailsQuery()
			{
				Id = id
			};

			var result = await Mediator.Send(query);

			return Ok(result);
		}


		/// <summary>
		/// Создание новой группы в факультете
		/// </summary>
		/// <param name="model">Модель создания группы</param>
		/// <returns></returns>
		[HttpPost]
		public async Task<ActionResult<Guid>> Create([FromBody] CreateGroupDto model)
		{
			var command = _mapper.Map<CreateGroupCommand>(model);

			var result = await Mediator.Send(command);
			return Ok(result);
		}


		/// <summary>
		/// Обновление сущности группы факультета 
		/// </summary>
		/// <param name="model">Модель обновления группы</param>
		/// <remarks>Если необходимо обновить только одно поле из модели, то отправляем только это поле и GUID.</remarks>
		/// <returns></returns>
		[HttpPut]
		public async Task<ActionResult> Update([FromBody] UpdateGroupDto model)
		{
			var command = _mapper.Map<UpdateGroupCommand>(model);
			await Mediator.Send(command);
			return Ok();
		}


		/// <summary>
		/// Удаление группы факультета.
		/// </summary>
		/// <param name="id">GUID группы</param>
		/// <returns></returns>
		[Route("{id}")]
		[HttpDelete]
		public async Task<ActionResult> Delete(Guid id)
		{
			var command = new DeleteGroupCommand()
			{
				Id = id
			};
			await Mediator.Send(command);

			return Ok();
		}

	}
}

