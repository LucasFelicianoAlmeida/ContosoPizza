using ContosoPizza.Mediator.Commands.Requests;
using FluentValidation;

namespace ContosoPizza.Vatidations
{
    public class DeletePizzaRequestValidator : AbstractValidator<DeletePizzaRequest>
    {
        public DeletePizzaRequestValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();
        }
    }
}
