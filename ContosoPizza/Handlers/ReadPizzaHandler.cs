using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContosoPizza.Context;
using ContosoPizza.Mediator.Commands.Requests;
using ContosoPizza.Mediator.Commands.Responses;
using MediatR;

namespace ContosoPizza.Handlers
{
    public class ReadPizzaHandler : IRequestHandler<ReadPizzaRequest, ReadPizzaResponse>
    {
        public ApplicationDbContext _context;

        public ReadPizzaHandler(ApplicationDbContext context)
        {
            _context = context;
        }
        public Task<ReadPizzaResponse> Handle(ReadPizzaRequest request, CancellationToken cancellationToken)
        {
            var pizza = _context.Pizzas.FirstOrDefault(x => x.Id == request.Id);

            if (pizza == null)
                return null;

            var pizzaResponse = new ReadPizzaResponse() { Id = pizza.Id, Name = pizza.Name, IsGlutenFree = pizza.IsGlutenFree };

            return Task.FromResult(pizzaResponse);

        }
    }
}
