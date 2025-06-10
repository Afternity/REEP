using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using REEP.Application.Interfaces.InterfaceDbContexts;
using REEP.Application.Common.Exceptions;
using AutoMapper;

namespace REEP.Application.Features.ContractFeatures.ContractManyToManyFeatures.ContractAndPayments.Queries.GetContractsAndPaymentsDetails
{
    public class GetContractsAndPaymentsDetailsQueryHandler
        : IRequestHandler<GetContractsAndPaymentsDetailsQuery, ContractsAndPaymentsDetailsVm>
    {
        private readonly IReepDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<GetContractsAndPaymentsDetailsQueryHandler> _logger;

        public GetContractsAndPaymentsDetailsQueryHandler(
            IReepDbContext context,
            IMapper mapper,
            ILogger<GetContractsAndPaymentsDetailsQueryHandler> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ContractsAndPaymentsDetailsVm> Handle(GetContractsAndPaymentsDetailsQuery request,
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

            return _mapper.Map<ContractsAndPaymentsDetailsVm>(entity);
        }
    }
}
