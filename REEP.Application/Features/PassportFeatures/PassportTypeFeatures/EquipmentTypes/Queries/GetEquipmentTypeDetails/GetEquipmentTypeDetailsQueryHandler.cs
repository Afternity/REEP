using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using REEP.Application.Common.Exceptions;
using REEP.Application.Interfaces.InterfaceDbContexts;

namespace REEP.Application.Features.EquipmentFeatures.EquipmentTypesFeatures.EquipmentTypes.Queries.GetEquipmentTypeDetails
{
    public class GetStatusTypeDetailsQueryHandler
        : IRequestHandler<GetStatusTypeDetailsQuery, StatusTypeDetailsVm>
    {
        private readonly IReepDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<GetStatusTypeDetailsQueryHandler> _logger;

        public GetStatusTypeDetailsQueryHandler(
            IReepDbContext context, IMapper mapper, ILogger<GetStatusTypeDetailsQueryHandler> logger) =>
            (_context, _mapper, _logger) = (context, mapper, logger);

        public async Task<StatusTypeDetailsVm> Handle(GetStatusTypeDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.SupplierTypes.FirstOrDefaultAsync(supplierType =>
                supplierType.Id == request.Id, cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(entity), request.Id);

            return _mapper.Map<StatusTypeDetailsVm>(entity);
        }
    }
}
