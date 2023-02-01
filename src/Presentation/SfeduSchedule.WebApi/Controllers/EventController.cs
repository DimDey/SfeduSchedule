using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SfeduSchedule.Application.Features.DayEvents.Commands.CreateEvent;
using SfeduSchedule.Application.Features.DayEvents.Commands.DeleteEvent;
using SfeduSchedule.Application.Features.DayEvents.Commands.UpdateEvent;
using SfeduSchedule.WebApi.Models;

namespace SfeduSchedule.WebApi.Controllers
{
    /// <summary>
    /// Методы для расписания
    /// </summary>
    public class EventController : BaseController
	{
		private readonly IMapper _mapper;

		public EventController(IMapper mapper)
		{
			_mapper = mapper;
		}

		/// <summary>
		/// Создание нового ивента
		/// </summary>
		/// <param name="model">Модель создания</param>
		/// <returns></returns>
		[HttpPost]
		public async Task<ActionResult<Guid>> Create([FromBody] CreateEventDto model)
		{
			var command = _mapper.Map<CreateEventCommand>(model);

			var result = await Mediator.Send(command);

			return Ok(result);
		}

		/// <summary>
		/// Обновление сущности ивента
		/// </summary>
		/// <param name="model">Модель обновления</param>
		/// <returns></returns>
		[HttpPut]
		public async Task<ActionResult> Update([FromBody] UpdateEventDto model)
		{
			var command = _mapper.Map<UpdateEventCommand>(model);

			await Mediator.Send(command);

			return Ok();
		}

		/// <summary>
		/// Удаление ивента
		/// </summary>
		/// <param name="id">GUID ивента</param>
		/// <returns></returns>
		[Route("{id}")]
		[HttpDelete]
		public async Task<ActionResult> Delete(Guid id)
		{
			var result = await Mediator.Send(new DeleteEventCommand { Id = id });

			return Ok(result);
		}
	}
}
