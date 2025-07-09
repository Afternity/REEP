using AutoMapper;
using REEP.Application.Common.Mappings;
using REEP.Domain.Models.WarrantyModels;

namespace REEP.Application.Features.WarrantyFeatures.Warranties.Queries.GetWarrantyDetails
{
    public class WarrantyDetailsVm
        : IMapWith<Warranty>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime StartedAt { get; set; }
        public DateTime EndedAt { get; set; }
        public DateTime CreatedAt { get; set; } 
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool IsDeleted { get; set; } 
        public string ContractName { get; set; } = null!;
        public string ContractType { get; set; } = null!;
        public string WarrantyType { get; set; } = null!;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Warranty, WarrantyDetailsVm>()
                .ForMember(destination => destination.ContractName,
                    options => options.MapFrom(source => source.Contract.Name))
                .ForMember(destination => destination.ContractType,
                    options => options.MapFrom(source => source.Contract.ContractType.Type))
                .ForMember(destination => destination.WarrantyType,
                    options => options.MapFrom(source => source.WarrantyType.Type));
        }
    }
}
