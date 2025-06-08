using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using REEP.Application.Interfaces.InterfaceDbContexts;

namespace REEP.Application.Features.ContractFeatures.Suppliers.Queries.GetSupplierList
{
    public class GetSupplierListQueryHandler
        : IRequestHandler<GetSupplierListQuery, SupplierListVm>
    {
        private readonly IReepDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<GetSupplierListQueryHandler> _logger;

        public GetSupplierListQueryHandler(
            IReepDbContext context,
            IMapper mapper,
            ILogger<GetSupplierListQueryHandler> logger) =>
            (_context, _mapper, _logger) = (context, mapper, logger);

        public async Task<SupplierListVm> Handle(GetSupplierListQuery request, CancellationToken cancellationToken)
        {
            var entities = await _context.Suppliers
                .Include(parent => parent.SupplierType)
                .Where(suppliers => suppliers.IsDeleted == request.IsDeleted)
                .ProjectTo<SupplierLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new SupplierListVm() { Suppliers = entities };
        }
    }
}
