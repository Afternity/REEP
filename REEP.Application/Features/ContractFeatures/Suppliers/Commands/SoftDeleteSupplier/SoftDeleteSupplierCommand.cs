using MediatR;

namespace REEP.Application.Features.ContractFeatures.Suppliers.Commands.SoftDeleteSupplier
{
    public class SoftDeleteSupplierCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; } = true;
    }
}
