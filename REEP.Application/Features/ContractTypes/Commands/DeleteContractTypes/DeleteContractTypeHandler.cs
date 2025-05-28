using REEP.Application.Common.Exceptions;
using REEP.Domain.Models.ContractModels.ContractTypeModels;
using MediatR;
using REEP.Application.Interfaces.InterfaceRepositories;

namespace REEP.Application.Features.ContractTypes.Commands.DeleteContractTypes
{
    public class DeleteContractTypeHandler : IRequestHandler<DeleteContractTypeCommand, Unit>
    {
        private readonly IContractTypeRepository _repository;

        public DeleteContractTypeHandler(IContractTypeRepository repository) =>
            _repository = repository;
        

        public async Task<Unit> Handle(DeleteContractTypeCommand request, CancellationToken cancellationToken)
        {
            var contractType = await _repository.GetByIdAsync(request.Id, cancellationToken);

            if (contractType == null || contractType.Id != request.Id)
                throw new NotFoundException(nameof(ContractType), request.Id);

            await _repository.DeleteAsync(contractType);

            return Unit.Value;
        }
    }
}
