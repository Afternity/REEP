using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using REEP.Application.Interfaces.InterfaceDbContexts;

namespace REEP.Application.Features.ContractFeatures.ContractManyToManyFeatures.ContractAndPayments.Queries.GetContractsAndPaymentsList
{
    internal class GetContractsAndPaymentsListQueryHandler
        : IRequestHandler<GetContractsAndPaymentsListQuery, ContractsAndPaymentsListVm>
    {
        private readonly IReepDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<GetContractsAndPaymentsListQueryHandler> _logger;

        public GetContractsAndPaymentsListQueryHandler(
            IReepDbContext context,
            IMapper mapper,
            ILogger<GetContractsAndPaymentsListQueryHandler> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ContractsAndPaymentsListVm> Handle(GetContractsAndPaymentsListQuery request,
            CancellationToken cancellationToken)
        {
            var entities = await _context.ContractsAndPayments
                .Include(parent => parent.Contract)
                    .ThenInclude(child => child.ContractType)
                .Include(parent => parent.Payment)
                    .ThenInclude(child => child.PaymentType)
                .Where(contractsAndPayments => contractsAndPayments.IsDeleted == request.IsDeleted)
                .ProjectTo<ContractsAndPaymentsLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new ContractsAndPaymentsListVm() { ContractsAndPayments = entities };
        }
    }
}
