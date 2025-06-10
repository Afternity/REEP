using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using REEP.Application.Common.Exceptions;
using REEP.Application.Interfaces.InterfaceDbContexts;

namespace REEP.Application.Features.UserFeatures.UserTypesFeatures.UserTypes.Queries.GetUserTypeDetails
{
    public class GetUserTypeDetailsQueryHandler
        : IRequestHandler<GetUserTypeDetailsQuery, UserTypeDetailsVm>
    {
        private readonly IReepDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<GetUserTypeDetailsQueryHandler> _logger;

        public GetUserTypeDetailsQueryHandler(
            IReepDbContext context, IMapper mapper, ILogger<GetUserTypeDetailsQueryHandler> logger) =>
            (_context, _mapper, _logger) = (context, mapper, logger);

        public async Task<UserTypeDetailsVm> Handle(GetUserTypeDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.SupplierTypes.FirstOrDefaultAsync(supplierType =>
                supplierType.Id == request.Id, cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(entity), request.Id);

            return _mapper.Map<UserTypeDetailsVm>(entity);
        }
    }
}
