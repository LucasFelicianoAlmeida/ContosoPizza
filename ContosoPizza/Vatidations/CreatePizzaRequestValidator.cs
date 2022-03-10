using ContosoPizza.Mediator.Requests;
using FluentValidation;

namespace ContosoPizza.Vatidations
{
    public class CreatePizzaRequestValidator : AbstractValidator<CreatePizzaRequest>
    {
        public CreatePizzaRequestValidator()
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
