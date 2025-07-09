using MediatR;

namespace REEP.Application.Features.WarrantyFeatures.Warranties.Queries.GetWarrantyList
{
    public class GetWarrantyListQuery
        : IRequest<WarrantyListVm>
    {
        public bool IsDeleted { get; set; } = false;
    }
}
