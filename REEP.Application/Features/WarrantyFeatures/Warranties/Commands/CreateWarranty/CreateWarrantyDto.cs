using AutoMapper;
using REEP.Application.Common.Mappings;

namespace REEP.Application.Features.WarrantyFeatures.Warranties.Commands.CreateWarranty
{
    public class CreateWarrantyDto
        : IMapWith<CreateWarrantyCommand>
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime StartedAt { get; set; }
        public DateTime EndedAt { get; set; }
        public bool IsDeleted { get; set; } = false;
        public Guid ContractId { get; set; }
        public Guid WarrantyTypeId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateWarrantyDto, CreateWarrantyCommand>();
        }
    }
}
