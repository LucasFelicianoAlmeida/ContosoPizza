using ContosoPizza.Mediator.Commands.Requests;
using FluentValidation;

namespace ContosoPizza.Validators
{
    public class UpdatePizzaRequestValidator : AbstractValidator<UpdatePizzaRequest>
    {
        public UpdatePizzaRequestValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();

            RuleFor(x => x.Name)
                .NotEmpty();

            RuleFor(x => x.IsGlutenFree)
                .NotEmpty();

        }
    }
}
