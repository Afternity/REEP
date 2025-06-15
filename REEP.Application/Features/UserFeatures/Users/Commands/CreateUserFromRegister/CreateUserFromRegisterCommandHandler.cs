using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using REEP.Application.Interfaces.InterfaceDbContexts;
using REEP.Domain.Models.UserModels;
using REEP.Domain.Models.UserModels.UserTypeModels;

namespace REEP.Application.Features.UserFeatures.Users.Commands.CreateUserFromRegister
{
    public class CreateUserFromRegisterCommandHandler
        : IRequestHandler<CreateUserFromRegisterCommand, Unit>
    {
        private readonly IReepDbContext _context;
        private readonly ILogger<CreateUserFromRegisterCommandHandler> _logger;

        public CreateUserFromRegisterCommandHandler(
            IReepDbContext context,
            ILogger<CreateUserFromRegisterCommandHandler> logger) =>
            (_context, _logger) = (context, logger);

        public async Task<Unit> Handle(CreateUserFromRegisterCommand request,
            CancellationToken cancellationToken)
        {
            var parent = await _context.UserTypes
                .FirstOrDefaultAsync(userType =>
                    userType.Type == "Сотрудник",
                    cancellationToken);

            if (parent == null)
            {
                var defaultUserType = new UserType()
                {
                    Id = Guid.NewGuid(),
                    Type = "Сотрудник",
                    CreatedAt = DateTime.UtcNow,
                    IsDeleted = false
                };
                parent = defaultUserType;
                await _context.UserTypes.AddAsync(defaultUserType, cancellationToken);
            }

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
                IsDeleted = false,
                UserTypeId = parent.Id,
            };

            await _context.Users.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
