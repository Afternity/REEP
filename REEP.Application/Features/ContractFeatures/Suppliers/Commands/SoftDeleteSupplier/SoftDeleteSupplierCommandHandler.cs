using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using REEP.Application.Interfaces.InterfaceDbContexts;
using REEP.Application.Common.Exceptions;

namespace REEP.Application.Features.ContractFeatures.Suppliers.Commands.SoftDeleteSupplier
{
    public class SoftDeleteSupplierCommandHandler
        : IRequestHandler<SoftDeleteSupplierCommand, Unit>
    {
        private readonly IReepDbContext _context;
        private readonly ILogger<SoftDeleteSupplierCommandHandler> _logger;

        public SoftDeleteSupplierCommandHandler(
            IReepDbContext context,
            ILogger<SoftDeleteSupplierCommandHandler> logger) =>
            (_context, _logger) = (context, logger);

        public async Task<Unit> Handle(SoftDeleteSupplierCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Suppliers
                .FirstOrDefaultAsync(supplier => supplier.Id == request.Id, cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(entity), request.Id);

            entity.DeletedAt = DateTime.UtcNow;
            entity.IsDeleted = request.IsDeleted;

            _context.Suppliers.Update(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
