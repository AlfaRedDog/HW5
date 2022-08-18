using Client.Validations.Interfaces;
using FluentValidation;
using FluentValidation.Results;
using HW3.Models.Requests;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Client.Validations
{
    public class ItemRequestValidator : AbstractValidator<ItemRequest>, IItemRequestValidator
    {
        [Obsolete]
        public ItemRequestValidator()
        {
            RuleFor(request => request.Amount)
                 .Must(a => a >= 0)
                 .WithMessage("Amount can't be negative");

            RuleFor(request => request.Price)
                .Must(a => a >= 0)
                .WithMessage("Price can't be negative");
        }
    }
}
