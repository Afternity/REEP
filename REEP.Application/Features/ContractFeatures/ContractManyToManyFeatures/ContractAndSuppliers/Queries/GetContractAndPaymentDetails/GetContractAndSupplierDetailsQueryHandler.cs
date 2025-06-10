using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using REEP.Application.Common.Exceptions;
using REEP.Application.Interfaces.InterfaceDbContexts;

namespace REEP.Application.Features.ContractFeatures.ContractManyToManyFeatures.ContractAndSuppliers.Queries.GetContractAndPaymentDetails
{
    public class GetContractAndSupplierDetailsQueryHandler
        : IRequestHandler<GetContractAndSupplierDetailsQuery, ContractAndSupplierDetailsVm>
    {
        private readonly IReepDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<GetContractAndSupplierDetailsQueryHandler> _logger;

        public GetContractAndSupplierDetailsQueryHandler(
            IReepDbContext context,
            IMapper mapper,
            ILogger<GetContractAndSupplierDetailsQueryHandler> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ContractAndSupplierDetailsVm> Handle(GetContractAndSupplierDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.ContractsAndSuppliers
               .Include(parent => parent.Contract)
                   .ThenInclude(child => child.ContractType)
               .Include(parent => parent.Supplier)
                   .ThenInclude(child => child.SupplierType)
               .FirstOrDefaultAsync(contarctAndPayment =>
                   contarctAndPayment.ContractId == request.ContractId
                   && contarctAndPayment.SupplierId == request.SupplierId,
                   cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(entity), request);

            return _mapper.Map<ContractAndSupplierDetailsVm>(entity);
        }
    }
}
