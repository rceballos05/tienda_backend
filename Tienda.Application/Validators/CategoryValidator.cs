using FluentValidation;
using Tienda.Application.Dtos.Requests;

namespace Tienda.Application.Validators
{
    public class CategoryValidator : AbstractValidator<CategoryDtoRequest>
    {
        public CategoryValidator()
        {
            RuleFor(c => c.Name)
                .NotNull().WithMessage("El campo Nombre no puede ser nulo")
                .NotEmpty().WithMessage("El campo Nombre no puede estar vacío")
                .MaximumLength(100).WithMessage("El campo no puede tener mas de 100 caracteres");
        }
    }
}
