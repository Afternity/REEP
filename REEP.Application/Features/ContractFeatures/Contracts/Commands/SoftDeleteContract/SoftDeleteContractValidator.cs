using FluentValidation;
using Microsoft.EntityFrameworkCore.Metadata;

namespace REEP.Application.Features.ContractFeatures.Contracts.Commands.SoftDeleteContract
{
    public class SoftDeleteContractValidator
        : AbstractValidator<SoftDeleteContractCommand>
    {
        public SoftDeleteContractValidator()
        {
            RuleFor(softDeleteContractCommand => softDeleteContractCommand.Id)
                .NotEqual(Guid.Empty);
            RuleFor(softDeleteContractCommand => softDeleteContractCommand.IsDeleted)
                .NotNull();
        }
    }
}
