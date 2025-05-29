using REEP.Application.Features.ContractTypes.Queries.GetContractTypesList;
using Microsoft.AspNetCore.Mvc;
using REEP.Application.Features.ContractTypes.Queries.GetContractTypesDetails;
using AutoMapper;
using REEP.Application.Features.ContractTypes.Commands.CreateContractType;
using REEP.WebApi.Models;
using REEP.Application.Features.ContractTypes.Commands.UpdateContractTypes;
using REEP.Application.Features.ContractTypes.Commands.DeleteContractTypes;

namespace REEP.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ContractTypeController : BaseContraller
    {
        private readonly IMapper _mapper;

        public ContractTypeController(IMapper mapper) =>
            _mapper = mapper;

        [HttpGet]
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
        public async Task<ActionResult<ContractTypeListVm>> Get(Guid id)
        {
            var query = new GetContractTypeDetailsQuery
            {
                Id = id
            };

            var vm = await Mediator.Send(query);
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

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteContractTypeCommand
            {
                Id = id
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
