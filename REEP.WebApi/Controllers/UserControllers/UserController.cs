using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using REEP.Application.Features.UserFeatures.Users.Commands.CreateUser;
using REEP.Application.Features.UserFeatures.Users.Commands.CreateUserFromRegister;
using REEP.Application.Features.UserFeatures.Users.Commands.HardDeleteUser;
using REEP.Application.Features.UserFeatures.Users.Commands.SoftDeleteUser;
using REEP.Application.Features.UserFeatures.Users.Commands.UpdateUser;
using REEP.Application.Features.UserFeatures.Users.Commands.UpdateUserFromProfile;
using REEP.Application.Features.UserFeatures.Users.Queries.GetUserDetails;
using REEP.Application.Features.UserFeatures.Users.Queries.GetUserFromRegisterDetails;
using REEP.Application.Features.UserFeatures.Users.Queries.GetUserList;

namespace REEP.WebApi.Controllers.UserControllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class UserController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly ILogger<UserController> _logger;

        public UserController(
            IMapper mapper,
            ILogger<UserController> logger) =>
            (_mapper, _logger) = (mapper, logger);

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateUserDto createUserDto)
        {
            var command = _mapper.Map<CreateUserCommand>(createUserDto);
            var userId = await Mediator.Send(command);
            return Ok(userId);
        }

        [HttpPost("register")]
        public async Task<IActionResult> CreateFromRegister([FromBody] CreateUserFromRegisterDto createUserFromRegisterDto)
        {
            var command = _mapper.Map<CreateUserFromRegisterCommand>(createUserFromRegisterDto);
            var user = await Mediator.Send(command);
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateUserDto updateUserDto)
        {
            var command = _mapper.Map<UpdateUserCommand>(updateUserDto);
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpPut("profile")]
        public async Task<IActionResult> UpdateFromProfile([FromBody] UpdateUserFromProfileDto updateUserFromProfileDto)
        {
            var command = _mapper.Map<UpdateUserFromProfileCommand>(updateUserFromProfileDto);
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpPut("soft-delete")]
        public async Task<IActionResult> SoftDelete([FromBody] SoftDeleteUserDto softDeleteUserDto)
        {
            var command = _mapper.Map<SoftDeleteUserCommand>(softDeleteUserDto);
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> HardDelete(Guid id)
        {
            var command = new HardDeleteUserCommand()
            {
                Id = id
            };
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDetailsVm>> Get(Guid id)
        {
            var query = new GetUserDetailsQuery()
            {
                Id = id
            };
            var userDetailsVm = await Mediator.Send(query);
            return Ok(userDetailsVm);
        }

        [HttpGet("{email}:{password}")]
        public async Task<ActionResult<UserDetailsVm>> GetFromResiter(string email, string password)
        {
            var query = new GetUserFromRegisterDetailsQuery()
            {
                Email = email,
                Password = password
            };
            var userFromRegisterDetailsVm = await Mediator.Send(query);
            return Ok(userFromRegisterDetailsVm);
        }

        [HttpGet("{isDeleted}/get-all")]
        public async Task<ActionResult<UserListVm>> GetAll(bool isDeleted)
        {

            var query = new GetUserListQuery()
            {
                IsDeleted = isDeleted
            };
            var userTypeDetailsVm = await Mediator.Send(query);
            return Ok(userTypeDetailsVm);
        }
    }
}
