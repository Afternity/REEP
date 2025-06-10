using MediatR;

namespace REEP.Application.Features.ContractFeatures.ContractManyToManyFeatures.ContractAndSuppliers.Commands.SoftDeleteContractAndSupplier
{
    public class SoftDeleteContractAndSupplierCommand
        : IRequest<Unit>
    {
        public Guid ContractId { get; set; }
        public Guid SupplierId { get; set; }
        public bool IsDeleted { get; set; } = true;
    }
}
