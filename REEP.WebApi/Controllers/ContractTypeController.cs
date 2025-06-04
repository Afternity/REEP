using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using REEP.Application.Features.ContractTypes.Commands.CreateContractType;
using REEP.Application.Features.ContractTypes.Commands.HardDeleteContractType;
using REEP.Application.Features.ContractTypes.Commands.SoftDeleteContractType;
using REEP.Application.Features.ContractTypes.Commands.UpdateContractType;
using REEP.Application.Features.ContractTypes.Queries.GetContractTypesDetails;
using REEP.Application.Features.ContractTypes.Queries.GetContractTypesList;

namespace REEP.WebApi.Controllers
{
    public class ContractTypeController : BaseContraller
    {
        private readonly IMapper _mapper;
        private readonly ILogger<ContractTypeController> _logger;

        public ContractTypeController(IMapper mapper, ILogger<ContractTypeController> logger) =>
           (_mapper, _logger) = (mapper, logger);

        [HttpGet("{bool}/get-all")]
        public async Task<ActionResult<ContractTypeListVm>> GetAll(bool isDeleted)
        {
            var query = new GetContractTypesListQuery()
            {
                IsDeleted = isDeleted
            };

            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ContractTypeDetailsVm>> Get(Guid id)
        {
            _logger.LogInformation($"guid = {id}");

            var query = new GetContractTypeDetailsQuery 
            {
                Id = id 
            };

            _logger.LogInformation($"query.Id == {query.Id}");

            var vm = await Mediator.Send(query);

            _logger.LogInformation($"vm == {vm.Type}");

            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateContractTypeDto createContractTypeDto)
        {
            var command = _mapper.Map<CreateContractTypeCommand>(createContractTypeDto);
            var noteId = await Mediator.Send(command);
            return Ok(noteId);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateContractTypeDto updateContractTypeDto)
        {
            var command = _mapper.Map<UpdateContractTypeCommand>(updateContractTypeDto);
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpPut("soft-delete")]
        public async Task<IActionResult> SoftDelete([FromBody] SoftDeleteContractTypeDto softDeleteContractTypeDto)
        {
            var command = _mapper.Map<SoftDeleteContractTypeCommand>(softDeleteContractTypeDto);
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> HardDelete(Guid id)
        {
            var command = new HardDeleteContractTypeCommand
            {
                Id = id
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
