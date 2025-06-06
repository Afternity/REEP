using MediatR;
using Microsoft.Extensions.Logging;
using REEP.Application.Interfaces.InterfaceDbContexts;
using REEP.Application.Common.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace REEP.Application.Features.ContractFeatures.Payments.Commands.HardDeletePayment
{
    public class HardDeletePaymentCommandHandler
        : IRequestHandler<HardDeletePaymentCommand, Unit>
    {
        private readonly IReepDbContext _context;
        private readonly ILogger<HardDeletePaymentCommandHandler> _logger;

        public HardDeletePaymentCommandHandler(
            IReepDbContext context,
            ILogger<HardDeletePaymentCommandHandler> logger) =>
            (_context, _logger) = (context, logger);

        public async Task<Unit> Handle(HardDeletePaymentCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Payments
                .FirstOrDefaultAsync(payment =>  payment.Id == request.Id, cancellationToken);

            if (entity == null) 
                throw new NotFoundException(nameof(entity), request.Id);

            _context.Payments.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
