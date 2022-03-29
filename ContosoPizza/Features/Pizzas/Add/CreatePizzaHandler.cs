using ContosoPizza.Context;
using ContosoPizza.Models;
using MediatR;
using Nudes.Retornator.AspnetCore.Errors;
using Nudes.Retornator.Core;

namespace ContosoPizza.Features.Pizzas.Add
{
    public class CreatePizzaHandler : IRequestHandler<CreatePizzaRequest, Result>
    {

        private ApplicationDbContext _context;
        public CreatePizzaHandler(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Result> Handle(CreatePizzaRequest request, CancellationToken cancellationToken)
        {
            var pizza = new Pizza(request.Name, request.Price, request.IsGlutenFree);

            _context.Pizzas.Add(pizza);

            await _context.SaveChangesAsync(cancellationToken);

            return Result.Success;


        }
    }
}