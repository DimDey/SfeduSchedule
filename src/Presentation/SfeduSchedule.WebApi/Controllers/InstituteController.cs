using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SfeduSchedule.Application.Features.Institutes.Commands.CreateInstitute;
using SfeduSchedule.Application.Features.Institutes.Commands.DeleteInstitute;
using SfeduSchedule.Application.Features.Institutes.Commands.UpdateInstitute;
using SfeduSchedule.Application.Features.Institutes.Queiries.GetInsituteList;
using SfeduSchedule.WebApi.Models;

namespace SfeduSchedule.WebApi.Controllers;

public class InstituteController : BaseController
{
    private readonly IMapper _mapper;

    public InstituteController(IMapper mapper)
    {
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<InstituteListVm>> Get()
    {
        var query = new GetInstituteListQuery();

        var result = await Mediator.Send(query);

        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Create([FromBody] CreateInstituteDto model)
    {
        var command = _mapper.Map<CreateInstituteCommand>(model);

        var result = await Mediator.Send(command);

        return Ok(result);
    }

    [HttpPut]
    public async Task<ActionResult> Update([FromBody] UpdateInstituteDto model)
    {
        var command = _mapper.Map<UpdateInstituteCommand>(model);

        var result = await Mediator.Send(command);
        return NoContent();
    }

    [Route("{id}")]
    [HttpDelete]
    public async Task<ActionResult> Delete(Guid id)
    {
        var command = new DeleteInstituteCommand()
        {
            Id = id
        };

        await Mediator.Send(command);

        return NoContent();
    }
}