using MediatR;

namespace REEP.Application.Features.ContractFeatures.Suppliers.Queries.GetSupplierList
{
    public class GetSupplierListQuery : IRequest<SupplierListVm>
    {
        public bool IsDeleted { get; set; } = false;
    }
}
