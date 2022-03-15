using ContosoPizza.Mediator.Commands.Requests;
using FluentValidation;

namespace ContosoPizza.Validators
{
    public class DeleteToppingRequestValidator : AbstractValidator<DeleteToppingRequest>
    {
        public DeleteToppingRequestValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();
        }
    }
}
