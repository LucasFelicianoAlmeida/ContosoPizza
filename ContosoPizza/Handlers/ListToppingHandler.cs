using ContosoPizza.Context;
using ContosoPizza.Mediator.Commands.Requests;
using ContosoPizza.Mediator.Commands.Responses;
using ContosoPizza.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Nudes.Retornator.Core;

namespace ContosoPizza.Handlers
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
            var listToppings = await _context.Toppings.Select(t => new ListToppingResponse
            {
                Id = t.Id, 
                Name = t.Name,
                Price = t.Price
            }).ToListAsync(cancellationToken);

            return listToppings;
        }
    }
}
