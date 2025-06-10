using MediatR;
using Microsoft.Extensions.Logging;
using REEP.Application.Interfaces.InterfaceDbContexts;
using REEP.Domain.Models.ContractModels.ContractManyToManyModels;

namespace REEP.Application.Features.ContractFeatures.ContractManyToManyFeatures.ContractAndPayments.Commands.CreateContractAndPayment
{
    public class CreateContractAndPaymentCommandHandler
        : IRequestHandler<CreateContractAndPaymentCommand, Unit>
    {
        private readonly IReepDbContext _context;
        private readonly ILogger<CreateContractAndPaymentCommandHandler> _logger;

        public CreateContractAndPaymentCommandHandler(
            IReepDbContext context,
            ILogger<CreateContractAndPaymentCommandHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Unit> Handle(CreateContractAndPaymentCommand request,
            CancellationToken cancellationToken)
        {
            var entity = new ContractAndPayment()
            {
                ContractId = request.ContractId,
                PaymentId = request.PaymentId,
                IsActive = request.IsActive,
                CreatedAt = DateTime.UtcNow,
                IsDeleted = request.IsDeleted,
            };

            await _context.ContractsAndPayments.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
