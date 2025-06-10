using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using REEP.Application.Common.Exceptions;
using REEP.Application.Interfaces.InterfaceDbContexts;

namespace REEP.Application.Features.WarrantyFeatures.WarrantyTypeFeatures.WarrantyTypes.Commands.SoftDeleteWarrantyType
{
    public class SoftDeleteEquipmentTypeCommandHandler
        : IRequestHandler<SoftDeleteEquipmentTypeCommand, Unit>
    {
        private readonly IReepDbContext _context;
        private readonly ILogger<SoftDeleteEquipmentTypeCommandHandler> _logger;

        public SoftDeleteEquipmentTypeCommandHandler(
            IReepDbContext context,
            ILogger<SoftDeleteEquipmentTypeCommandHandler> logger) =>
            (_context, _logger) = (context, logger);

        public async Task<Unit> Handle(SoftDeleteEquipmentTypeCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.SupplierTypes.FirstOrDefaultAsync(supplierType =>
                supplierType.Id == request.Id, cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(entity), request.Id);

            entity.DeletedAt = DateTime.UtcNow;
            entity.IsDeleted = request.IsDeleted;

            _context.SupplierTypes.Update(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
