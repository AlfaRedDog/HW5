using FluentValidation;
using HW3.Models.Requests;
namespace Client.Validations.Interfaces
{
    public interface IItemRequestValidator : IValidator<ItemRequest>
    {
    }
}
