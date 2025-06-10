using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using REEP.Application.Common.Exceptions;
using REEP.Application.Interfaces.InterfaceDbContexts;

namespace REEP.Application.Features.StatusFeatures.StatusTypesFeatures.StatusTypes.Queries.GetStatusTypeByTypeDetails
{
    internal class GetUserTypeByTypeDetailsQueryHandler
        : IRequestHandler<GetUserTypeByTypeDetailsQuery, UserTypeByTypeDetailsVm>
    {
        private readonly IReepDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<GetUserTypeByTypeDetailsQueryHandler> _logger;

        public GetUserTypeByTypeDetailsQueryHandler(
            IReepDbContext context, IMapper mapper, ILogger<GetUserTypeByTypeDetailsQueryHandler> logger) =>
            (_context, _mapper, _logger) = (context, mapper, logger);

        public async Task<UserTypeByTypeDetailsVm> Handle(GetUserTypeByTypeDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.SupplierTypes.FirstOrDefaultAsync(supplierType =>
                supplierType.Type == request.Type, cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(entity), request.Type);

            return _mapper.Map<UserTypeByTypeDetailsVm>(entity);
        }
    }
}
