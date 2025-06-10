using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using REEP.Application.Features.ContractFeatures.ContractManyToManyFeatures.ContractAndPayments.Commands.CreateContractsAndPayments;
using REEP.Application.Features.ContractFeatures.ContractManyToManyFeatures.ContractAndPayments.Commands.HardDeleteContractsAndPayments;
using REEP.Application.Features.ContractFeatures.ContractManyToManyFeatures.ContractAndPayments.Commands.SoftDeleteContractsAndPayments;
using REEP.Application.Features.ContractFeatures.ContractManyToManyFeatures.ContractAndPayments.Commands.UpdateContractsAndPayments;
using REEP.Application.Features.ContractFeatures.ContractManyToManyFeatures.ContractAndPayments.Queries.GetContractsAndPaymentsDetails;
using REEP.Application.Features.ContractFeatures.ContractManyToManyFeatures.ContractAndPayments.Queries.GetContractsAndPaymentsList;

namespace REEP.WebApi.Controllers.ContractControllers.ContractManyToManyControllers
{
    public class ContractAndPaymentsController : BaseContraller
    {
        private IMapper _mapper;
        private ILogger<ContractAndPaymentsController> _logger;

        public ContractAndPaymentsController(
           IMapper mapper,
           ILogger<ContractAndPaymentsController> logger) =>
           (_mapper, _logger) = (mapper, logger);

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateContractsAndPaymentsDto createContractsAndPaymentsDto)
        {
            var command = _mapper.Map<CreateContractsAndPaymentsCommand>(createContractsAndPaymentsDto);
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateContractsAndPaymentsDto updateContractsAndPaymentsDto)
        {
            var command = _mapper.Map<UpdateContractsAndPaymentsCommand>(updateContractsAndPaymentsDto);
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpPut("soft-delete")]
        public async Task<IActionResult> SoftDelete([FromBody] SoftDeleteContractsAndPaymentsDto softDeleteContractsAndPaymentsDto)
        {
            var command = _mapper.Map<SoftDeleteContractsAndPaymentsCommand>(softDeleteContractsAndPaymentsDto);
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> HardDelete(Guid contractId, Guid paymentId)
        {
            var command = new HardDeleteContractsAndPaymentsCommand()
            {
                ContractId = contractId,
                PaymentId = paymentId
            };
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ContractsAndPaymentsDetailsVm>> Get(Guid contractId, Guid paymentId)
        {
            var query = new GetContractsAndPaymentsDetailsQuery()
            {
                ContractId = contractId,
                PaymentId = paymentId
            };
            var contractAndPaymentDetailsVm = await Mediator.Send(query);
            return Ok(contractAndPaymentDetailsVm);
        }

        [HttpGet("{isDeleted}/get-all")]
        public async Task<ActionResult<ContractsAndPaymentsListVm>> GetAll(bool isDeleted)
        {

            var query = new GetContractsAndPaymentsListQuery()
            {
                IsDeleted = isDeleted
            };
            var contractsAndPaymentsListVm = await Mediator.Send(query);
            return Ok(contractsAndPaymentsListVm);
        }
    }
}
