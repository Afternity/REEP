using REEP.Domain.Models.ContractModels.ContractTypeModels;
using MediatR;
using REEP.Application.Interfaces.InterfaceRepositories;

namespace REEP.Application.Features.ContractTypes.Commands.CreateContractType
{
    public class CreateContractTypeHandler : IRequestHandler<CreateContractTypeCommand, Guid>
    {
        private readonly IContractTypeRepository _contractTypeRepository;

        public CreateContractTypeHandler(IContractTypeRepository contractTypeRepository) =>
            _contractTypeRepository = contractTypeRepository;

        public async Task<Guid> Handle(
            CreateContractTypeCommand request,
            CancellationToken cancellationToken)
        {
            var contractType = new ContractType
            {
                Id = Guid.NewGuid(),
                Type = request.Type,
                IsDeleted = request.IsDeleted,
            };

            await _contractTypeRepository.CreateAsync(contractType, cancellationToken);

            return contractType.Id;
        }
    }
}
