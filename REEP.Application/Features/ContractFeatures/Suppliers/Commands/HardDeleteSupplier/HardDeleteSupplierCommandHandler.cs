using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using REEP.Application.Interfaces.InterfaceDbContexts;
using REEP.Application.Common.Exceptions;

namespace REEP.Application.Features.ContractFeatures.Suppliers.Commands.HardDeleteSupplier
{
    public class HardDeleteSupplierCommandHandler
        : IRequestHandler<HardDeleteSupplierCommand, Unit>
    {
        private readonly IReepDbContext _context;
        private readonly ILogger<HardDeleteSupplierCommandHandler> _logger;

        public HardDeleteSupplierCommandHandler(
            IReepDbContext context,
            ILogger<HardDeleteSupplierCommandHandler> logger) =>
            (_context, _logger) = (context, logger);

        public async Task<Unit> Handle(HardDeleteSupplierCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Suppliers
                .FirstOrDefaultAsync(supplier => supplier.Id == request.Id, cancellationToken);

            if (entity == null) 
                throw new NotFoundException(nameof(entity), request.Id);

            _context.Suppliers.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
