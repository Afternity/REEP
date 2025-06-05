using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using REEP.Application.Interfaces.InterfaceDbContexts;

namespace REEP.Application.Features.ContractFeatures.Contracts.Queries.GetContractList
{
    public class GetContractListCommandHandler
        : IRequestHandler<GetContractListCommand, ContractListVm>
    {
        private readonly IReepDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<GetContractListCommandHandler> _logger;

        public GetContractListCommandHandler(
            IReepDbContext context,
            IMapper mapper,
            ILogger<GetContractListCommandHandler> logger) =>
            (_context, _mapper, _logger) = (context, mapper, logger);

        public async Task<ContractListVm> Handle(GetContractListCommand request, CancellationToken cancellationToken)
        {
            var entities = await _context.Contracts
                .Include(parent => parent.ContractType)
                .Where(entity => entity.IsDeleted == request.IsDeleted)
                .ProjectTo<ContractLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new ContractListVm { Contracts = entities };
        }
    }
}
