using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using REEP.Application.Features.ContractFeatures.ContractTypesFeatures.ContractTypes.Queries.GetContractTypeDetails;
using REEP.Application.Interfaces.InterfaceDbContexts;
using REEP.Application.Common.Exceptions;

namespace REEP.Application.Features.ContractFeatures.Contracts.Queries.GetContractDetails
{
    public class GetContractDetailsQueryHandler
        : IRequestHandler<GetContractDetailsQuery, ContractDetailsVm>
    {
        private readonly IReepDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<GetContractTypeDetailsQueryHandler> _logger;

        public GetContractDetailsQueryHandler(
            IReepDbContext context, IMapper mapper, ILogger<GetContractTypeDetailsQueryHandler> logger) =>
            (_context, _mapper, _logger) = (context, mapper, logger);

        public async Task<ContractDetailsVm> Handle(GetContractDetailsQuery request, CancellationToken cancellationToken)
        {
            var contract = await _context.Contracts
                .Include(parent => parent.ContractType) 
                .FirstOrDefaultAsync(entity => entity.Id == request.Id, cancellationToken);

            if (contract == null || contract.Id != request.Id)
                throw new NotFoundException(nameof(contract), request.Id);

            return _mapper.Map<ContractDetailsVm>(contract);
        }
    }
}
