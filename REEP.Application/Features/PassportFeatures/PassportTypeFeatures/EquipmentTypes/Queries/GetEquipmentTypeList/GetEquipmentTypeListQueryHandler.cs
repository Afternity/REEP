using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using REEP.Application.Interfaces.InterfaceDbContexts;

namespace REEP.Application.Features.EquipmentFeatures.EquipmentTypesFeatures.EquipmentTypes.Queries.GetEquipmentTypeList
{
    public class GetStatusTypeListQueryHandler
        : IRequestHandler<GetStatusTypeListQuery, StatusTypeListVm>
    {
        private readonly IReepDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<GetStatusTypeListQueryHandler> _logger;

        public GetStatusTypeListQueryHandler(
            IReepDbContext context, IMapper mapper, ILogger<GetStatusTypeListQueryHandler> logger) =>
            (_context, _mapper, _logger) = (context, mapper, logger);

        public async Task<StatusTypeListVm> Handle(GetStatusTypeListQuery request,
            CancellationToken cancellationToken)
        {
            var entities = await _context.SupplierTypes
                .Where(supplierTypes =>supplierTypes.IsDeleted == request.IsDeleted)
                .ProjectTo<StatusTypeLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new StatusTypeListVm { EquipmentTypes = entities };
        }
    }
}
