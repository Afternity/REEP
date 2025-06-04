using AutoMapper;
using REEP.Application.Common.Mappings;

namespace REEP.Application.Features.PaymentTypes.Commands.UpdatePaymentType
{
    public class UpdatePaymentTypeDto : IMapWith<UpdatePaymentTypeCommand>
    {
        public Guid Id { get; set; }
        public string Type { get; set; } = null!;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdatePaymentTypeDto, UpdatePaymentTypeCommand>();
        }
    }
}
