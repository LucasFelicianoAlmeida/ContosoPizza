using FluentValidation;

namespace ContosoPizza.Features.Pizzas.Add
{
    public class CreatePizzaRequestValidator : AbstractValidator<CreatePizzaRequest>
    {
        public CreatePizzaRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty();
        }
    }
}
