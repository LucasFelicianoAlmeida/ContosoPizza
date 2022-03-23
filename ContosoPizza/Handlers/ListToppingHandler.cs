using ContosoPizza.Context;
using ContosoPizza.Mediator.Commands.Requests;
using ContosoPizza.Mediator.Commands.Responses;
using ContosoPizza.Models;
using MediatR;

namespace ContosoPizza.Handlers
{
    public class ListToppingHandler : IRequestHandler<ListToppingRequest, List<ListToppingResponse>>
    {
        public ApplicationDbContext _context;

        public ListToppingHandler(ApplicationDbContext context)
        {
            _context = context;
        }
        public Task<List<ListToppingResponse>> Handle(ListToppingRequest request, CancellationToken cancellationToken)
        {
            var listToppings = _context.Toppings.Select(t => new ListToppingResponse
            {
                Id = t.Id, 
                Name = t.Name,
                Price = t.Price
            }).ToList();

            return Task.FromResult(listToppings);
        }
    }
}
