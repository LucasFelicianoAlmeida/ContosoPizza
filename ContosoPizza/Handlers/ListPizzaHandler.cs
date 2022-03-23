
using ContosoPizza.Context;
using ContosoPizza.Mediator.Requests;
using ContosoPizza.Mediator.Responses;
using MediatR;

namespace ContosoPizza.Handlers
{
    public class ListPizzaHandler : IRequestHandler<ListPizzaRequest, List<ListPizzaResponse>>
    {
        public ApplicationDbContext _context;

        public ListPizzaHandler(ApplicationDbContext context)
        {
            _context = context;
        }


        public Task<List<ListPizzaResponse>> Handle(ListPizzaRequest request, CancellationToken cancellationToken)
        {

            var pizzas = _context.Pizzas.Select(p => new ListPizzaResponse
            {
                Id = p.Id,
                IsGlutenFree = p.IsGlutenFree,
                Name = p.Name,
                Price = p.Price
            }).ToList();

            return Task.FromResult(pizzas);
        }
    }
}