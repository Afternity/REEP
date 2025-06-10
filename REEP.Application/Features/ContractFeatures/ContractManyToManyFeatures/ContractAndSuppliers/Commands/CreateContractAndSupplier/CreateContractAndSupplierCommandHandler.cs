using MediatR;
using Microsoft.Extensions.Logging;
using REEP.Application.Interfaces.InterfaceDbContexts;
using REEP.Domain.Models.ContractModels.ContractManyToManyModels;

namespace REEP.Application.Features.ContractFeatures.ContractManyToManyFeatures.ContractAndSuppliers.Commands.CreateContractAndSupplier
{
    public class CreateContractAndSupplierCommandHandler
        : IRequestHandler<CreateContractAndSupplierCommand, Unit>
    {
        private readonly IReepDbContext _context;
        private readonly ILogger<CreateContractAndSupplierCommandHandler> _logger;

        public CreateContractAndSupplierCommandHandler(
            IReepDbContext context,
            ILogger<CreateContractAndSupplierCommandHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Unit> Handle(CreateContractAndSupplierCommand request,
            CancellationToken cancellationToken)
        {
            var entity = new ContractAndSupplier()
            {
                ContractId = request.ContractId,
                SupplierId = request.SupplierId,
                IsActive = request.IsActive,
                CreatedAt = DateTime.UtcNow,
                IsDeleted = request.IsDeleted,
            };

            await _context.ContractsAndSuppliers.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
