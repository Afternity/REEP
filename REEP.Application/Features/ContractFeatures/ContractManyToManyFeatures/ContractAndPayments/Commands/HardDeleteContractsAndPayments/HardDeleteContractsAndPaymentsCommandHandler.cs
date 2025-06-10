using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using REEP.Application.Common.Exceptions;
using REEP.Application.Interfaces.InterfaceDbContexts;

namespace REEP.Application.Features.ContractFeatures.ContractManyToManyFeatures.ContractAndPayments.Commands.HardDeleteContractsAndPayments
{
    public class HardDeleteContractsAndPaymentsCommandHandler
        : IRequestHandler<HardDeleteContractsAndPaymentsCommand, Unit>
    {
        private readonly IReepDbContext _context;
        private readonly ILogger<HardDeleteContractsAndPaymentsCommandHandler> _logger;

        public HardDeleteContractsAndPaymentsCommandHandler(
            IReepDbContext context,
            ILogger<HardDeleteContractsAndPaymentsCommandHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Unit> Handle(HardDeleteContractsAndPaymentsCommand request, CancellationToken cancellationToken)
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
