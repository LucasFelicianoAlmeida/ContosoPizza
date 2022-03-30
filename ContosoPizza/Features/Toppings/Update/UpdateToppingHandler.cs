using ContosoPizza.Context;
using ContosoPizza.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Nudes.Retornator.AspnetCore.Errors;
using Nudes.Retornator.Core;

namespace ContosoPizza.Features.Toppings.Update
{
    public class UpdateToppingHandler : IRequestHandler<UpdateToppingRequest, Result>
    {
        public ApplicationDbContext _context;

        public UpdateToppingHandler(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Result> Handle(UpdateToppingRequest request, CancellationToken cancellationToken)
        {
            var topping = await _context.Toppings.FirstOrDefaultAsync(x => x.Id == request.Id,cancellationToken);

            if(topping == null)
                return new NotFoundError();

            topping.Name = request.Name;
            topping.Price = request.Price;

            _context.Toppings.Update(topping);

            await _context.SaveChangesAsync(cancellationToken);

            return Result.Success;
        }
    }
}
