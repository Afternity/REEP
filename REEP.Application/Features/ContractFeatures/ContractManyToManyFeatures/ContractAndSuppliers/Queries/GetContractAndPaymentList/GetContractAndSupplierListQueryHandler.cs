using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using REEP.Application.Features.ContractFeatures.ContractManyToManyFeatures.ContractAndPayments.Queries.GetContractAndPaymentList;
using REEP.Application.Interfaces.InterfaceDbContexts;

namespace REEP.Application.Features.ContractFeatures.ContractManyToManyFeatures.ContractAndSuppliers.Queries.GetContractAndPaymentList
{
    public class GetContractAndSupplierListQueryHandler
        : IRequestHandler<GetContractAndSupplierListQuery, ContractAndSupplierListVm>
    {
        private readonly IReepDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<GetContractAndSupplierListQueryHandler> _logger;

        public GetContractAndSupplierListQueryHandler(
            IReepDbContext context,
            IMapper mapper,
            ILogger<GetContractAndSupplierListQueryHandler> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ContractAndSupplierListVm> Handle(GetContractAndSupplierListQuery request,
            CancellationToken cancellationToken)
        {
            var entities = await _context.ContractsAndSuppliers
               .Include(parent => parent.Contract)
                   .ThenInclude(child => child.ContractType)
               .Include(parent => parent.Supplier)
                   .ThenInclude(child => child.SupplierType)
               .Where(contractsAndPayments => contractsAndPayments.IsDeleted == request.IsDeleted)
               .ProjectTo<ContractAndSupplierLookupDto>(_mapper.ConfigurationProvider)
               .ToListAsync(cancellationToken);

            return new ContractAndSupplierListVm() { ContractsAndSuppliers = entities };
        }
    }
}
