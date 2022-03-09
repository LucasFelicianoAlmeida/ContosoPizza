using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContosoPizza.Mediator.Commands.Requests;
using ContosoPizza.Mediator.Commands.Responses;
using MediatR;
namespace ContosoPizza.Handlers
{
    public class DeletePizzaHandler : IRequestHandler<DeletePizzaRequest, bool>
    {
        public Task<bool> Handle(DeletePizzaRequest request, CancellationToken cancellationToken)
        {
            var pizza = PizzaStore.Pizzas.FirstOrDefault(x => x.Id == request.Id);
            if (pizza == null)
                return Task.FromResult(false);

            PizzaStore.Pizzas.Remove(pizza);
            return Task.FromResult(true);
        }
    }
}
