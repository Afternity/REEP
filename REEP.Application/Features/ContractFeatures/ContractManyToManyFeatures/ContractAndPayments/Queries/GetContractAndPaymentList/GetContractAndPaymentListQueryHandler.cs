using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using REEP.Application.Interfaces.InterfaceDbContexts;

namespace REEP.Application.Features.ContractFeatures.ContractManyToManyFeatures.ContractAndPayments.Queries.GetContractAndPaymentList
{
    internal class GetContractAndPaymentListQueryHandler
        : IRequestHandler<GetContractAndPaymentListQuery, ContractAndPaymentListVm>
    {
        private readonly IReepDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<GetContractAndPaymentListQueryHandler> _logger;

        public GetContractAndPaymentListQueryHandler(
            IReepDbContext context,
            IMapper mapper,
            ILogger<GetContractAndPaymentListQueryHandler> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ContractAndPaymentListVm> Handle(GetContractAndPaymentListQuery request,
            CancellationToken cancellationToken)
        {
            var entities = await _context.ContractsAndPayments
                .Include(parent => parent.Contract)
                    .ThenInclude(child => child.ContractType)
                .Include(parent => parent.Payment)
                    .ThenInclude(child => child.PaymentType)
                .Where(contractsAndPayments => contractsAndPayments.IsDeleted == request.IsDeleted)
                .ProjectTo<ContractAndPaymentLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new ContractAndPaymentListVm() { ContractsAndPayments = entities };
        }
    }
}
