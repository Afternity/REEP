using MediatR;

namespace REEP.Application.Features.WarrantyFeatures.WarrantyTypeFeatures.WarrantyTypes.Commands.CreateWarrantyType
{
    public class CreateWarratyTypeCommand : IRequest<Guid>
    {
        public string Type { get; set; } = null!;
        public bool IsDeleted { get; set; } = false;
    }
}
