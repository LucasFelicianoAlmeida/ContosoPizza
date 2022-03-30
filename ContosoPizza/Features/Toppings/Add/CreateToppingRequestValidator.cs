
using FluentValidation;

namespace ContosoPizza.Features.Toppings.Add
{
    public class CreateToppingRequestValidator : AbstractValidator<CreateToppingRequest>
    {
        public CreateToppingRequestValidator()
        {

            RuleFor(x => x.Name)
                .NotEmpty();

            RuleFor(x => x.Price).GreaterThanOrEqualTo(0);
                
        }
    }
}
