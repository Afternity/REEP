using MediatR;
using Microsoft.Extensions.Logging;
using REEP.Application.Interfaces.InterfaceDbContexts;
using REEP.Domain.Models.ContractModels.ContractManyToManyModels;

namespace REEP.Application.Features.ContractFeatures.ContractManyToManyFeatures.ContractAndPayments.Commands.CreateContractsAndPayments
{
    public class CreateContractsAndPaymentsCommandHandler
        : IRequestHandler<CreateContractsAndPaymentsCommand, Unit>
    {
        private readonly IReepDbContext _context;
        private readonly ILogger<CreateContractsAndPaymentsCommandHandler> _logger;

        public CreateContractsAndPaymentsCommandHandler(
            IReepDbContext context,
            ILogger<CreateContractsAndPaymentsCommandHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Unit> Handle(CreateContractsAndPaymentsCommand request,
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
