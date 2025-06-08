using AutoMapper;
using REEP.Application.Common.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REEP.Application.Features.ContractFeatures.Suppliers.Commands.CreateSupplier
{
    public class CreateSupplierDto : IMapWith<CreateSupplierCommand>
    {
        public string? FirstName { get; set; }
        public string? SecondName { get; set; }
        public string? LastName { get; set; }
        public string? OtherName { get; set; }
        public string? Number { get; set; }
        public string? Email { get; set; }
        public string? OtherContacts { get; set; }
        public bool IsDeleted { get; set; } = false;
        public string Type { get; set; } = null!;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateSupplierDto, CreateSupplierCommand>();
        }
    }
}
