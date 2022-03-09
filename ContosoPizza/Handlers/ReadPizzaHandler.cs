using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContosoPizza.Mediator.Commands.Requests;
using ContosoPizza.Mediator.Commands.Responses;
using MediatR;

namespace ContosoPizza.Handlers
{
    public class ReadPizzaHandler : IRequestHandler<ReadPizzaRequest, ReadPizzaResponse>
    {
        public Task<ReadPizzaResponse> Handle(ReadPizzaRequest request, CancellationToken cancellationToken)
        {
            var pizza = PizzaStore.Pizzas.FirstOrDefault(x => x.Id == request.Id);
            var pizzaResponse = new ReadPizzaResponse() {Id = pizza.Id,Name = pizza.Name,IsGlutenFree = pizza.IsGlutenFree };
            return Task.FromResult(pizzaResponse);

        }
    }
}
