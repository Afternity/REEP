using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using REEP.Application.Features.ContractFeatures.ContractManyToManyFeatures.ContractAndSuppliers.Commands.CreateContractAndSupplier;
using REEP.Application.Features.ContractFeatures.ContractManyToManyFeatures.ContractAndSuppliers.Commands.HardDeleteContractAndSupplier;
using REEP.Application.Features.ContractFeatures.ContractManyToManyFeatures.ContractAndSuppliers.Commands.SoftDeleteContractAndSupplier;
using REEP.Application.Features.ContractFeatures.ContractManyToManyFeatures.ContractAndSuppliers.Commands.UpdateContractAndSupplier;
using REEP.Application.Features.ContractFeatures.ContractManyToManyFeatures.ContractAndSuppliers.Queries.GetContractAndPaymentDetails;
using REEP.Application.Features.ContractFeatures.ContractManyToManyFeatures.ContractAndSuppliers.Queries.GetContractAndPaymentList;

namespace REEP.WebApi.Controllers.ContractControllers.ContractManyToManyControllers
{
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ContractAndSupplierController : BaseContraller
    {
        private IMapper _mapper;
        private ILogger<ContractAndSupplierController> _logger;

        public ContractAndSupplierController(
           IMapper mapper,
           ILogger<ContractAndSupplierController> logger) =>
           (_mapper, _logger) = (mapper, logger);

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateContractAndSupplierDto createContractAndSupplierDto)
        {
            var command = _mapper.Map<CreateContractAndSupplierCommand>(createContractAndSupplierDto);
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateContractAndSupplierDto updateContractAndSupplierDto)
        {
            var command = _mapper.Map<UpdateContractAndSupplierCommand>(updateContractAndSupplierDto);
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpPut("soft-delete")]
        public async Task<IActionResult> SoftDelete([FromBody] SoftDeleteContractAndSupplierDto softDeleteContractAndSupplierDto)
        {
            var command = _mapper.Map<SoftDeleteContractAndSupplierCommand>(softDeleteContractAndSupplierDto);
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> HardDelete([FromBody] HardDeleteContractAndSupplierDto hardDeleteContractAndSupplierDto)
        {
            var command = _mapper.Map<HardDeleteContractAndSupplierCommand>(hardDeleteContractAndSupplierDto);
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<ContractAndSupplierDetailsVm>> Get([FromBody] ContractAndSupplierDetailsDto contractAndSupplierDetailsDto)
        {
            var query = _mapper.Map<GetContractAndSupplierDetailsQuery>(contractAndSupplierDetailsDto);
            var contractAndSupplierDetailsVm = await Mediator.Send(query);
            return Ok(contractAndSupplierDetailsVm);
        }

        [HttpGet("{isDeleted}/get-all")]
        public async Task<ActionResult<ContractAndSupplierListVm>> GetAll(bool isDeleted)
        {

            var query = new GetContractAndSupplierListQuery()
            {
                IsDeleted = isDeleted
            };
            var contractsAndPaymentsListVm = await Mediator.Send(query);
            return Ok(contractsAndPaymentsListVm);
        }
    }
}
