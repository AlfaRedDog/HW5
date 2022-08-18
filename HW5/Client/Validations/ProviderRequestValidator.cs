using Client.Validations.Interfaces;
using FluentValidation;
using FluentValidation.Results;
using HW3.Models.Requests;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Client.Validations
{
    public class ProviderRequestValidator : AbstractValidator<ProviderRequest>, IProviderRequestValidator
    {
        [Obsolete]
        public ProviderRequestValidator()
        {
            RuleFor(request => request.Name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Name can't be empty")
                .MinimumLength(2)
                .WithMessage("Name too short")
                .MaximumLength(50)
                .WithMessage("Name is too long");

            RuleFor(request => request.Adress)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Adress can't be empty")
                .MinimumLength(20)
                .WithMessage("Adress too short")
                .MaximumLength(150)
                .WithMessage("Adress is too long");
        }
    }
}
