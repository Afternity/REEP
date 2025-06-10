using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using REEP.Application.Common.Exceptions;
using REEP.Application.Interfaces.InterfaceDbContexts;

namespace REEP.Application.Features.ContractFeatures.ContractManyToManyFeatures.ContractAndPayments.Commands.UpdateContractAndPayment
{
    public class UpdateContractAndPaymentCommandHandler
        : IRequestHandler<UpdateContractAndPaymentCommand, Unit>
    {
        private readonly IReepDbContext _context;
        private readonly ILogger<UpdateContractAndPaymentCommandHandler> _logger;

        public UpdateContractAndPaymentCommandHandler(
            IReepDbContext context,
            ILogger<UpdateContractAndPaymentCommandHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateContractAndPaymentCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _context.ContractsAndPayments
              .FirstOrDefaultAsync(contractsAndPayments =>
                  contractsAndPayments.ContractId == request.ContractId
                  && contractsAndPayments.PaymentId == request.PaymentId, cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(entity), request);

            entity.IsActive = request.IsActive;
            entity.UpdatedAt = DateTime.UtcNow;

            _context.ContractsAndPayments.Update(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
