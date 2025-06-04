﻿using FluentValidation;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace REEP.Application.Features.PaymentTypes.Commands.HardDeletePaymentType
{
    public class HardDeletePaymentTypeValidator
        : AbstractValidator<HardDeletePaymentTypeCommand>
    {
        public HardDeletePaymentTypeValidator()
        {
            RuleFor(hardDeletePaymentTypeCommand => hardDeletePaymentTypeCommand.Id).NotEqual(Guid.Empty);
        }
    }
}
