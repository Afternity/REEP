using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using REEP.Application.Common.Exceptions;
using REEP.Application.Interfaces.InterfaceDbContexts;

namespace REEP.Application.Features.ContractFeatures.ContractTypesFeatures.SupplierTypes.Commands.UpdateSupplierType
{
    public class UpdateSupplierTypeCommandHandler
        : IRequestHandler<UpdateSupplierTypeCommand, Unit>
    {
        private readonly IReepDbContext _context;
        private readonly ILogger<UpdateSupplierTypeCommandHandler> _logger;

        public UpdateSupplierTypeCommandHandler(
            IReepDbContext context,
            ILogger<UpdateSupplierTypeCommandHandler> logger) =>
            (_context, _logger) = (context, logger);

        public async Task<Unit> Handle(UpdateSupplierTypeCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.SupplierTypes.FirstOrDefaultAsync(supplierType =>
                supplierType.Id == request.Id, cancellationToken);

            if (entity == null || entity.Id != request.Id)
                throw new NotFoundException(nameof(entity), request.Id);

            entity.Type = request.Type;
            entity.UpdatedAt = DateTime.UtcNow;

            _context.SupplierTypes.Update(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
