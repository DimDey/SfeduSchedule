using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SfeduSchedule.Application.Feature.Groups.Commands.CreateGroup;
using SfeduSchedule.Application.Feature.Groups.Commands.DeleteGroup;
using SfeduSchedule.Application.Feature.Groups.Commands.UpdateGroup;
using SfeduSchedule.Application.Feature.Groups.Queries.GetFacultyGroups;
using SfeduSchedule.Application.Feature.Groups.Queries.GetGroupDetails;
using SfeduSchedule.Application.ViewModels;
using SfeduSchedule.WebApi.Models;

namespace SfeduSchedule.WebApi.Controllers
{
    public class GroupController : BaseController
    {
        private readonly IMapper _mapper;

        public GroupController(IMapper mapper) => _mapper = mapper;


        /// <summary>
        /// Gets the simple list of groups by Faculty GUID
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        /// </remarks>
        /// <param name="facultyId">Faculty GUID</param>
        /// <returns>Returns List GroupModel</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpGet("{facultyId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<List<FacultyGroupVm>>> GetFacultyGroups(Guid facultyId)
        {
            var query = new GetFacultyGroupsQuery()
            {
                FacultyId = facultyId
            };

            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
    
        /// <summary>
        /// Gets the group details data.
        /// </summary>
        /// <param name="id">Group GUID</param>
        /// <returns>Returns GroupDetailsViewModel</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<GroupDetailsVm>> GetGroupDetails(Guid id)
        {
            var query = new GetGroupDetailsQuery()
            {
                Id = id
            };

            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Create a group entity by DTO
        /// </summary>
        /// <param name="createGroupDto">Group params</param>
        /// <returns>New Group entity GUID</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateGroupDto createGroupDto)
        {
            var command = _mapper.Map<CreateGroupCommand>(createGroupDto);
            // TODO: Remove facultyGuid and add mapping from user identity
            var groupId = await Mediator.Send(command);

            return Ok(groupId);
        }
        
        /// <summary>
        /// Update the group info
        /// </summary>
        /// <param name="updateGroupDto">Group data</param>
        /// <returns>Nothing</returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> Update([FromBody] UpdateGroupDto updateGroupDto)
        {
            // TODO: Remove facultyGuid and add mapping from user identity
            var command = _mapper.Map<UpdateGroupCommand>(updateGroupDto);

            await Mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Delete the group entity.
        /// </summary>
        /// <param name="id">Group GUID</param>
        /// <returns>Nothing</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeleteGroupCommand()
            {
                Id = id
            };
            var result = await Mediator.Send(command);

            return NoContent();
        }
    }
}
