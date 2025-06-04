using MediatR;
using REEP.Domain.Models.ContractModels.ContractTypeModels;

namespace REEP.Application.Features.ContractFeatures.ContractTypesFeatures.SupplierTypes.Queries.GetSupplierTypeByTypeDetails
{
    public class GetSupplierTypeByTypeDetailsQuery : IRequest<SupplierTypeByTypeDetailsVm>
    {
        public string Type { get; set; } = null!;
    }
}
