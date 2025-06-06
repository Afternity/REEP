using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using REEP.Application.Interfaces.InterfaceDbContexts;
using REEP.Application.Common.Exceptions;
using REEP.Domain.Models.ContractModels;

namespace REEP.Application.Features.ContractFeatures.Payments.Commands.CreatePayment
{
    public class CreatePaymentCommandHandler
        : IRequestHandler<CreatePaymentCommand, Guid>
    {
        private readonly IReepDbContext _context;
        private readonly ILogger<CreatePaymentCommandHandler> _logger;

        public CreatePaymentCommandHandler(
            IReepDbContext context,
            ILogger<CreatePaymentCommandHandler> logger) =>
            (_context, _logger) = (context, logger);

        public async Task<Guid> Handle(CreatePaymentCommand request,
            CancellationToken cancellationToken)
        {
            var parent = await _context.PaymentTypes
                .FirstOrDefaultAsync(paymentType => paymentType.Type ==  request.Type, cancellationToken);

            if(parent == null) 
                throw new NotFoundException(nameof(parent), request.Type);

            _logger.LogInformation($"parent.Type = {parent.Type}");

            var entity = new Payment()
            {
                Id = Guid.NewGuid(),
                Price = request.Price,
                FirstPay = request.FirstPay,
                PeriodPay = request.PeriodPay,
                LastPay = request.LastPay,
                CreatedAt = DateTime.UtcNow,
                IsDeleted = request.IsDeleted,
                PaymentTypeId = parent.Id
            };
            _logger.LogInformation($"entity.PaymentTypeId = {entity.PaymentTypeId}");
            await _context.Payments.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
