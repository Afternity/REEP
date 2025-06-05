using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using REEP.Application.Common.Exceptions;
using REEP.Application.Features.ContractFeatures.Contracts.Commands.CreateContract;
using REEP.Application.Interfaces.InterfaceDbContexts;

namespace REEP.Application.Features.ContractFeatures.Contracts.Commands.HardDeleteContract
{
    public class HardDeleteContractCommandHandler
        : IRequestHandler<HardDeleteContractCommand, Unit>
    {
        private readonly IReepDbContext _context;
        private readonly ILogger<HardDeleteContractCommandHandler> _logger;

        public HardDeleteContractCommandHandler(
            IReepDbContext context,
            ILogger<HardDeleteContractCommandHandler> logger) =>
            (_context, _logger) = (context, logger);

        public async Task<Unit> Handle(HardDeleteContractCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Contracts.FirstOrDefaultAsync(contract =>
                contract.Id == request.Id, cancellationToken);

            if (entity == null || entity.Id != request.Id)
                throw new NotFoundException(nameof(entity), request.Id);

            _context.Contracts.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
