using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using REEP.Application.Common.Exceptions;
using REEP.Application.Interfaces.InterfaceDbContexts;

namespace REEP.Application.Features.ContractFeatures.ContractTypesFeatures.SupplierTypes.Commands.HardDeleteSupplierType
{
    public class HardDeleteSupplierTypeCommandHandler
        : IRequestHandler<HardDeleteSupplierTypeCommand, Unit>
    {
        private readonly IReepDbContext _context;
        private readonly ILogger<HardDeleteSupplierTypeCommandHandler> _logger;

        public HardDeleteSupplierTypeCommandHandler(
            IReepDbContext context,
            ILogger<HardDeleteSupplierTypeCommandHandler> logger) =>
            (_context, _logger) = (context, logger);

        public async Task<Unit> Handle(HardDeleteSupplierTypeCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.SupplierTypes.FirstOrDefaultAsync(supplierType =>
                supplierType.Id == request.Id, cancellationToken);

            if (entity == null || entity.Id != request.Id)
                throw new NotFoundException(nameof(entity), request.Id);

            _context.SupplierTypes.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
