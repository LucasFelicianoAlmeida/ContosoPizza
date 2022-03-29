using ContosoPizza.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Nudes.Retornator.Core;

namespace ContosoPizza.Features.Pizzas.List
{
    public class ListPizzaHandler : IRequestHandler<ListPizzaRequest, ResultOf<List<ListPizzaResponse>>>
    {
        public ApplicationDbContext _context;

        public ListPizzaHandler(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<ResultOf<List<ListPizzaResponse>>> Handle(ListPizzaRequest request, CancellationToken cancellationToken)
        {

            var pizzas = await _context.Pizzas.Select(p => new ListPizzaResponse
            {
                Id = p.Id,
                IsGlutenFree = p.IsGlutenFree,
                Name = p.Name,
                Price = p.Price
            }).ToListAsync(cancellationToken);

            return pizzas;
        }
    }
}