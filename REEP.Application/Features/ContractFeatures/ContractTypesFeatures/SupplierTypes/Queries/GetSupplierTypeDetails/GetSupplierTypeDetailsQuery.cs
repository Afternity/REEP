

using MediatR;

namespace REEP.Application.Features.ContractFeatures.ContractTypesFeatures.SupplierTypes.Queries.GetSupplierTypeDetails
{
    public class GetSupplierTypeDetailsQuery : IRequest<SupplierTypeDetailsVm>
    {
        public Guid Id { get; set; }
    }
}
