using MediatR;

namespace REEP.Application.Features.ContractFeatures.ContractManyToManyFeatures.ContractAndSuppliers.Commands.HardDeleteContractAndSupplier
{
    public class HardDeleteContractAndSupplierCommand
        : IRequest<Unit>
    {
        public Guid ContractId { get; set; }
        public Guid SupplierId { get; set; }
    }
}
