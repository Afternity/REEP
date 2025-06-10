using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using REEP.Application.Common.Exceptions;
using REEP.Application.Interfaces.InterfaceDbContexts;

namespace REEP.Application.Features.ContractFeatures.ContractManyToManyFeatures.ContractAndPayments.Commands.SoftDeleteContractAndPayment
{
    public class SoftDeleteContractAndPaymentCommandHandler
        : IRequestHandler<SoftDeleteContractAndPaymentCommand, Unit>
    {
        private readonly IReepDbContext _context;
        private readonly ILogger<SoftDeleteContractAndPaymentCommandHandler> _logger;

        public SoftDeleteContractAndPaymentCommandHandler(
            IReepDbContext context,
            ILogger<SoftDeleteContractAndPaymentCommandHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Unit> Handle(SoftDeleteContractAndPaymentCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.ContractsAndPayments
               .FirstOrDefaultAsync(contractsAndPayments =>
                   contractsAndPayments.ContractId == request.ContractId
                   && contractsAndPayments.PaymentId == request.PaymentId, cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(entity), request);

            entity.DeletedAt = DateTime.UtcNow;
            entity.IsDeleted = request.IsDeleted;

            _context.ContractsAndPayments.Update(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
