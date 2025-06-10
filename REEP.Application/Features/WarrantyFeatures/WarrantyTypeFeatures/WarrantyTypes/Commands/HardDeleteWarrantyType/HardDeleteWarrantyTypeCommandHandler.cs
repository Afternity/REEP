using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using REEP.Application.Common.Exceptions;
using REEP.Application.Interfaces.InterfaceDbContexts;

namespace REEP.Application.Features.WarrantyFeatures.WarrantyTypeFeatures.WarrantyTypes.Commands.HardDeleteWarrantyType
{
    public class HardDeleteEquipmentTypeCommandHandler
        : IRequestHandler<HardDeleteEquipmentTypeCommand, Unit>
    {
        private readonly IReepDbContext _context;
        private readonly ILogger<HardDeleteEquipmentTypeCommandHandler> _logger;

        public HardDeleteEquipmentTypeCommandHandler(
            IReepDbContext context,
            ILogger<HardDeleteEquipmentTypeCommandHandler> logger) =>
            (_context, _logger) = (context, logger);

        public async Task<Unit> Handle(HardDeleteEquipmentTypeCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.SupplierTypes.FirstOrDefaultAsync(supplierType =>
                supplierType.Id == request.Id, cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(entity), request.Id);

            _context.SupplierTypes.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
