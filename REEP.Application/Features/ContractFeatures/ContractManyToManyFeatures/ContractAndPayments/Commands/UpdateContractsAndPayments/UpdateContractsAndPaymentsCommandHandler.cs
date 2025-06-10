using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using REEP.Application.Common.Exceptions;
using REEP.Application.Interfaces.InterfaceDbContexts;

namespace REEP.Application.Features.ContractFeatures.ContractManyToManyFeatures.ContractAndPayments.Commands.UpdateContractsAndPayments
{
    public class UpdateContractsAndPaymentsCommandHandler
        : IRequestHandler<UpdateContractsAndPaymentsCommand, Unit>
    {
        private readonly IReepDbContext _context;
        private readonly ILogger<UpdateContractsAndPaymentsCommandHandler> _logger;

        public UpdateContractsAndPaymentsCommandHandler(
            IReepDbContext context,
            ILogger<UpdateContractsAndPaymentsCommandHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateContractsAndPaymentsCommand request,
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
