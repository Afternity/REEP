using MediatR;
using REEP.Application.Interfaces.InterfaceDbContexts;
using REEP.Domain.Models.ContractModels.ContractTypeModels;

namespace REEP.Application.Features.PaymentTypes.Commands.CreatePaymentType
{
    public class CreatePaymentTypeHandler 
        : IRequestHandler<CreatePaymentTypeCommand, Guid>
    {
        private readonly IReepDbContext _context;

        public CreatePaymentTypeHandler(IReepDbContext context) =>
            _context = context;
        
        public async Task<Guid> Handle(CreatePaymentTypeCommand request,
            CancellationToken cancellationToken)
        {
            var entity = new PaymentType
            {
                Id = Guid.NewGuid(),
                Type = request.Type,
                IsDeleted = request.IsDeleted,
            };
            await _context.PaymentTypes.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
