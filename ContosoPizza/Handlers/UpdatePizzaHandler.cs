﻿using ContosoPizza.Context;
using ContosoPizza.Mediator.Commands.Requests;
using ContosoPizza.Models;
using MediatR;

namespace ContosoPizza.Handlers
{
    public class UpdatePizzaHandler : IRequestHandler<UpdatePizzaRequest, bool>
    {
        public ApplicationDbContext _context;

        public UpdatePizzaHandler(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Handle(UpdatePizzaRequest request, CancellationToken cancellationToken)
        {
            var pizza = _context.Pizzas.FirstOrDefault(x => x.Id == request.Id);

            if (pizza == null)
                return false;

            pizza.Name = request.Name;
            pizza.IsGlutenFree = request.IsGlutenFree;
            pizza.Price = request.Price;

            _context.Pizzas.Update(pizza);

            await _context.SaveChangesAsync(); 

            return true;

        }
    }
}
