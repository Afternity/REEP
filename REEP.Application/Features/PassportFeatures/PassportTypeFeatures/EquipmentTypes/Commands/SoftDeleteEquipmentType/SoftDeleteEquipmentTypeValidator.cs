using FluentValidation;

namespace REEP.Application.Features.EquipmentFeatures.EquipmentTypeFeatures.EquipmentTypes.Commands.SoftDeleteEquipmentType
{
    public class SoftDeleteStatusTypeValidator
        : AbstractValidator<SoftDeleteStatusTypeCommand>
    {
        public SoftDeleteStatusTypeValidator()
        {
            RuleFor(command => command.Id)
                .NotEqual(Guid.Empty);
            RuleFor(command => command.IsDeleted)
                .NotNull();
        }
    }
}
