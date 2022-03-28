using ContosoPizza.Context;
using ContosoPizza.Mediator.Requests;
using ContosoPizza.Models;
using MediatR;
using Nudes.Retornator.AspnetCore.Errors;
using Nudes.Retornator.Core;

namespace ContosoPizza.Handlers
{
    public class CreatePizzaHandler : IRequestHandler<CreatePizzaRequest, ResultOf<bool>>
    {

        private ApplicationDbContext _context;
        public CreatePizzaHandler(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ResultOf<bool>> Handle(CreatePizzaRequest request, CancellationToken cancellationToken)
        {
            var pizza = new Pizza(request.Name, request.Price, request.IsGlutenFree);

            _context.Pizzas.Add(pizza);

            await _context.SaveChangesAsync(cancellationToken);

            return true;


        }
    }
}