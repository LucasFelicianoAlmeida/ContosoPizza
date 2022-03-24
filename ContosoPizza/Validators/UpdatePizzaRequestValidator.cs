using ContosoPizza.Mediator.Commands.Requests;
using FluentValidation;

namespace ContosoPizza.Validators
{
    public class UpdatePizzaRequestValidator : AbstractValidator<UpdatePizzaRequest>
    {
        public UpdatePizzaRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
