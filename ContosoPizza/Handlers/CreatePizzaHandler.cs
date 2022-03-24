using ContosoPizza.Context;
using ContosoPizza.Mediator.Requests;
using ContosoPizza.Models;
using MediatR;

namespace ContosoPizza.Handlers
{
    public class CreatePizzaHandler : IRequestHandler<CreatePizzaRequest, (bool,int)>
    {

        private ApplicationDbContext _context;
        public CreatePizzaHandler(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<(bool,int)> Handle(CreatePizzaRequest request, CancellationToken cancellationToken)
        {
            var pizza = new Pizza(request.Name,request.Price,request.IsGlutenFree);

            _context.Pizzas.Add(pizza);

            await _context.SaveChangesAsync(cancellationToken);

            return (true,pizza.Id);
        }
    }
}