using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using REEP.Application.Features.ContractFeatures.Payments.Commands.CreatePayment;
using REEP.Application.Features.ContractFeatures.Payments.Commands.HardDeletePayment;
using REEP.Application.Features.ContractFeatures.Payments.Commands.SoftDeletePayment;
using REEP.Application.Features.ContractFeatures.Payments.Commands.UpdatePayment;
using REEP.Application.Features.ContractFeatures.Payments.Queries.GetPaymentDetails;
using REEP.Application.Features.ContractFeatures.Payments.Queries.GetPaymentList;

namespace REEP.WebApi.Controllers.ContractControllers
{
    public class PaymentController : BaseContraller
    {
        private readonly IMapper _mapper;
        private readonly ILogger<PaymentController> _logger;

        public PaymentController(
            IMapper mapper,
            ILogger<PaymentController> logger) =>
            (_mapper, _logger) = (mapper, logger);

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreatePaymentDto createPaymentDto)
        {
            var command = _mapper.Map<CreatePaymentCommand>(createPaymentDto);
            var paymentId = await Mediator.Send(command);
            return Ok(paymentId);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdatePaymentDto updatePaymentDto)
        {
            var command = _mapper.Map<UpdatePaymentCommand>(updatePaymentDto);
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpPut("soft-delete")]
        public async Task<IActionResult> SoftDelete([FromBody] SoftDeletePaymentDto softDeletePaymentDto)
        {
            var command = _mapper.Map<SoftDeletePaymentCommand>(softDeletePaymentDto);
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> HardDelete(Guid id)
        {
            var command = new HardDeletePaymentCommand()
            {
                Id = id
            };
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentDetailsVm>> Get(Guid id)
        {
            var query = new GetPaymentDetailsQuery()
            {
                Id = id
            };
            var contractDetailsVm = await Mediator.Send(query);
            return Ok(contractDetailsVm);
        }

        [HttpGet("{isDeleted}/get-all")]
        public async Task<ActionResult<PaymentListVm>> GetAll(bool isDeleted)
        {

            var query = new GetPaymentListQuery()
            {
                IsDeleted = isDeleted
            };
            var contractDetailsVm = await Mediator.Send(query);
            return Ok(contractDetailsVm);
        }
    }
}
