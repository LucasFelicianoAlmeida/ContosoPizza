using ContosoPizza.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Nudes.Retornator.Core;
using Nudes.Paginator;
using Nudes.Paginator.Core;

namespace ContosoPizza.Features.Pizzas.List
{
    public class ListPizzaHandler : IRequestHandler<ListPizzaRequest, ResultOf<PageResult<ListPizzaResponse>>>
    {
        public ApplicationDbContext _context;

        public ListPizzaHandler(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<ResultOf<PageResult<ListPizzaResponse>>> Handle(ListPizzaRequest request, CancellationToken cancellationToken)
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

            var toppingsList = await pizzaQuery.PaginateBy(request, p => p.Name)
                  .Select(x => new ListPizzaResponse
                  {
                      Name = x.Name,
                      Id = x.Id,
                      IsGlutenFree = x.IsGlutenFree,
                      Price = x.Price
                  }).ToListAsync(cancellationToken);

            var total = await pizzaQuery.CountAsync(cancellationToken);

            var result = new PageResult<ListPizzaResponse>(request, total, toppingsList);

            return result;
        }
    }
}