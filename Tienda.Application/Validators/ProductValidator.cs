using FluentValidation;
using Tienda.Application.Dtos.Requests;

namespace Tienda.Application.Validators
{
    public class ProductValidator : AbstractValidator<ProductDtoRequest>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Name)
                .NotNull().WithMessage("El campo Nombre no puede ser nulo")
                .NotEmpty().WithMessage("El campo Nombre no puede estar vacío")
                .MaximumLength(100).WithMessage("El campo no puede tener mas de 100 caracteres");
            RuleFor(p => p.Price)
                .NotNull().WithMessage("El campo Nombre no puede ser nulo")
                .NotEmpty().WithMessage("El campo Nombre no puede estar vacío");
            RuleFor(p => p.Category)
                .NotNull().WithMessage("El campo Nombre no puede ser nulo")
                .NotEmpty().WithMessage("El campo Nombre no puede estar vacío");
        }
    }
}
