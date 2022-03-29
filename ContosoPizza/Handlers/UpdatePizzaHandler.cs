using ContosoPizza.Context;
using ContosoPizza.Mediator.Commands.Requests;
using ContosoPizza.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Nudes.Retornator.AspnetCore.Errors;
using Nudes.Retornator.Core;

namespace ContosoPizza.Handlers
{
    public class UpdatePizzaHandler : IRequestHandler<UpdatePizzaRequest, Result>
    {
        public ApplicationDbContext _context;

        public UpdatePizzaHandler(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Result> Handle(UpdatePizzaRequest request, CancellationToken cancellationToken)
        {
            var pizza = await _context.Pizzas.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (pizza == null)
                return new NotFoundError();

            pizza.Name = request.Name;
            pizza.IsGlutenFree = request.IsGlutenFree;
            pizza.Price = request.Price;

            _context.Pizzas.Update(pizza);

            await _context.SaveChangesAsync(cancellationToken); 

            return Result.Success;

        }
    }
}
