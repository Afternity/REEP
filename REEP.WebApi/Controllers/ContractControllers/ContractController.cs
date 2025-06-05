using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using REEP.Application.Features.ContractFeatures.Contracts.Commands.CreateContract;
using REEP.Application.Features.ContractFeatures.Contracts.Commands.HardDeleteContract;
using REEP.Application.Features.ContractFeatures.Contracts.Commands.SoftDeleteContract;
using REEP.Application.Features.ContractFeatures.Contracts.Commands.UpdateContract;
using REEP.Application.Features.ContractFeatures.Contracts.Queries.GetContractDetails;
using REEP.Application.Features.ContractFeatures.Contracts.Queries.GetContractList;

namespace REEP.WebApi.Controllers.ContractControllers
{
    public class ContractController : BaseContraller
    {
        private readonly IMapper _mapper;
        private readonly ILogger<ContractController> _logger;

        public ContractController(
            IMapper mapper,
            ILogger<ContractController> logger) =>
            (_mapper, _logger) = (mapper, logger);

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateContractDto createContractDto)
        {
            var command = _mapper.Map<CreateContractCommand>(createContractDto);
            var contractId = await Mediator.Send(command);
            return Ok(contractId);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateContractDto updateContractDto)
        {
            var command = _mapper.Map<UpdateContractCommand>(updateContractDto);
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpPut("soft-delete")]
        public async Task<IActionResult> SoftDelete([FromBody] SoftDeleteContractDto softDeleteContractDto)
        {
            var command = _mapper.Map<SoftDeleteContractCommand>(softDeleteContractDto);
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> HardDelete(Guid id)
        {
            var command = new HardDeleteContractCommand()
            {
                Id = id
            };
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ContractDetailsVm>> Get(Guid id)
        {
            var query = new GetContractDetailsQuery()
            {
                Id = id
            };
            var contractDetailsVm = await Mediator.Send(query);
            return Ok(contractDetailsVm);
        }

        [HttpGet("{isDeleted}/get-all")]
        public async Task<ActionResult<ContractListVm>> GetAll(bool isDeleted)
        {

            var query = new GetContractListCommand()
            {
                IsDeleted = isDeleted
            };
            var contractDetailsVm = await Mediator.Send(query);
            return Ok(contractDetailsVm);
        }

    }
}
