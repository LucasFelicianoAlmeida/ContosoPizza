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
            var pizzaQuery = _context.Pizzas.AsQueryable();

            if (!string.IsNullOrWhiteSpace(request.FilterByName))
                pizzaQuery = pizzaQuery.Where(x => x.Name.Contains(request.FilterByName));

            if (request.IsGlutenFreeFilter.HasValue)
                pizzaQuery = pizzaQuery.Where(x => x.IsGlutenFree == request.IsGlutenFreeFilter);

            if (request.MaximumPrice.HasValue)
                pizzaQuery = pizzaQuery.Where(x => x.Price <= request.MaximumPrice);

            if (request.MinimumPrice.HasValue)
                pizzaQuery = pizzaQuery.Where(x => x.Price >= request.MinimumPrice);

            List<ListPizzaResponse> pizzas = await pizzaQuery.OrderBy(x => x.Name).Skip((request.PageNumber - 1) * request.Quantity).Take(request.Quantity).Select(p => new ListPizzaResponse
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