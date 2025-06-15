using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using REEP.Application.Features.ContractFeatures.ContractTypesFeatures.SupplierTypes.Commands.CreateSupplierType;
using REEP.Application.Features.ContractFeatures.ContractTypesFeatures.SupplierTypes.Commands.HardDeleteSupplierType;
using REEP.Application.Features.ContractFeatures.ContractTypesFeatures.SupplierTypes.Commands.SoftDeleteSupplierType;
using REEP.Application.Features.ContractFeatures.ContractTypesFeatures.SupplierTypes.Commands.UpdateSupplierType;
using REEP.Application.Features.ContractFeatures.ContractTypesFeatures.SupplierTypes.Queries.GetSupplierTypeByTypeDetails;
using REEP.Application.Features.ContractFeatures.ContractTypesFeatures.SupplierTypes.Queries.GetSupplierTypeDetails;
using REEP.Application.Features.ContractFeatures.ContractTypesFeatures.SupplierTypes.Queries.GetSupplierTypeList;

namespace REEP.WebApi.Controllers.ContractControllers.ContractTypeControllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class SupplierTypeController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly ILogger<SupplierTypeController> _logger;

        public SupplierTypeController(
            IMapper mapper,
            ILogger<SupplierTypeController> logger) =>
            (_mapper, _logger) = (mapper, logger);

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateSupplierTypeDto createSupplierTypeDto)
        {
            var command = _mapper.Map<CreateSupplierTypeCommand>(createSupplierTypeDto);
            var supplieTypeId = await Mediator.Send(command);
            return Ok(supplieTypeId);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateSupplierTypeDto updateSupplierTypeDto)
        {
            var command = _mapper.Map<UpdateSupplierTypeCommand>(updateSupplierTypeDto);
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpPut("soft-delete")]
        public async Task<IActionResult> SoftDelete([FromBody] SoftDeleteSupplierTypeDto softDeleteSupplierTypeDto)
        {
            var command = _mapper.Map<SoftDeleteSupplierTypeCommand>(softDeleteSupplierTypeDto);
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> HardDelete(Guid id)
        {
            var command = new HardDeleteSupplierTypeCommand()
            {
                Id = id
            };
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpGet("{type}/by-type")]
        public async Task<ActionResult<SupplierTypeByTypeDetailsVm>> GetByType(string type)
        {
            var query = new GetSupplierTypeByTypeDetailsQuery()
            {
                Type = type
            };
            var supplierTypeByTypeDetailsVm = await Mediator.Send(query);
            return Ok(supplierTypeByTypeDetailsVm);
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<SupplierTypeDetailsVm>> Get(Guid id)
        {
            var query = new GetSupplierTypeDetailsQuery()
            {
                Id = id
            };
            var supplierTypeDetailsVm = await Mediator.Send(query);
            return Ok(supplierTypeDetailsVm);
        }

        [HttpGet("{isDeleted}/get-all")]
        public async Task<ActionResult<SupplierTypeListVm>> GetAll(bool isDeleted)
        {
            
            var query = new GetSupplierTypeListQuery()
            {
                IsDeleted = isDeleted
            };
            var supplierTypeDetailsVm = await Mediator.Send(query);
            return Ok(supplierTypeDetailsVm);
        }
    }
}
