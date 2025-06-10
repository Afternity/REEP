using MediatR;

namespace REEP.Application.Features.ContractFeatures.ContractManyToManyFeatures.ContractAndSuppliers.Commands.CreateContractAndSupplier
{
    public class CreateContractAndSupplierCommand
        : IRequest<Unit>
    {
        public Guid ContractId { get; set; }
        public Guid SupplierId { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsDeleted { get; set; } = false;
    }
}
