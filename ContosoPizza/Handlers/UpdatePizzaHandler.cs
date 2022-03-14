using ContosoPizza.Mediator.Commands.Requests;
using ContosoPizza.Models;
using MediatR;

namespace ContosoPizza.Handlers
{
    public class UpdatePizzaHandler : IRequestHandler<UpdatePizzaRequest, bool>
    {
        public Task<bool> Handle(UpdatePizzaRequest request, CancellationToken cancellationToken)
        {
            var pizza = PizzaStorage.Pizzas.FirstOrDefault(x => x.Id == request.Id);
            if (pizza == null)
                return Task.FromResult( false);

            pizza.Name = request.Name;
            pizza.IsGlutenFree = request.IsGlutenFree;

            var result = PizzaStorage.UpdatePizza(pizza);

            return Task.FromResult(result);

        }
    }
}
