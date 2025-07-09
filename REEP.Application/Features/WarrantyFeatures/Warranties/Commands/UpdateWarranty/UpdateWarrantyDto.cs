using AutoMapper;
using REEP.Application.Common.Mappings;

namespace REEP.Application.Features.WarrantyFeatures.Warranties.Commands.UpdateWarranty
{
    public class UpdateWarrantyDto
        : IMapWith<UpdateWarrantyCommand>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime StartedAt { get; set; }
        public DateTime EndedAt { get; set; }
        public Guid ContractId { get; set; }
        public Guid WarrantyTypeId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateWarrantyDto, UpdateWarrantyCommand>();
        }
    }
}
