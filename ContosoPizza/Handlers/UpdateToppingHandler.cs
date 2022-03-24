using ContosoPizza.Context;
using ContosoPizza.Mediator.Commands.Requests;
using ContosoPizza.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ContosoPizza.Handlers
{
    public class UpdateToppingHandler : IRequestHandler<UpdateToppingRequest, bool>
    {
        public ApplicationDbContext _context;

        public UpdateToppingHandler(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Handle(UpdateToppingRequest request, CancellationToken cancellationToken)
        {
            var topping = await _context.Toppings.FirstOrDefaultAsync(x => x.Id == request.Id);

            if(topping == null) return false;

            topping.Name = request.Name;
            topping.Price = request.Price;

            _context.Toppings.Update(topping);

            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
