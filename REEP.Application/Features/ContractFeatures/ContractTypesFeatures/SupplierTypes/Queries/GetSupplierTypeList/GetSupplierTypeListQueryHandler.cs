using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using REEP.Application.Features.ContractFeatures.ContractTypesFeatures.PaymentTypes.Queries.GetPaymentTypeList;
using REEP.Application.Interfaces.InterfaceDbContexts;

namespace REEP.Application.Features.ContractFeatures.ContractTypesFeatures.SupplierTypes.Queries.GetSupplierTypeList
{
    public class GetSupplierTypeListQueryHandler
        : IRequestHandler<GetSupplierTypeListQuery, SupplierTypeListVm>
    {
        private readonly IReepDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<GetPaymentTypeListQueryHandler> _logger;

        public GetSupplierTypeListQueryHandler(
            IReepDbContext context, IMapper mapper, ILogger<GetPaymentTypeListQueryHandler> logger) =>
            (_context, _mapper, _logger) = (context, mapper, logger);

        public async Task<SupplierTypeListVm> Handle(GetSupplierTypeListQuery request,
            CancellationToken cancellationToken)
        {
            var entities = await _context.SupplierTypes
                .Where(supplierTypes =>supplierTypes.IsDeleted == request.IsDeleted)
                .ProjectTo<SupplierTypeLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new SupplierTypeListVm { SupplierTypes = entities };
        }
    }
}
