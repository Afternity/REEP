using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using REEP.Application.Features.ContractFeatures.ContractManyToManyFeatures.ContractAndPayments.Commands.CreateContractAndPayment;
using REEP.Application.Features.ContractFeatures.ContractManyToManyFeatures.ContractAndPayments.Commands.HardDeleteContractAndPayment;
using REEP.Application.Features.ContractFeatures.ContractManyToManyFeatures.ContractAndPayments.Commands.SoftDeleteContractAndPayment;
using REEP.Application.Features.ContractFeatures.ContractManyToManyFeatures.ContractAndPayments.Commands.UpdateContractAndPayment;
using REEP.Application.Features.ContractFeatures.ContractManyToManyFeatures.ContractAndPayments.Queries.GetContractAndPaymentDetails;
using REEP.Application.Features.ContractFeatures.ContractManyToManyFeatures.ContractAndPayments.Queries.GetContractAndPaymentList;

namespace REEP.WebApi.Controllers.ContractControllers.ContractManyToManyControllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ContractAndPaymentController : BaseController
    {
        private IMapper _mapper;
        private ILogger<ContractAndPaymentController> _logger;

        public ContractAndPaymentController(
           IMapper mapper,
           ILogger<ContractAndPaymentController> logger) =>
           (_mapper, _logger) = (mapper, logger);

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateContractAndPaymentDto createContractsAndPaymentsDto)
        {
            var command = _mapper.Map<CreateContractAndPaymentCommand>(createContractsAndPaymentsDto);
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateContractAndPaymentDto updateContractsAndPaymentsDto)
        {
            var command = _mapper.Map<UpdateContractAndPaymentCommand>(updateContractsAndPaymentsDto);
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpPut("soft-delete")]
        public async Task<IActionResult> SoftDelete([FromBody] SoftDeleteContractAndPaymentDto softDeleteContractsAndPaymentsDto)
        {
            var command = _mapper.Map<SoftDeleteContractAndPaymentCommand>(softDeleteContractsAndPaymentsDto);
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> HardDelete([FromBody] HardDeleteContractAndPaymentDto hardDeleteContractAndPaymentDto)
        {
            var command = _mapper.Map<HardDeleteContractAndPaymentCommand>(hardDeleteContractAndPaymentDto);
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<ContractAndPaymentDetailsVm>> Get([FromBody] ContractAndPaymentDetailsDto contractAndPaymentDetailsDto)
        {
            var query = _mapper.Map<GetContractAndPaymentDetailsQuery>(contractAndPaymentDetailsDto);
            var contractAndPaymentDetailsVm = await Mediator.Send(query);
            return Ok(contractAndPaymentDetailsVm);
        }

        [HttpGet("{isDeleted}/get-all")]
        public async Task<ActionResult<ContractAndPaymentListVm>> GetAll(bool isDeleted)
        {

            var query = new GetContractAndPaymentListQuery()
            {
                IsDeleted = isDeleted
            };
            var contractsAndPaymentsListVm = await Mediator.Send(query);
            return Ok(contractsAndPaymentsListVm);
        }
    }
}
