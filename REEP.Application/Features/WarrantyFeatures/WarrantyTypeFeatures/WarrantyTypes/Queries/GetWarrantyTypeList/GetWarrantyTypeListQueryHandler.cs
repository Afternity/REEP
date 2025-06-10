using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using REEP.Application.Features.ContractFeatures.ContractTypesFeatures.PaymentTypes.Queries.GetPaymentTypeList;
using REEP.Application.Interfaces.InterfaceDbContexts;

namespace REEP.Application.Features.WarrantyFeatures.WarrantyTypesFeatures.WarrantyTypes.Queries.GetWarrantyTypeList
{
    public class GetEquipmentTypeListQueryHandler
        : IRequestHandler<GetEquipmentTypeListQuery, EquipmentTypeListVm>
    {
        private readonly IReepDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<GetEquipmentTypeListQueryHandler> _logger;

        public GetEquipmentTypeListQueryHandler(
            IReepDbContext context, IMapper mapper, ILogger<GetEquipmentTypeListQueryHandler> logger) =>
            (_context, _mapper, _logger) = (context, mapper, logger);

        public async Task<EquipmentTypeListVm> Handle(GetEquipmentTypeListQuery request,
            CancellationToken cancellationToken)
        {
            var entities = await _context.SupplierTypes
                .Where(supplierTypes =>supplierTypes.IsDeleted == request.IsDeleted)
                .ProjectTo<EquipmentTypeLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new EquipmentTypeListVm { SupplierTypes = entities };
        }
    }
}
