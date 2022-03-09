using ContosoPizza.Mediator.Commands.Requests;
using MediatR;

namespace ContosoPizza.Handlers
{
    public class UpdatePizzaHandler : IRequestHandler<UpdatePizzaRequest, bool>
    {
        public Task<bool> Handle(UpdatePizzaRequest request, CancellationToken cancellationToken)
        {
            var result = PizzaStorage.UpdatePizza(request);

            return Task.FromResult(result);

        }
    }
}
