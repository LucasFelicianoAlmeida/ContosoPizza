using ContosoPizza.Mediator.Requests;
using FluentValidation;

namespace ContosoPizza.Validators
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
