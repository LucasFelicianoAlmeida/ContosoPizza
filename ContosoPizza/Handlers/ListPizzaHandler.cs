
using ContosoPizza.Context;
using ContosoPizza.Mediator.Requests;
using ContosoPizza.Mediator.Responses;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ContosoPizza.Handlers
{
    public class ListPizzaHandler : IRequestHandler<ListPizzaRequest, List<ListPizzaResponse>>
    {
        public ApplicationDbContext _context;

        public ListPizzaHandler(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<List<ListPizzaResponse>> Handle(ListPizzaRequest request, CancellationToken cancellationToken)
        {

            var pizzas = await  _context.Pizzas.Select(p => new ListPizzaResponse
            {
                Id = p.Id,
                IsGlutenFree = p.IsGlutenFree,
                Name = p.Name,
                Price = p.Price
            }).ToListAsync();

            return  pizzas;
        }
    }
}