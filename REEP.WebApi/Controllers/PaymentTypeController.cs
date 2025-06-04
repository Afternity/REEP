using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using REEP.Application.Features.PaymentTypes.Commands.CreatePaymentType;
using REEP.Application.Features.PaymentTypes.Commands.HardDeletePaymentType;
using REEP.Application.Features.PaymentTypes.Commands.SoftDeletePaymetType;
using REEP.Application.Features.PaymentTypes.Commands.UpdatePaymentType;
using REEP.Application.Features.PaymentTypes.Queries.GetPaymentTypeDetails;
using REEP.Application.Features.PaymentTypes.Queries.GetPaymentTypeList;
using REEP.Application.Interfaces.InterfaceDbContexts;

namespace REEP.WebApi.Controllers
{
    public class PaymentTypeController : BaseContraller
    {
        private readonly IMapper _mapper;
        private readonly ILogger<PaymentTypeController> _logger;

        public PaymentTypeController(IMapper mapper, ILogger<PaymentTypeController> logger) =>
            (_mapper, _logger) = (mapper, logger);


        [HttpGet("{isDeleted}/get-all")]
        public async Task<ActionResult<PaymentTypeListVm>> GetAll(bool isDeleted)
        {
            var query = new GetPaymentTypeListQuery()
            {
                IsDeleted = isDeleted
            };

            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentTypeDetailsVm>> Get(Guid id)
        {
            var query = new GetPaymentTypeDetailsQuery
            {
                Id = id
            };

            var vm = await Mediator.Send(query);

            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreatePaymentTypeDto createPaymentTypeDto)
        {
            _logger.LogInformation($"dto.type = {createPaymentTypeDto.Type}, dto.isDeleted = {createPaymentTypeDto.IsDeleted}");
            var command = _mapper.Map<CreatePaymentTypeCommand>(createPaymentTypeDto);
            _logger.LogInformation($"command.type = {command.Type}, command.isDeleted = {command.IsDeleted}");
            var noteId = await Mediator.Send(command);
            return Ok(noteId);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdatePaymentTypeDto updatePaymentTypeDto)
        {
            var command = _mapper.Map<UpdatePaymentTypeCommand>(updatePaymentTypeDto);
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpPut("soft-delete")]
        public async Task<IActionResult> SoftDelete([FromBody] SoftDeletePaymentTypeDto softDeletePaymentTypeDto)
        {
            var command = _mapper.Map<SoftDeletePaymentTypeCommand>(softDeletePaymentTypeDto);
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> HardDelete(Guid id)
        {
            var command = new HardDeletePaymentTypeCommand
            {
                Id = id
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
