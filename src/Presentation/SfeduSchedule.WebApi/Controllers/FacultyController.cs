using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SfeduSchedule.Application.Features.Faculties.Commands.CreateFaculty;
using SfeduSchedule.Application.Features.Faculties.Commands.DeleteFaculty;
using SfeduSchedule.Application.Features.Faculties.Commands.UpdateFaculty;
using SfeduSchedule.Application.Features.Faculties.Queries.GetInstituteFaculties;
using SfeduSchedule.Application.Features.Institutes.Commands.CreateInstitute;
using SfeduSchedule.Application.Features.Institutes.Commands.DeleteInstitute;
using SfeduSchedule.Application.Features.Institutes.Commands.UpdateInstitute;
using SfeduSchedule.Application.Features.Institutes.Queries.GetInsituteList;
using SfeduSchedule.WebApi.Models;

namespace SfeduSchedule.WebApi.Controllers;

public class FacultyController : BaseController
{
    private readonly IMapper _mapper;

    public FacultyController(IMapper mapper)
    {
        _mapper = mapper;
    }
    
    [Route("Insitute/{id}")]
    [HttpGet]
    public async Task<ActionResult<InstituteListVm>> Get(Guid id)
    {
        var query = new GetInstituteFacultiesCommand()
        {
            InstituteId = id
        };

        var result = await Mediator.Send(query);

        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Create([FromBody] CreateFacultyDto model)
    {
        var command = _mapper.Map<CreateFacultyCommand>(model);

        var result = await Mediator.Send(command);

        return Ok(result);
    }

    [HttpPut]
    public async Task<ActionResult> Update([FromBody] UpdateFacultyDto model)
    {
        var command = _mapper.Map<UpdateFacultyCommand>(model);
    
        var result = await Mediator.Send(command);
        return NoContent();
    }

    [Route("{id}")]
    [HttpDelete]
    public async Task<ActionResult> Delete(Guid id)
    {
        var command = new DeleteFacultyCommand()
        {
            Id = id
        };

        await Mediator.Send(command);

        return NoContent();
    }
}