using AutoMapper;
using REEP.Application.Common.Mappings;

namespace REEP.Application.Features.WarrantyFeatures.Warranties.Commands.CreateWarrantyByType
{
    public class CreateWarrantyByTypeDto
        : IMapWith<CreateWarrantyByTypeCommand>
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime StartedAt { get; set; }
        public DateTime EndedAt { get; set; }
        public bool IsDeleted { get; set; } = false;
        public Guid ContractId { get; set; }
        public string WarrantyType { get; set; } = null!;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateWarrantyByTypeDto, CreateWarrantyByTypeCommand>();
        }
    }
}
