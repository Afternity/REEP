using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using REEP.Application.Common.Exceptions;
using REEP.Application.Interfaces.InterfaceDbContexts;

namespace REEP.Application.Features.StatusFeatures.StatusTypeFeatures.StatusTypes.Commands.HardDeleteStatusType
{
    public class HardDeleteUserTypeCommandHandler
        : IRequestHandler<HardDeleteUserTypeCommand, Unit>
    {
        private readonly IReepDbContext _context;
        private readonly ILogger<HardDeleteUserTypeCommandHandler> _logger;

        public HardDeleteUserTypeCommandHandler(
            IReepDbContext context,
            ILogger<HardDeleteUserTypeCommandHandler> logger) =>
            (_context, _logger) = (context, logger);

        public async Task<Unit> Handle(HardDeleteUserTypeCommand request, CancellationToken cancellationToken)
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
