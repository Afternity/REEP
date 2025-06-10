using MediatR;

namespace REEP.Application.Features.ContractFeatures.ContractTypesFeatures.SupplierTypes.Queries.GetSupplierTypeList
{
    public class GetWarrantyTypeListQuery : IRequest<WarrantyTypeListVm>
    {
        public bool IsDeleted { get; set; } = false;
    }
}
