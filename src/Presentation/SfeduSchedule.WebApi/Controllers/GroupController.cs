using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SfeduSchedule.Application.Features.Groups.Commands.CreateGroup;
using SfeduSchedule.Application.Features.Groups.Commands.DeleteGroup;
using SfeduSchedule.Application.Features.Groups.Commands.UpdateGroup;
using SfeduSchedule.Application.Features.Groups.Queries.GetGroupDetails;
using SfeduSchedule.WebApi.Models;

namespace SfeduSchedule.WebApi.Controllers
{
    public class GroupController : BaseController
    {
        private readonly IMapper _mapper;

        public GroupController(IMapper mapper)
        {
            _mapper = mapper;
        }
        
        [Route("{id}")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<GroupDetailsVm>> Get(Guid id)
        {
            var query = new GetGroupDetailsQuery()
            {
                Id = id
            };

            var result = await Mediator.Send(query);

            return Ok(result);
        }

        
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateGroupDto model)
        {
            var command = _mapper.Map<CreateGroupCommand>(model);

            var result = await Mediator.Send(command);
            return Ok();
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Update([FromBody] UpdateGroupDto model)
        {
            var command = _mapper.Map<UpdateGroupCommand>(model);
            await Mediator.Send(command);
            return NoContent();
        }

        [Route("{id}")]
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeleteGroupCommand()
            {
                Id = id
            };
            await Mediator.Send(command);
            
            return NoContent();
        }
        
    }
}

