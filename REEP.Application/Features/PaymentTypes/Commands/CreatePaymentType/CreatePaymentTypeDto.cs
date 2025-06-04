using AutoMapper;
using REEP.Application.Common.Mappings;

namespace REEP.Application.Features.PaymentTypes.Commands.CreatePaymentType
{
    public class CreatePaymentTypeDto : IMapWith<CreatePaymentTypeCommand>
    {
        public string Type { get; set; } = null!;
        public bool IsDeleted { get; set; } = false;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreatePaymentTypeDto, CreatePaymentTypeCommand>();
        }
    }
}
