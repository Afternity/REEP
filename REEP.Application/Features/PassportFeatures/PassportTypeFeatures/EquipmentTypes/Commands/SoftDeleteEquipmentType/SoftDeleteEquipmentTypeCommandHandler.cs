using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using REEP.Application.Common.Exceptions;
using REEP.Application.Interfaces.InterfaceDbContexts;

namespace REEP.Application.Features.EquipmentFeatures.EquipmentTypeFeatures.EquipmentTypes.Commands.SoftDeleteEquipmentType
{
    public class SoftDeleteStatusTypeCommandHandler
        : IRequestHandler<SoftDeleteStatusTypeCommand, Unit>
    {
        private readonly IReepDbContext _context;
        private readonly ILogger<SoftDeleteStatusTypeCommandHandler> _logger;

        public SoftDeleteStatusTypeCommandHandler(
            IReepDbContext context,
            ILogger<SoftDeleteStatusTypeCommandHandler> logger) =>
            (_context, _logger) = (context, logger);

        public async Task<Unit> Handle(SoftDeleteStatusTypeCommand request, CancellationToken cancellationToken)
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
