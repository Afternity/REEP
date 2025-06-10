using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using REEP.Application.Common.Exceptions;
using REEP.Application.Interfaces.InterfaceDbContexts;

namespace REEP.Application.Features.ContractFeatures.ContractManyToManyFeatures.ContractAndPayments.Commands.HardDeleteContractAndPayment
{
    public class HardDeleteContractAndPaymentCommandHandler
        : IRequestHandler<HardDeleteContractAndPaymentCommand, Unit>
    {
        private readonly IReepDbContext _context;
        private readonly ILogger<HardDeleteContractAndPaymentCommandHandler> _logger;

        public HardDeleteContractAndPaymentCommandHandler(
            IReepDbContext context,
            ILogger<HardDeleteContractAndPaymentCommandHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Unit> Handle(HardDeleteContractAndPaymentCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.ContractsAndPayments
                .FirstOrDefaultAsync(contractsAndPayments =>
                    contractsAndPayments.ContractId == request.ContractId
                    && contractsAndPayments.PaymentId == request.PaymentId, cancellationToken);

            if (entity == null) 
                throw new NotFoundException(nameof(entity), request);

            _context.ContractsAndPayments.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
