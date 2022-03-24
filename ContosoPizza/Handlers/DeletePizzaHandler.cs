using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContosoPizza.Context;
using ContosoPizza.Mediator.Commands.Requests;
using ContosoPizza.Mediator.Commands.Responses;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ContosoPizza.Handlers
{
    public class DeletePizzaHandler : IRequestHandler<DeletePizzaRequest, bool>
    {
        public ApplicationDbContext _context;
        public DeletePizzaHandler(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<bool> Handle(DeletePizzaRequest request, CancellationToken cancellationToken)
        {
            var pizza = await _context.Pizzas.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (pizza == null)
                return false;

            _context.Pizzas.Remove(pizza);

            await _context.SaveChangesAsync(cancellationToken);


            return true;
        }
    }
}
