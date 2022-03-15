using ContosoPizza.Mediator.Commands.Requests;
using ContosoPizza.Mediator.Requests;
using FluentValidation;

namespace ContosoPizza.Validators
{
    public class CreateToppingRequestValidator : AbstractValidator<CreateToppingRequest>
    {
        public CreateToppingRequestValidator()
        {

            RuleFor(x => x.Name)
                .NotEmpty();

            RuleFor(x => x.Price)
                .NotEmpty();
        }
    }
}
