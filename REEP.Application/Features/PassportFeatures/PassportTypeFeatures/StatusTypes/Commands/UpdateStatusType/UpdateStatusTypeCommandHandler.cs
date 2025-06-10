using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using REEP.Application.Common.Exceptions;
using REEP.Application.Interfaces.InterfaceDbContexts;

namespace REEP.Application.Features.StatusFeatures.StatusTypeFeatures.StatusTypes.Commands.UpdateStatusType
{
    public class UpdateUserTypeCommandHandler
        : IRequestHandler<UpdateUserTypeCommand, Unit>
    {
        private readonly IReepDbContext _context;
        private readonly ILogger<UpdateUserTypeCommandHandler> _logger;

        public UpdateUserTypeCommandHandler(
            IReepDbContext context,
            ILogger<UpdateUserTypeCommandHandler> logger) =>
            (_context, _logger) = (context, logger);

        public async Task<Unit> Handle(UpdateUserTypeCommand request, CancellationToken cancellationToken)
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
