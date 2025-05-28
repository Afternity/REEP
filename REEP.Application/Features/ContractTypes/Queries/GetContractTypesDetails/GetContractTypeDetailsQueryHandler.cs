using REEP.Application.Common.Exceptions;
using REEP.Domain.Models.ContractModels.ContractTypeModels;
using AutoMapper;
using MediatR;
using REEP.Application.Interfaces.InterfaceRepositories;

namespace REEP.Application.Features.ContractTypes.Queries.GetContractTypesDetails
{
    public class GetContractTypeDetailsQueryHandler
        : IRequestHandler<GetContractTypeDetailsQuery, ContractTypeDetailsVm>
    {
        private readonly IContractTypeRepository _repository;
        private readonly IMapper _mapper;

        public GetContractTypeDetailsQueryHandler(
            IContractTypeRepository repository, IMapper mapper) =>
            (_repository, _mapper) = (repository, mapper);
        
        public async Task<ContractTypeDetailsVm> Handle(
            GetContractTypeDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var contractType = await _repository.GetByIdAsync(request.Id, cancellationToken);

            if (contractType == null || contractType.Id != request.Id) 
                throw new NotFoundException(nameof(ContractType), request.Id);

            return _mapper.Map<ContractTypeDetailsVm>(contractType);
        }
    }
}
