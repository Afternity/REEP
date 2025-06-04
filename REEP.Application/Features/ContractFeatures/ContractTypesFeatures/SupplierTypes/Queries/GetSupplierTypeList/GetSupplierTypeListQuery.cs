using MediatR;

namespace REEP.Application.Features.ContractFeatures.ContractTypesFeatures.SupplierTypes.Queries.GetSupplierTypeList
{
    public class GetSupplierTypeListQuery : IRequest<SupplierTypeListVm>
    {
        public bool IsDeleted { get; set; } = false;
    }
}
