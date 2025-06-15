using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using REEP.Application.Common.Exceptions;
using REEP.Application.Features.ContractFeatures.Suppliers.Commands.CreateSupplier;
using REEP.Application.Interfaces.InterfaceDbContexts;
using REEP.Domain.Models.ContractModels;
using REEP.Domain.Models.UserModels;


namespace REEP.Application.Features.UserFeatures.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler
        : IRequestHandler<CreateUserCommand, Guid>
    {
        private readonly IReepDbContext _context;
        private readonly ILogger<CreateUserCommandHandler> _logger;

        public CreateUserCommandHandler(
            IReepDbContext context,
            ILogger<CreateUserCommandHandler> logger) =>
            (_context, _logger) = (context, logger);

        public async Task<Guid> Handle(CreateUserCommand request,
            CancellationToken cancellationToken)
        {
            var parent = await _context.UserTypes
                .FirstOrDefaultAsync(userType =>
                    userType.Type == request.Type,
                    cancellationToken);

            if (parent == null)
                throw new NotFoundException(nameof(parent), request.Type);

            var entity = new User()
            {
                Id = Guid.NewGuid(),
                FirstName = request.FirstName,
                SecondName = request.SecondName,
                LastName = request.LastName,
                Email = request.Email,
                OtherContacts = request.OtherContacts,
                Password = request.Password,
                CreatedAt = DateTime.UtcNow,
                IsDeleted = request.IsDeleted,
                UserTypeId = parent.Id,
            };

            await _context.Users.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
