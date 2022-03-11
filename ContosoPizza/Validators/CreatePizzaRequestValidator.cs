using ContosoPizza.Mediator.Requests;
using FluentValidation;

namespace ContosoPizza.Validators
{
    public class CreatePizzaRequestValidator : AbstractValidator<CreatePizzaRequest>
    {
        public CreatePizzaRequestValidator()
        {
            RuleFor(x => x.Id)
                .Null();

            RuleFor(x => x.IsGlutenFree)
                .NotEmpty();

            RuleFor(x => x.Name)
                .NotEmpty();
        }
    }
}
