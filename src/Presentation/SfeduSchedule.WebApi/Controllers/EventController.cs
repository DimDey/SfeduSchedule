using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SfeduSchedule.Application.Features.DayEvents.Commands.CreateEvent;
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

		[HttpPost]
		public async Task<ActionResult<Guid>> Create([FromBody] CreateEventDto model)
		{
			var command = _mapper.Map<CreateEventCommand>(model);

			var result = await Mediator.Send(command);

			return Ok(result);
		}
	}
}
