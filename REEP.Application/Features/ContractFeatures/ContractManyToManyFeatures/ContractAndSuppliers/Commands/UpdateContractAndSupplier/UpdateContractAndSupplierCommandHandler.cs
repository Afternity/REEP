using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using REEP.Application.Common.Exceptions;
using REEP.Application.Interfaces.InterfaceDbContexts;


namespace REEP.Application.Features.ContractFeatures.ContractManyToManyFeatures.ContractAndSuppliers.Commands.UpdateContractAndSupplier
{
    public class UpdateContractAndSupplierCommandHandler
        : IRequestHandler<UpdateContractAndSupplierCommand, Unit>
    {
        private readonly IReepDbContext _context;
        private readonly ILogger<UpdateContractAndSupplierCommandHandler> _logger;

        public UpdateContractAndSupplierCommandHandler(
            IReepDbContext context,
            ILogger<UpdateContractAndSupplierCommandHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateContractAndSupplierCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.ContractsAndSuppliers
              .FirstOrDefaultAsync(contractsAndPayments =>
                  contractsAndPayments.ContractId == request.ContractId
                  && contractsAndPayments.SupplierId == request.SupplierId, cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(entity), request);

            entity.IsActive = request.IsActive;
            entity.UpdatedAt = DateTime.UtcNow;

            _context.ContractsAndSuppliers.Update(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
