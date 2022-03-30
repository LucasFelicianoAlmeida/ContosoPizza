using ContosoPizza.Context;


using ContosoPizza.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Nudes.Retornator.Core;

namespace ContosoPizza.Features.Toppings.List
{
    public class ListToppingHandler : IRequestHandler<ListToppingRequest, ResultOf<List<ListToppingResponse>>>
    {
        public ApplicationDbContext _context;

        public ListToppingHandler(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ResultOf<List<ListToppingResponse>>> Handle(ListToppingRequest request, CancellationToken cancellationToken)
        {
            var listToppings = _context.Toppings.ToList();

            if (request.FilterByName != null)
            {
                listToppings = listToppings.Where(x => x.Name.ToUpper().Contains(request.FilterByName)).ToList();
            }

            List<ListToppingResponse> list = await _context.Toppings.Where(x => x.Price == request.Price).Skip(request.Quantity * (request.PageNumber - 1)).Take(request.Quantity)
                .Select(t => new ListToppingResponse
                {
                    Id = t.Id,
                    Name = t.Name,
                    Price = t.Price
                }).ToListAsync(cancellationToken);


            return list;
        }
    }
}
