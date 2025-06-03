using REEP.Application.Common.Exceptions;
using REEP.Domain.Models.ContractModels.ContractTypeModels;
using MediatR;
using REEP.Application.Interfaces.InterfaceRepositories;

namespace REEP.Application.Features.ContractTypes.Commands.UpdateContractType
{
    public class UpdateContractTypeHandler : IRequestHandler<UpdateContractTypeCommand, Unit>
    {
        private readonly IContractTypeRepository _repository;

        public UpdateContractTypeHandler(IContractTypeRepository contractTypeRepository) =>
            _repository = contractTypeRepository;

        public async Task<Unit> Handle(
            UpdateContractTypeCommand request,
            CancellationToken cancellationToken)
        {
            var contractType = await _repository.GetByIdAsync(request.Id, cancellationToken);

            if (contractType == null || contractType.Id != request.Id)
                throw new NotFoundException(nameof(contractType), request.Id);
            

            contractType.Type = request.Type;
            contractType.UpdatedAt = DateTime.UtcNow;

            await _repository.UpdateAsync(contractType);  
            
            return Unit.Value;
        }
    }
}
