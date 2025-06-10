using MediatR;

namespace REEP.Application.Features.ContractFeatures.ContractManyToManyFeatures.ContractAndSuppliers.Queries.GetContractAndPaymentDetails
{
    public class GetContractAndSupplierDetailsQuery
        : IRequest<ContractAndSupplierDetailsVm>
    {
        public Guid ContractId { get; set; }
        public Guid SupplierId { get; set; }
    }
}
