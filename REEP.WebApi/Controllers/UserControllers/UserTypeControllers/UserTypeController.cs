using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using REEP.Application.Features.UserFeatures.UserTypeFeatures.UserTypes.Commands.CreateUserType;
using REEP.Application.Features.UserFeatures.UserTypeFeatures.UserTypes.Commands.HardDelereUserType;
using REEP.Application.Features.UserFeatures.UserTypeFeatures.UserTypes.Commands.SoftDeleteUserType;
using REEP.Application.Features.UserFeatures.UserTypeFeatures.UserTypes.Commands.UpdateUserType;
using REEP.Application.Features.UserFeatures.UserTypeFeatures.UserTypes.Queries.GetUserTypeByTypeDetails;
using REEP.Application.Features.UserFeatures.UserTypeFeatures.UserTypes.Queries.GetUserTypeDetails;
using REEP.Application.Features.UserFeatures.UserTypeFeatures.UserTypes.Queries.GetUserTypeList;

namespace REEP.WebApi.Controllers.UserControllers.UserTypeControllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class UserTypeController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly ILogger<UserTypeController> _logger;

        public UserTypeController(
            IMapper mapper,
            ILogger<UserTypeController> logger) =>
            (_mapper, _logger) = (mapper, logger);

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateUserTypeDto createUserTypeDto)
        {
            var command = _mapper.Map<CreateUserTypeCommand>(createUserTypeDto);
            var userTypeId = await Mediator.Send(command);
            return Ok(userTypeId);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateUserTypeDto updateUserTypeDto)
        {
            var command = _mapper.Map<UpdateUserTypeCommand>(updateUserTypeDto);
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpPut("soft-delete")]
        public async Task<IActionResult> SoftDelete([FromBody] SoftDeleteUserTypeDto softDeleteUserTypeDto)
        {
            var command = _mapper.Map<SoftDeleteUserTypeCommand>(softDeleteUserTypeDto);
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> HardDelete(Guid id)
        {
            var command = new HardDeleteUserTypeCommand()
            {
                Id = id
            };
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpGet("{type}/by-type")]
        public async Task<ActionResult<UserTypeByTypeDetailsVm>> GetByType(string type)
        {
            var query = new GetUserTypeByTypeDetailsQuery()
            {
                Type = type
            };
            var userTypeByTypeDetailsVm = await Mediator.Send(query);
            return Ok(userTypeByTypeDetailsVm);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserTypeDetailsVm>> Get(Guid id)
        {
            var query = new GetUserTypeDetailsQuery()
            {
                Id = id
            };
            var userTypeDetailsVm = await Mediator.Send(query);
            return Ok(userTypeDetailsVm);
        }

        [HttpGet("{isDeleted}/get-all")]
        public async Task<ActionResult<UserTypeListVm>> GetAll(bool isDeleted)
        {

            var query = new GetUserTypeListQuery()
            {
                IsDeleted = isDeleted
            };
            var userTypeDetailsVm = await Mediator.Send(query);
            return Ok(userTypeDetailsVm);
        }
    }
}
