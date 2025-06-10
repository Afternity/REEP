using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using REEP.Application.Common.Exceptions;
using REEP.Application.Interfaces.InterfaceDbContexts;

namespace REEP.Application.Features.WarrantyFeatures.WarrantyTypesFeatures.WarrantyTypes.Queries.GetWarrantyTypeByTypeDetails
{
    internal class GetEquipmentTypeByTypeDetailsQueryHandler
        : IRequestHandler<GetEquipmentTypeByTypeDetailsQuery, EquipmentTypeByTypeDetailsVm>
    {
        private readonly IReepDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<GetEquipmentTypeByTypeDetailsQueryHandler> _logger;

        public GetEquipmentTypeByTypeDetailsQueryHandler(
            IReepDbContext context, IMapper mapper, ILogger<GetEquipmentTypeByTypeDetailsQueryHandler> logger) =>
            (_context, _mapper, _logger) = (context, mapper, logger);

        public async Task<EquipmentTypeByTypeDetailsVm> Handle(GetEquipmentTypeByTypeDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.SupplierTypes.FirstOrDefaultAsync(supplierType =>
                supplierType.Type == request.Type, cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(entity), request.Type);

            return _mapper.Map<EquipmentTypeByTypeDetailsVm>(entity);
        }
    }
}
