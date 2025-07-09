using MediatR;

namespace REEP.Application.Features.WarrantyFeatures.Warranties.Queries.GetWarrantyDetails
{
    public class GetWarrantyDetailsQuery
        : IRequest<WarrantyDetailsVm>
    {
        public Guid Id { get; set; }
    }
}
