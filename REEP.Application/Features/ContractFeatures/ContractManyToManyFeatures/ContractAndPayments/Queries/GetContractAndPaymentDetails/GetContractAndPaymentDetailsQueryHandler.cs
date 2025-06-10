using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using REEP.Application.Interfaces.InterfaceDbContexts;
using REEP.Application.Common.Exceptions;
using AutoMapper;

namespace REEP.Application.Features.ContractFeatures.ContractManyToManyFeatures.ContractAndPayments.Queries.GetContractAndPaymentDetails
{
    public class GetContractAndPaymentDetailsQueryHandler
        : IRequestHandler<GetContractAndPaymentDetailsQuery, ContractAndPaymentDetailsVm>
    {
        private readonly IReepDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<GetContractAndPaymentDetailsQueryHandler> _logger;

        public GetContractAndPaymentDetailsQueryHandler(
            IReepDbContext context,
            IMapper mapper,
            ILogger<GetContractAndPaymentDetailsQueryHandler> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ContractAndPaymentDetailsVm> Handle(GetContractAndPaymentDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _context.ContractsAndPayments
                .Include(parent => parent.Contract)
                    .ThenInclude(child => child.ContractType)
                .Include(parent => parent.Payment)
                    .ThenInclude(child => child.PaymentType)
                .FirstOrDefaultAsync(contarctAndPayment => 
                    contarctAndPayment.ContractId == request.ContractId
                    && contarctAndPayment.PaymentId == request.PaymentId,
                    cancellationToken);

            if (entity == null) 
                throw new NotFoundException(nameof(entity), request);

            return _mapper.Map<ContractAndPaymentDetailsVm>(entity);
        }
    }
}
