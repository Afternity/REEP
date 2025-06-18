using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using REEP.Application.Features.MaitenanceFeatures.MaintenanceRequests.Commands.CreateMaintenanceRequest;
using REEP.Application.Features.UserFeatures.Users.Commands.CreateUser;

namespace REEP.WebApi.Controllers.MaintenanceControllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class MaintenanceRequestController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly ILogger<MaintenanceRequestController> _logger;

        public MaintenanceRequestController(
            IMapper mapper,
            ILogger<MaintenanceRequestController> logger)
        {
            _mapper = mapper;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] CreateMaintenanceRequestDto createMaintenanceRequestDto)
        {
            var command = _mapper.Map<CreateMaintenanceRequestCommand>(createMaintenanceRequestDto);
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
