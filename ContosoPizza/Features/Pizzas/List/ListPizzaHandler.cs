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
            if (request.IsGlutenFreeFilter.HasValue)
            {
                pizzaQuery.Where(x => x.IsGlutenFree == true);
            }

            if (request.FilterByName != null)
            {
                pizzaQuery.Where(x => x.Name.ToUpper().Contains(request.FilterByName.ToUpper()));
            }

            List<ListPizzaResponse> pizzas = await pizzaQuery.Skip((request.PageNumber - 1) * request.Quantity).Take(request.Quantity).Select(p => new ListPizzaResponse
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