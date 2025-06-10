using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using REEP.Application.Common.Exceptions;
using REEP.Application.Interfaces.InterfaceDbContexts;

namespace REEP.Application.Features.EquipmentFeatures.EquipmentTypeFeatures.EquipmentTypes.Commands.HardDeleteEquipmentType
{
    public class HardDeleteStatusTypeCommandHandler
        : IRequestHandler<HardDeleteStatusTypeCommand, Unit>
    {
        private readonly IReepDbContext _context;
        private readonly ILogger<HardDeleteStatusTypeCommandHandler> _logger;

        public HardDeleteStatusTypeCommandHandler(
            IReepDbContext context,
            ILogger<HardDeleteStatusTypeCommandHandler> logger) =>
            (_context, _logger) = (context, logger);

        public async Task<Unit> Handle(HardDeleteStatusTypeCommand request, CancellationToken cancellationToken)
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
