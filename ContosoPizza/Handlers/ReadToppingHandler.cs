using ContosoPizza.Context;
using ContosoPizza.Mediator.Commands.Requests;
using ContosoPizza.Mediator.Commands.Responses;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ContosoPizza.Handlers
{
    public class ReadToppingHandler : IRequestHandler<ReadToppingRequest, ReadToppingResponse>
    {
        public ApplicationDbContext _context;

        public ReadToppingHandler(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ReadToppingResponse> Handle(ReadToppingRequest request, CancellationToken cancellationToken)
        {
            var topping = await _context.Toppings.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (topping == null) return null;

            var response = new ReadToppingResponse() { Id = topping.Id, Name = topping.Name, Price = topping.Price };

            return response;
        }
    }
}
