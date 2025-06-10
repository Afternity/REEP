using MediatR;

namespace REEP.Application.Features.ContractFeatures.ContractManyToManyFeatures.ContractAndSuppliers.Queries.GetContractAndPaymentList
{
    public class GetContractAndSupplierListQuery
        : IRequest<ContractAndSupplierListVm>
    {
        public bool IsDeleted { get; set; } = false;
    }
}
