using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using REEP.Application.Common.Exceptions;
using REEP.Application.Interfaces.InterfaceDbContexts;

namespace REEP.Application.Features.ContractFeatures.ContractManyToManyFeatures.ContractAndSuppliers.Commands.SoftDeleteContractAndSupplier
{
    public class SoftDeleteContractAndSupplierCommandHandler
        : IRequestHandler<SoftDeleteContractAndSupplierCommand, Unit>
    {
        private readonly IReepDbContext _context;
        private readonly ILogger<SoftDeleteContractAndSupplierCommandHandler> _logger;

        public SoftDeleteContractAndSupplierCommandHandler(
            IReepDbContext context,
            ILogger<SoftDeleteContractAndSupplierCommandHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Unit> Handle(SoftDeleteContractAndSupplierCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _context.ContractsAndSuppliers
              .FirstOrDefaultAsync(contractsAndPayments =>
                  contractsAndPayments.ContractId == request.ContractId
                  && contractsAndPayments.SupplierId == request.SupplierId, cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(entity), request);

            entity.DeletedAt = DateTime.UtcNow;
            entity.IsDeleted = request.IsDeleted;

            _context.ContractsAndSuppliers.Update(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
