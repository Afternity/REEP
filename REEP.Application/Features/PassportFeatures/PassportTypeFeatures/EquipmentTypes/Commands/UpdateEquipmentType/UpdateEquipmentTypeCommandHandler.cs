using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using REEP.Application.Common.Exceptions;
using REEP.Application.Interfaces.InterfaceDbContexts;

namespace REEP.Application.Features.EquipmentFeatures.EquipmentTypeFeatures.EquipmentTypes.Commands.UpdateEquipmentType
{
    public class UpdateStatusTypeCommandHandler
        : IRequestHandler<UpdateStatusTypeCommand, Unit>
    {
        private readonly IReepDbContext _context;
        private readonly ILogger<UpdateStatusTypeCommandHandler> _logger;

        public UpdateStatusTypeCommandHandler(
            IReepDbContext context,
            ILogger<UpdateStatusTypeCommandHandler> logger) =>
            (_context, _logger) = (context, logger);

        public async Task<Unit> Handle(UpdateStatusTypeCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.SupplierTypes
                .FirstOrDefaultAsync(supplierType => supplierType.Id == request.Id, cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(entity), request.Id);

            entity.Type = request.Type;
            entity.UpdatedAt = DateTime.UtcNow;

            _context.SupplierTypes.Update(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
