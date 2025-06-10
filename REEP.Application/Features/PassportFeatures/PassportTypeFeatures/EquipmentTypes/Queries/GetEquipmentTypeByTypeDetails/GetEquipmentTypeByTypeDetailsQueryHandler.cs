using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using REEP.Application.Common.Exceptions;
using REEP.Application.Interfaces.InterfaceDbContexts;

namespace REEP.Application.Features.EquipmentFeatures.EquipmentTypesFeatures.EquipmentTypes.Queries.GetEquipmentTypeByTypeDetails
{
    internal class GetStatusTypeByTypeDetailsQueryHandler
        : IRequestHandler<GetStatusTypeByTypeDetailsQuery, StatusTypeByTypeDetailsVm>
    {
        private readonly IReepDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<GetStatusTypeByTypeDetailsQueryHandler> _logger;

        public GetStatusTypeByTypeDetailsQueryHandler(
            IReepDbContext context, IMapper mapper, ILogger<GetStatusTypeByTypeDetailsQueryHandler> logger) =>
            (_context, _mapper, _logger) = (context, mapper, logger);

        public async Task<StatusTypeByTypeDetailsVm> Handle(GetStatusTypeByTypeDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.SupplierTypes.FirstOrDefaultAsync(supplierType =>
                supplierType.Type == request.Type, cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(entity), request.Type);

            return _mapper.Map<StatusTypeByTypeDetailsVm>(entity);
        }
    }
}
