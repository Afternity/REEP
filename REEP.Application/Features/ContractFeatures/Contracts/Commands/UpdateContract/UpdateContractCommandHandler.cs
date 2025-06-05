using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using REEP.Application.Common.Exceptions;
using REEP.Application.Features.ContractFeatures.ContractTypesFeatures.SupplierTypes.Commands.SoftDeleteSupplierType;
using REEP.Application.Interfaces.InterfaceDbContexts;
using REEP.Domain.Models.ContractModels.ContractTypeModels;

namespace REEP.Application.Features.ContractFeatures.Contracts.Commands.UpdateContract
{
    public class UpdateContractCommandHandler
        : IRequestHandler<UpdateContractCommand, Unit>
    {
        private readonly IReepDbContext _context;
        private readonly ILogger<UpdateContractCommandHandler> _logger;

        public UpdateContractCommandHandler(
            IReepDbContext context,
            ILogger<UpdateContractCommandHandler> logger) =>
            (_context, _logger) = (context, logger);

        public async Task<Unit> Handle(UpdateContractCommand request, CancellationToken cancellationToken)
        {
            var contract = await _context.Contracts
                .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

            if (contract == null)
                throw new NotFoundException(nameof(contract), request.Id);

            var contractType = await _context.ContractTypes
                .FirstOrDefaultAsync(ct => ct.Type == request.Type, cancellationToken);

            if (contractType == null)
                throw new NotFoundException(nameof(contractType), request.Type);

            contract.Name = request.Name;
            contract.Description = request.Description;
            contract.StartedAt = request.StartedAt;
            contract.EndedAt = request.EndedAt;
            contract.UpdatedAt = DateTime.UtcNow;
            contract.ContractTypeId = contractType.Id;

            _context.Contracts.Update(contract);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
