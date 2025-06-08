using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using REEP.Application.Common.Exceptions;
using REEP.Application.Interfaces.InterfaceDbContexts;

namespace REEP.Application.Features.ContractFeatures.Suppliers.Queries.GetSupplierDetails
{
    public class GetSupplierDetailsQueryHandler
        : IRequestHandler<GetSupplierDetailsQuery, SupplierDetailsVm>
    {
        private readonly IReepDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<GetSupplierDetailsQueryHandler> _logger;

        public GetSupplierDetailsQueryHandler(
            IReepDbContext context,
            IMapper mapper,
            ILogger<GetSupplierDetailsQueryHandler> logger) =>
            (_context, _mapper, _logger) = (context, mapper, logger);

        public async Task<SupplierDetailsVm> Handle(GetSupplierDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Suppliers
                .Include(parent => parent.SupplierType)
                .FirstOrDefaultAsync(supplier => supplier.Id == request.Id, cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(entity), request.Id);

            return _mapper.Map<SupplierDetailsVm>(entity);
        }
    }
}
