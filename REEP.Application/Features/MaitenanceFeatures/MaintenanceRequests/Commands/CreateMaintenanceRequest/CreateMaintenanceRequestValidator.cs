using FluentValidation;

namespace REEP.Application.Features.MaitenanceFeatures.MaintenanceRequests.Commands.CreateMaintenanceRequest
{
    public class CreateMaintenanceRequestValidator
        : AbstractValidator<CreateMaintenanceRequestCommand>
    {
        public CreateMaintenanceRequestValidator()
        {
            RuleFor(command => command.Description)
                .NotEmpty()
                .MaximumLength(200);
            RuleFor(command => command.CreateByUserId)
                .NotEqual(Guid.Empty);
        }
    }
}
