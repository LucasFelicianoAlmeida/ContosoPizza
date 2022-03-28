using ContosoPizza.Context;
using ContosoPizza.Mediator.Commands.Requests;
using ContosoPizza.Models;
using MediatR;
using Nudes.Retornator.AspnetCore.Errors;
using Nudes.Retornator.Core;

namespace ContosoPizza.Handlers
{
    public class CreateToppingHandler : IRequestHandler<CreateToppingRequest, ResultOf<bool>>
    {
        public ApplicationDbContext _context;
        public CreateToppingHandler(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<ResultOf<bool>> Handle(CreateToppingRequest request, CancellationToken cancellationToken)
        {

            var topping = new Topping(request.Name, request.Price);

            _context.Toppings.Add(topping);

            try
            {
                await _context.SaveChangesAsync(cancellationToken);

                return true;
            }
            catch (Exception) { return new ServiceUnavaiableError("CreateToppingHandler"); }
        }
    }
}
