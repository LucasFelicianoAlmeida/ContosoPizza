using ContosoPizza.Context;
using ContosoPizza.Mediator.Commands.Requests;
using ContosoPizza.Mediator.Commands.Responses;
using ContosoPizza.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ContosoPizza.Handlers
{
    public class ListToppingHandler : IRequestHandler<ListToppingRequest, List<ListToppingResponse>>
    {
        public ApplicationDbContext _context;

        public ListToppingHandler(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<ListToppingResponse>> Handle(ListToppingRequest request, CancellationToken cancellationToken)
        {
            var listToppings = await _context.Toppings.Select(t => new ListToppingResponse
            {
                Id = t.Id, 
                Name = t.Name,
                Price = t.Price
            }).ToListAsync();

            return listToppings;
        }
    }
}
