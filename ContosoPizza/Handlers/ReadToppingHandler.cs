using ContosoPizza.Context;
using ContosoPizza.Mediator.Commands.Requests;
using ContosoPizza.Mediator.Commands.Responses;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Nudes.Retornator.AspnetCore.Errors;
using Nudes.Retornator.Core;

namespace ContosoPizza.Handlers
{
    public class ReadToppingHandler : IRequestHandler<ReadToppingRequest, ResultOf<ReadToppingResponse>>
    {
        public ApplicationDbContext _context;

        public ReadToppingHandler(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ResultOf<ReadToppingResponse>> Handle(ReadToppingRequest request, CancellationToken cancellationToken)
        {
            var topping = await _context.Toppings.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (topping == null)
                return new NotFoundError();

            var response = new ReadToppingResponse() { Id = topping.Id, Name = topping.Name, Price = topping.Price };

            return response;
        }
    }
}
