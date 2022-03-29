using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContosoPizza.Context;
using ContosoPizza.Mediator.Commands.Requests;
using ContosoPizza.Mediator.Commands.Responses;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Nudes.Retornator.AspnetCore.Errors;
using Nudes.Retornator.Core;

namespace ContosoPizza.Handlers
{
    public class ReadPizzaHandler : IRequestHandler<ReadPizzaRequest, ResultOf<ReadPizzaResponse>>
    {
        public ApplicationDbContext _context;

        public ReadPizzaHandler(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ResultOf<ReadPizzaResponse>> Handle(ReadPizzaRequest request, CancellationToken cancellationToken)
        {
            var pizza = await _context.Pizzas.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (pizza == null)
                return new NotFoundError();

            var pizzaResponse = new ReadPizzaResponse() { Id = pizza.Id, Name = pizza.Name, IsGlutenFree = pizza.IsGlutenFree };

            return pizzaResponse;

        }
    }
}
