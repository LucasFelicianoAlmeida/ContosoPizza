using ContosoPizza.Context;
using ContosoPizza.Mediator.Commands.Requests;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ContosoPizza.Handlers
{
    public class DeleteToppingHandler : IRequestHandler<DeleteToppingRequest, bool>
    {
        public ApplicationDbContext _context;
        public DeleteToppingHandler(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<bool> Handle(DeleteToppingRequest request, CancellationToken cancellationToken)
        {
            var topping = await _context.Toppings.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (topping == null) return false;

            _context.Toppings.Remove(topping);

            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
