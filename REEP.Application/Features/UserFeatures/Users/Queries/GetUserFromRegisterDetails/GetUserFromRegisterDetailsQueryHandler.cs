using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using REEP.Application.Common.Exceptions;
using REEP.Application.Interfaces.InterfaceDbContexts;

namespace REEP.Application.Features.UserFeatures.Users.Queries.GetUserFromRegisterDetails
{
    public class GetUserFromRegisterDetailsQueryHandler
        : IRequestHandler<GetUserFromRegisterDetailsQuery, UserFromRegisterDetailsVm>
    {
        private readonly IReepDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<GetUserFromRegisterDetailsQueryHandler> _logger;

        public GetUserFromRegisterDetailsQueryHandler(
            IReepDbContext context,
            IMapper mapper,
            ILogger<GetUserFromRegisterDetailsQueryHandler> logger) =>
            (_context, _mapper, _logger) = (context, mapper, logger);

        public async Task<UserFromRegisterDetailsVm> Handle(
            GetUserFromRegisterDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _context.Users
                .Include(parent =>
                    parent.UserType)
                .FirstOrDefaultAsync(user =>
                    user.Password == request.Password
                    && user.Email == request.Email,
                    cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(entity), request.Password);

            return _mapper.Map<UserFromRegisterDetailsVm>(entity);
        }
    }
}
