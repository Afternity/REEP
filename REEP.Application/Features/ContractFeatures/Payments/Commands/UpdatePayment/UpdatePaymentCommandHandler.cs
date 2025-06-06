using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using REEP.Application.Interfaces.InterfaceDbContexts;
using REEP.Application.Common.Exceptions;

namespace REEP.Application.Features.ContractFeatures.Payments.Commands.UpdatePayment
{
    public class UpdatePaymentCommandHandler
        : IRequestHandler<UpdatePaymentCommand, Unit>
    {
        private readonly IReepDbContext _context;
        private readonly ILogger<UpdatePaymentCommandHandler> _logger;

        public UpdatePaymentCommandHandler(
            IReepDbContext context,
            ILogger<UpdatePaymentCommandHandler> logger) =>
            (_context, _logger) = (context, logger);

        public async Task<Unit> Handle(UpdatePaymentCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Payments
                .FirstOrDefaultAsync(payment => payment.Id == request.Id, cancellationToken);

            if (entity == null) 
                throw new NotFoundException(nameof(entity), request.Id);
            _logger.LogInformation($"entity.id = {entity.Id}");
            var parent = await _context.PaymentTypes
                .FirstOrDefaultAsync(paymentType => paymentType.Type == request.Type, cancellationToken);

            if (parent == null)
                throw new NotFoundException(nameof(entity), request.Id);

            entity.Price = request.Price;
            entity.FirstPay = request.FirstPay;
            entity.PeriodPay = request.PeriodPay;
            entity.LastPay = request.LastPay;
            entity.UpdatedAt = DateTime.UtcNow;
            entity.PaymentTypeId = parent.Id;

            _context.Payments.Update(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
