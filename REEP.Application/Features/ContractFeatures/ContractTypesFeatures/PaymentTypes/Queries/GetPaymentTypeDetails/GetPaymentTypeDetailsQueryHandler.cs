using MediatR;
using Microsoft.EntityFrameworkCore;
using REEP.Application.Interfaces.InterfaceDbContexts;
using REEP.Application.Common.Exceptions;
using System.Net.NetworkInformation;
using AutoMapper;

namespace REEP.Application.Features.ContractFeatures.ContractTypesFeatures.PaymentTypes.Queries.GetPaymentTypeDetails
{
    public class GetPaymentTypeDetailsQueryHandler
        : IRequestHandler<GetPaymentTypeDetailsQuery, PaymentTypeDetailsVm>
    {
        private readonly IReepDbContext _context;
        private readonly IMapper _mapper;

        public GetPaymentTypeDetailsQueryHandler(IReepDbContext context, IMapper mapper) =>
            (_context, _mapper) = (context, mapper);

        public async Task<PaymentTypeDetailsVm> Handle(GetPaymentTypeDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _context.PaymentTypes.FirstOrDefaultAsync(paymentType => 
                paymentType.Id == request.Id, cancellationToken);

            if (entity == null || entity.Id != request.Id) 
                throw new NotFoundException(nameof(entity), request.Id);

            return _mapper.Map<PaymentTypeDetailsVm>(entity);
        }
    }
}
