using ContosoPizza.Context;
using ContosoPizza.Mediator.Commands.Requests;
using ContosoPizza.Models;
using MediatR;
using Nudes.Retornator.AspnetCore.Errors;
using Nudes.Retornator.Core;

namespace ContosoPizza.Handlers
{
    public class CreateToppingHandler : IRequestHandler<CreateToppingRequest, Result>
    {
        public ApplicationDbContext _context;
        public CreateToppingHandler(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<Result> Handle(CreateToppingRequest request, CancellationToken cancellationToken)
        {

            var topping = new Topping(request.Name, request.Price);

            _context.Toppings.Add(topping);


            await _context.SaveChangesAsync(cancellationToken);

            return Result.Success;

        }
    }
}
