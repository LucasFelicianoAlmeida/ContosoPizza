using ContosoPizza.Mediator.Commands.Requests;
using FluentValidation;

namespace ContosoPizza.Vatidations
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
