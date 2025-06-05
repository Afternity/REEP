using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using REEP.Application.Interfaces.InterfaceDbContexts;
using REEP.Domain.Models.ContractModels;
using REEP.Application.Common.Exceptions;

namespace REEP.Application.Features.ContractFeatures.Contracts.Commands.CreateContract
{
    public class CreateContractCommandHandler
        : IRequestHandler<CreateContractCommand, Guid>
    {
        private readonly IReepDbContext _context;
        private readonly IMediator _mediator;
        private readonly ILogger<CreateContractCommandHandler> _logger;

        public CreateContractCommandHandler(
            IReepDbContext context,
            IMediator mediator,
            ILogger<CreateContractCommandHandler> logger) =>
            (_context, _mediator, _logger) = (context, mediator, logger);

        public async Task<Guid> Handle(CreateContractCommand request,
            CancellationToken cancellationToken)
        {
            var contractType = await _context.ContractTypes.FirstOrDefaultAsync(x =>
                x.Type == request.Type, cancellationToken);

            if (contractType == null || contractType.Type != request.Type) 
                 throw new NotFoundException(nameof(contractType), request.Type);

            var entity = new Contract()
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Description = request.Description,
                StartedAt = request.StartedAt,
                EndedAt = request.EndedAt,
                IsDeleted = request.IsDeleted,
                ContractTypeId = contractType.Id
            };

            await _context.Contracts.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
