using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using REEP.Application.Common.Exceptions;
using REEP.Application.Features.ContractFeatures.ContractTypesFeatures.PaymentTypes.Queries.GetPaymentTypeList;
using REEP.Application.Interfaces.InterfaceDbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REEP.Application.Features.ContractFeatures.ContractTypesFeatures.SupplierTypes.Queries.GetSupplierTypeByTypeDetails
{
    internal class GetSupplierTypeByTypeDetailsQueryHandler
        : IRequestHandler<GetSupplierTypeByTypeDetailsQuery, SupplierTypeByTypeDetailsVm>
    {
        private readonly IReepDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<GetPaymentTypeListQueryHandler> _logger;

        public GetSupplierTypeByTypeDetailsQueryHandler(
            IReepDbContext context, IMapper mapper, ILogger<GetPaymentTypeListQueryHandler> logger) =>
            (_context, _mapper, _logger) = (context, mapper, logger);

        public async Task<SupplierTypeByTypeDetailsVm> Handle(GetSupplierTypeByTypeDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.SupplierTypes.FirstOrDefaultAsync(supplierType =>
                supplierType.Type == request.Type, cancellationToken);

            if (entity == null || entity.Type != request.Type)
                throw new NotFoundException(nameof(entity), request.Type);

            return _mapper.Map<SupplierTypeByTypeDetailsVm>(entity);
        }
    }
}
