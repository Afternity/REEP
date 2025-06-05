using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using REEP.Application.Common.Exceptions;
using REEP.Application.Features.ContractFeatures.Contracts.Commands.CreateContract;
using REEP.Application.Interfaces.InterfaceDbContexts;

namespace REEP.Application.Features.ContractFeatures.Contracts.Commands.SoftDeleteContract
{
    public class SoftDeleteContractCommandHandler
        : IRequestHandler<SoftDeleteContractCommand, Unit>
    {
        private readonly IReepDbContext _context;
        private readonly ILogger<SoftDeleteContractCommandHandler> _logger;

        public SoftDeleteContractCommandHandler(
            IReepDbContext context,
            ILogger<SoftDeleteContractCommandHandler> logger) =>
            (_context, _logger) = (context, logger);

        public async Task<Unit> Handle(SoftDeleteContractCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Contracts.FirstOrDefaultAsync(contract =>
               contract.Id == request.Id, cancellationToken);

            if (entity == null || entity.Id != request.Id)
                throw new NotFoundException(nameof(entity), request.Id);

            entity.DeletedAt = DateTime.UtcNow;
            entity.IsDeleted = request.IsDeleted;

            _context.Contracts.Update(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
