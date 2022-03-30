
using FluentValidation;

namespace ContosoPizza.Features.Pizzas.Read
{
    public class ReadPizzaRequestValidator : AbstractValidator<ReadPizzaRequest>
    {
        public ReadPizzaRequestValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();
        }
    }
}
