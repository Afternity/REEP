using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using REEP.Application.Common.Exceptions;
using REEP.Application.Interfaces.InterfaceDbContexts;

namespace REEP.Application.Features.ContractFeatures.Payments.Commands.SoftDeletePayment
{
    public class SoftDeletePaymentCommandHandler
        : IRequestHandler<SoftDeletePaymentCommand, Unit>
    {
        private readonly IReepDbContext _context;
        private readonly ILogger<SoftDeletePaymentCommandHandler> _logger;

        public SoftDeletePaymentCommandHandler(
            IReepDbContext context,
            ILogger<SoftDeletePaymentCommandHandler> logger) =>
            (_context, _logger) = (context, logger);

        public async Task<Unit> Handle(SoftDeletePaymentCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Payments
                .FirstOrDefaultAsync(payment => payment.Id == request.Id, cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(entity), request.Id);

            entity.DeletedAt = DateTime.UtcNow;
            entity.IsDeleted = request.IsDeleted;

            _context.Payments.Update(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
