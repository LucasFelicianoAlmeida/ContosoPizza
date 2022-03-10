using ContosoPizza.Mediator.Commands.Requests;
using FluentValidation;

namespace ContosoPizza.Vatidations
{
    public class UpdatePizzaValidator : AbstractValidator<UpdatePizzaRequest>
    {
        public UpdatePizzaValidator()
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
