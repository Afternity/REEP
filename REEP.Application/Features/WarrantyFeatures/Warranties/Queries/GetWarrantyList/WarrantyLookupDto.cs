using AutoMapper;
using REEP.Application.Common.Mappings;
using REEP.Application.Features.WarrantyFeatures.Warranties.Queries.GetWarrantyDetails;
using REEP.Domain.Models.WarrantyModels;

namespace REEP.Application.Features.WarrantyFeatures.Warranties.Queries.GetWarrantyList
{
    public class WarrantyLookupDto
        : IMapWith<Warranty>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime StartedAt { get; set; }
        public DateTime EndedAt { get; set; }
        public string ContractName { get; set; } = null!;
        public string ContractType { get; set; } = null!;
        public string WarrantyType { get; set; } = null!;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Warranty, WarrantyLookupDto>()
                .ForMember(destination => destination.ContractName,
                    options => options.MapFrom(source => source.Contract.Name))
                .ForMember(destination => destination.ContractType,
                    options => options.MapFrom(source => source.Contract.ContractType.Type))
                .ForMember(destination => destination.WarrantyType,
                    options => options.MapFrom(source => source.WarrantyType.Type));
        }
    }
}
