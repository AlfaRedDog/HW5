using Client.Validations.Interfaces;
using FluentValidation;
using HW3.Models.Requests;
using System;

namespace Client.Validations
{
    public class OrderRequestValidator : AbstractValidator<OrderRequest>, IOrderRequestValidator
    {
        [Obsolete]
        public OrderRequestValidator()
        {
            RuleFor(request => request.Amount)
                .Must(a => a >= 0)
                .WithMessage("Amount can't be negative");
        }
    }
}
