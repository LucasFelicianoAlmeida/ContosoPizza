using ContosoPizza.Context;


using ContosoPizza.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Nudes.Paginator.Core;
using Nudes.Retornator.Core;

namespace ContosoPizza.Features.Toppings.List
{
    public class ListToppingHandler : IRequestHandler<ListToppingRequest, ResultOf<PageResult<ListToppingResponse>>>
    {
        public ApplicationDbContext _context;

        public ListToppingHandler(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ResultOf<PageResult<ListToppingResponse>>> Handle(ListToppingRequest request, CancellationToken cancellationToken)
        {
            var toppingQuery = _context.Toppings.AsQueryable();

            if (!string.IsNullOrWhiteSpace(request.FilterByName))
                toppingQuery = toppingQuery.Where(x => x.Name.Contains(request.FilterByName));

            if (request.MinimunPrice.HasValue)
                toppingQuery = toppingQuery.Where(x => x.Price >= request.MinimunPrice);

            if (request.MaximumPrice.HasValue)
                toppingQuery = toppingQuery.Where(x => x.Price <= request.MaximumPrice);

            var listToppings = await toppingQuery.PaginateBy(request,t => t.Name)
                .Select(t => new ListToppingResponse
                {
                    Id = t.Id,
                    Name = t.Name,
                    Price = t.Price
                }).ToListAsync(cancellationToken);

            var total = await toppingQuery.CountAsync(cancellationToken);

            var result = new PageResult<ListToppingResponse>(request, total, listToppings);

            return result;
        }
    }
}
