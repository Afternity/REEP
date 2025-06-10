using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using REEP.Application.Interfaces.InterfaceDbContexts;
using REEP.Application.Common.Exceptions;

namespace REEP.Application.Features.ContractFeatures.ContractManyToManyFeatures.ContractAndSuppliers.Commands.HardDeleteContractAndSupplier
{
    public class HardDeleteContractAndSupplierCommandHandler
        : IRequestHandler<HardDeleteContractAndSupplierCommand, Unit>
    {
        private readonly IReepDbContext _context;
        private readonly ILogger<HardDeleteContractAndSupplierCommandHandler> _logger;

        public HardDeleteContractAndSupplierCommandHandler(
            IReepDbContext context,
            ILogger<HardDeleteContractAndSupplierCommandHandler> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<Unit> Handle(HardDeleteContractAndSupplierCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _context.ContractsAndSuppliers
                .FirstOrDefaultAsync(contractAndSupplier =>
                    contractAndSupplier.ContractId == request.ContractId
                    && contractAndSupplier.SupplierId == request.SupplierId,
                    cancellationToken);

            if (entity == null) 
                throw new NotFoundException(nameof(entity), request);

            _context.ContractsAndSuppliers.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
