﻿using REEP.Domain.Models.ContractModels.ContractTypeModels;
using MediatR;
using REEP.Application.Interfaces.InterfaceRepositories;

namespace REEP.Application.Features.ContractFeatures.ContractTypesFeatures.ContractTypes.Commands.CreateContractType
{
    public class CreateContractTypeCommandHandler : IRequestHandler<CreateContractTypeCommand, Guid>
    {
        private readonly IContractTypeRepository _repository;

        public CreateContractTypeCommandHandler(IContractTypeRepository repository) =>
            _repository = repository;

        public async Task<Guid> Handle(CreateContractTypeCommand request,
            CancellationToken cancellationToken)
        {
            var contractType = new ContractType
            {
                Id = Guid.NewGuid(),
                Type = request.Type,
                IsDeleted = request.IsDeleted,
            };

            await _repository.CreateAsync(contractType, cancellationToken);

            return contractType.Id;
        }
    }
}
