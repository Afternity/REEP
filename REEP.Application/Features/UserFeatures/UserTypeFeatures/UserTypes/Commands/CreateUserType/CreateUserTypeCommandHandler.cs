using MediatR;
using Microsoft.Extensions.Logging;
using REEP.Application.Interfaces.InterfaceDbContexts;
using REEP.Domain.Models.UserModels.UserTypeModels;

namespace REEP.Application.Features.UserFeatures.UserTypeFeatures.UserTypes.Commands.CreateUserType
{
    internal class CreateUserTypeCommandHandler
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
            var entity = new UserType
            {
                Type = request.Type,
                CreatedAt = DateTime.UtcNow,
                IsDeleted = request.IsDeleted
            };

            await _context.UserTypes.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
