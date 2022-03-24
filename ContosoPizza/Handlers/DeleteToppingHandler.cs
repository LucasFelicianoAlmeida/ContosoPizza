using ContosoPizza.Context;
using ContosoPizza.Mediator.Commands.Requests;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Nudes.Retornator.AspnetCore.Errors;
using Nudes.Retornator.Core;

namespace ContosoPizza.Handlers
{
    public class DeleteToppingHandler : IRequestHandler<DeleteToppingRequest, Result>
    {
        public ApplicationDbContext _context;
        public DeleteToppingHandler(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<Result> Handle(DeleteToppingRequest request, CancellationToken cancellationToken)
        {
            var topping = await _context.Toppings.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (topping == null)
                return new NotFoundError();

            _context.Toppings.Remove(topping);

            await _context.SaveChangesAsync(cancellationToken);

            return Result.Success;
        }
    }
}
