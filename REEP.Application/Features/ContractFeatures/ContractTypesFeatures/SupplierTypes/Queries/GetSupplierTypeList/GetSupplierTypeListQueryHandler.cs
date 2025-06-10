using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using REEP.Application.Features.ContractFeatures.ContractTypesFeatures.PaymentTypes.Queries.GetPaymentTypeList;
using REEP.Application.Interfaces.InterfaceDbContexts;

namespace REEP.Application.Features.ContractFeatures.ContractTypesFeatures.SupplierTypes.Queries.GetSupplierTypeList
{
    public class GetWarrantyTypeListQueryHandler
        : IRequestHandler<GetWarrantyTypeListQuery, WarrantyTypeListVm>
    {
        private readonly IReepDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<GetPaymentTypeListQueryHandler> _logger;

        public GetWarrantyTypeListQueryHandler(
            IReepDbContext context, IMapper mapper, ILogger<GetPaymentTypeListQueryHandler> logger) =>
            (_context, _mapper, _logger) = (context, mapper, logger);

        public async Task<WarrantyTypeListVm> Handle(GetWarrantyTypeListQuery request,
            CancellationToken cancellationToken)
        {
            var entities = await _context.SupplierTypes
                .Where(supplierTypes =>supplierTypes.IsDeleted == request.IsDeleted)
                .ProjectTo<WarrnatyTypeLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new WarrantyTypeListVm { SupplierTypes = entities };
        }
    }
}
