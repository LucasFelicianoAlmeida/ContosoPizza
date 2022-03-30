
using FluentValidation;

namespace ContosoPizza.Features.Pizzas.Update
{
    public class UpdatePizzaRequestValidator : AbstractValidator<UpdatePizzaRequest>
    {
        public UpdatePizzaRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
