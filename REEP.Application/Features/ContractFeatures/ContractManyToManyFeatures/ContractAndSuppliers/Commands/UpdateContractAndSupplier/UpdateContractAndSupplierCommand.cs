using MediatR;

namespace REEP.Application.Features.ContractFeatures.ContractManyToManyFeatures.ContractAndSuppliers.Commands.UpdateContractAndSupplier
{
    public class UpdateContractAndSupplierCommand
        : IRequest<Unit>
    {
        public Guid ContractId { get; set; }
        public Guid SupplierId { get; set; }
        public bool IsActive { get; set; } = false;
    }
}
