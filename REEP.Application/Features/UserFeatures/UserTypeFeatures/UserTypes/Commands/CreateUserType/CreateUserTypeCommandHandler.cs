using MediatR;
using Microsoft.Extensions.Logging;
using REEP.Application.Interfaces.InterfaceDbContexts;
using REEP.Domain.Models.ContractModels.ContractTypeModels;

namespace REEP.Application.Features.UserFeatures.UserTypeFeatures.UserTypes.Commands.CreateUserType
{
    public class CreateUserTypeCommandHandler
        : IRequestHandler<CreateUserTypeCommand, Guid>
    {
        private readonly IReepDbContext _context;
        private readonly ILogger<CreateUserTypeCommandHandler> _logger;

        public CreateUserTypeCommandHandler(
            IReepDbContext context,
            ILogger<CreateUserTypeCommandHandler> logger) =>
            (_context, _logger) = (context, logger);

        public async Task<Guid> Handle(CreateUserTypeCommand request,
            CancellationToken cancellationToken)
        {
            var entity = new SupplierType
            {
                Type = request.Type,
                CreatedAt = DateTime.UtcNow,
                IsDeleted = request.IsDeleted
            };

            await _context.SupplierTypes.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
