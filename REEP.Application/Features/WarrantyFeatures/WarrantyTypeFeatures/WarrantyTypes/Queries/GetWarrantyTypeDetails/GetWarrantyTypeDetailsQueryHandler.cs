using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using REEP.Application.Common.Exceptions;
using REEP.Application.Interfaces.InterfaceDbContexts;

namespace REEP.Application.Features.WarrantyFeatures.WarrantyTypesFeatures.WarrantyTypes.Queries.GetWarrantyTypeDetails
{
    public class GetEquipmentTypeDetailsQueryHandler
        : IRequestHandler<GetEquipmentTypeDetailsQuery, EquipmentTypeDetailsVm>
    {
        private readonly IReepDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<GetEquipmentTypeDetailsQueryHandler> _logger;

        public GetEquipmentTypeDetailsQueryHandler(
            IReepDbContext context, IMapper mapper, ILogger<GetEquipmentTypeDetailsQueryHandler> logger) =>
            (_context, _mapper, _logger) = (context, mapper, logger);

        public async Task<EquipmentTypeDetailsVm> Handle(GetEquipmentTypeDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.SupplierTypes.FirstOrDefaultAsync(supplierType =>
                supplierType.Id == request.Id, cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(entity), request.Id);

            return _mapper.Map<EquipmentTypeDetailsVm>(entity);
        }
    }
}
