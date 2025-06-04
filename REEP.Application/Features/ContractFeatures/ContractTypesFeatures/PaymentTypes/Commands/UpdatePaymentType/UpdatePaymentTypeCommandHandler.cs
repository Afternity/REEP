using MediatR;
using Microsoft.EntityFrameworkCore;
using REEP.Application.Common.Exceptions;
using REEP.Application.Interfaces.InterfaceDbContexts;

namespace REEP.Application.Features.ContractFeatures.ContractTypesFeatures.PaymentTypes.Commands.UpdatePaymentType
{
    public class UpdatePaymentTypeCommandHandler 
        : IRequestHandler<UpdatePaymentTypeCommand, Unit>
    {
        private readonly IReepDbContext _context;

        public UpdatePaymentTypeCommandHandler(IReepDbContext context) =>
            _context = context;

        public async Task<Unit> Handle(UpdatePaymentTypeCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _context.PaymentTypes.FirstOrDefaultAsync(paymentType =>
                paymentType.Id == request.Id, cancellationToken);

            if (entity == null || entity.Id != request.Id)
                throw new NotFoundException(nameof(entity), request.Id);

            entity.Type = request.Type;
            entity.UpdatedAt = DateTime.UtcNow;

            _context.PaymentTypes.Update(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
