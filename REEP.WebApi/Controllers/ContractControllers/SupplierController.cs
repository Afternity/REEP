using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using REEP.Application.Features.ContractFeatures.Suppliers.Commands.CreateSupplier;
using REEP.Application.Features.ContractFeatures.Suppliers.Commands.HardDeleteSupplier;
using REEP.Application.Features.ContractFeatures.Suppliers.Commands.SoftDeleteSupplier;
using REEP.Application.Features.ContractFeatures.Suppliers.Commands.UpdateSupplier;
using REEP.Application.Features.ContractFeatures.Suppliers.Queries.GetSupplierDetails;
using REEP.Application.Features.ContractFeatures.Suppliers.Queries.GetSupplierList;

namespace REEP.WebApi.Controllers.ContractControllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class SupplierController: BaseController
    {
        private readonly IMapper _mapper;
        private readonly ILogger<SupplierController> _logger;

        public SupplierController(
            IMapper mapper,
            ILogger<SupplierController> logger) =>
            (_mapper, _logger) = (mapper, logger);

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateSupplierDto createSupplierDto)
        {
            var command = _mapper.Map<CreateSupplierCommand>(createSupplierDto);
            var supplierId = await Mediator.Send(command);
            return Ok(supplierId);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateSupplierDto updateSupplierDto)
        {
            var command = _mapper.Map<UpdateSupplierCommand>(updateSupplierDto);
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpPut("soft-delete")]
        public async Task<IActionResult> SoftDelete([FromBody] SoftDeleteSupplierDto softDeleteSupplierDto)
        {
            var command = _mapper.Map<SoftDeleteSupplierCommand>(softDeleteSupplierDto);
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> HardDelete(Guid id)
        {
            var command = new HardDeleteSupplierCommand()
            {
                Id = id
            };
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SupplierDetailsVm>> Get(Guid id)
        {
            var query = new GetSupplierDetailsQuery()
            {
                Id = id
            };
            var supplierDetailsVm = await Mediator.Send(query);
            return Ok(supplierDetailsVm);
        }

        [HttpGet("{isDeleted}/get-all")]
        public async Task<ActionResult<SupplierListVm>> GetAll(bool isDeleted)
        {

            var query = new GetSupplierListQuery()
            {
                IsDeleted = isDeleted
            };
            var contractDetailsVm = await Mediator.Send(query);
            return Ok(contractDetailsVm);
        }
    }
}
