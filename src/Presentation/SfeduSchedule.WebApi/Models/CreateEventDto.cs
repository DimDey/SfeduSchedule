using AutoMapper;
using SfeduSchedule.Application.Common.Mappings;
using SfeduSchedule.Application.Features.DayEvents.Commands.CreateEvent;
using SfeduSchedule.Domain.Entities;

namespace SfeduSchedule.WebApi.Models
{
	public class CreateEventDto : IMapWith<CreateEventCommand>
	{
		/// <summary>
		/// GUID группы
		/// </summary>
		public Guid GroupId { get; set; }

		/// <summary>
		/// Дни недели
		/// </summary>
		public DayNumber DayNumber { get; set; }

		/// <summary>
		/// Время начала пары
		/// </summary>
		public TimeSpan Begin { get; set; }

		/// <summary>
		/// Время окончания пары
		/// </summary>
		public TimeSpan End { get; set; }

		/// <summary>
		/// Описание пары
		/// </summary>
		public string Description { get; set; }

		/// <summary>
		/// Адресс корпуса пары
		/// </summary>
		public string Address { get; set; }

		/// <summary>
		/// Кабинет, в котором проходит пара
		/// </summary>
		public string ClassRoom { get; set; }

		/// <summary>
		/// ФИО преподавателя
		/// </summary>
		public string Teacher { get; set; }

		/// <summary>
		/// Необязательное свойство. Четная/нечетная неделя
		/// </summary>
		public bool? OnEven { get; set; }

		/// <summary>
		/// Необязательное свойство. Номер подгруппы
		/// </summary>
		public int? SubGroup { get; set; }

		public void Mapping(Profile profile)
		{
			profile.CreateMap<CreateEventDto, CreateEventCommand>();
		}
	}
}
