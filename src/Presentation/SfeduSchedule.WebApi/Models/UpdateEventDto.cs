using AutoMapper;
using SfeduSchedule.Application.Common.Mappings;
using SfeduSchedule.Application.Features.DayEvents.Commands.UpdateEvent;
using SfeduSchedule.Domain.Entities;

namespace SfeduSchedule.WebApi.Models
{
    public class UpdateEventDto : IMapWith<UpdateEventCommand>
    {

		/// <summary>
		/// GUID ивента
		/// </summary>
		public Guid Id { get; set; }

		/// <summary>
		/// День недели
		/// </summary>
		public DayNumber DayNumber { get; set; }


		/// <summary>
		/// Время начала
		/// </summary>
		public TimeOnly? Begin { get; set; }

		/// <summary>
		/// Время окончания
		/// </summary>
		public TimeOnly? End { get; set; }

		/// <summary>
		/// Описание ивента
		/// </summary>
		public string Description { get; set; }

		/// <summary>
		/// Адрес ивента
		/// </summary>
		public string Address { get; set; }

		/// <summary>
		/// Кабинет, в котором проходит ивент
		/// </summary>
		public string ClassRoom { get; set; }

		/// <summary>
		/// ФИО преподавателя
		/// </summary>
		public string Teacher { get; set; }

		/// <summary>
		/// Необязательный аргумент. Четная/нечетная неделя.
		/// </summary>
		public bool? OnEven { get; set; }

		/// <summary>
		/// Необязательный аргумент. Номер подгруппы
		/// </summary>
		public int? SubGroup { get; set; }

		public void Mapping(Profile profile)
		{
			profile.CreateMap<UpdateEventDto, UpdateEventCommand>();
		}
	}
}