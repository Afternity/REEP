using MediatR;

namespace REEP.Application.Features.ContractFeatures.Suppliers.Queries.GetSupplierDetails
{
    public class GetSupplierDetailsQuery : IRequest<SupplierDetailsVm>
    {
        public Guid Id { get; set; }
    }
}
