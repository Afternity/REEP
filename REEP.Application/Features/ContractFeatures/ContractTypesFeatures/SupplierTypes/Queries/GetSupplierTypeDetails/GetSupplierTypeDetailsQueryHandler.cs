using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using REEP.Application.Common.Exceptions;
using REEP.Application.Features.ContractFeatures.ContractTypesFeatures.PaymentTypes.Queries.GetPaymentTypeList;
using REEP.Application.Interfaces.InterfaceDbContexts;

namespace REEP.Application.Features.ContractFeatures.ContractTypesFeatures.SupplierTypes.Queries.GetSupplierTypeDetails
{
    public class GetSupplierTypeDetailsQueryHandler
        : IRequestHandler<GetSupplierTypeDetailsQuery, SupplierTypeDetailsVm>
    {
        private readonly IReepDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<GetPaymentTypeListQueryHandler> _logger;

        public GetSupplierTypeDetailsQueryHandler(
            IReepDbContext context, IMapper mapper, ILogger<GetPaymentTypeListQueryHandler> logger) =>
            (_context, _mapper, _logger) = (context, mapper, logger);

        public async Task<SupplierTypeDetailsVm> Handle(GetSupplierTypeDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.SupplierTypes.FirstOrDefaultAsync(supplierType =>
                supplierType.Id == request.Id, cancellationToken);

            if (entity == null || entity.Id != request.Id)
                throw new NotFoundException(nameof(entity), request.Id);

            return _mapper.Map<SupplierTypeDetailsVm>(entity);
        }
    }
}
